using System;
using System.Net.Sockets;
using System.Text;

namespace TelnetTemp
{
    public class TelnetConnection
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        enum Verbs
        {
            WILL = 251,
            WONT = 252,
            DO = 253,
            DONT = 254,
            IAC = 255
        }

        enum Options
        {
            SGA = 3
        }

        private TcpClient tcpSocket;

        private int TimeOutMs = 100;

        public TelnetConnection()
        {
            //tcpSocket = new TcpClient();
        }

        public void Connect(string Hostname, int Port)
        {
            try
            {
                if (tcpSocket != null)
                    tcpSocket = null;

                tcpSocket = new TcpClient(Hostname, Port);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw new Exception("Remote computer has opened a connection");
            }
        }

        public string Login(string Username, string Password, int LoginTimeOutMs)
        {
            int oldTimeOutMs = TimeOutMs;
            TimeOutMs = LoginTimeOutMs;
            string s = Read();
            if (!s.TrimEnd().EndsWith(":"))
                throw new Exception("Connection error: no login request required");
            WriteLine(Username);
            //Thread.Sleep(1000);
            s += Read();
            if (!s.TrimEnd().EndsWith(":")) { }
            //throw new Exception("Ошибка соединения: не требуется запрос пароля");
            else
            {
                WriteLine(Password);
            }

            TimeOutMs = 3000;
            s += Read();
            TimeOutMs = oldTimeOutMs;

            return s;
        }

        public void WriteLine(string cmd)
        {
            Write(cmd + "\n");
        }

        public void Write(string cmd)
        {
            if (!tcpSocket.Connected) return;
            byte[] buf = System.Text.ASCIIEncoding.ASCII.GetBytes(cmd.Replace("\0xFF", "\0xFF\0xFF"));
            tcpSocket.GetStream().Write(buf, 0, buf.Length);
        }

        public string Read()
        {
            if (tcpSocket == null)
                return null;

            if (!tcpSocket.Connected)
                return null;

            StringBuilder sb = new StringBuilder();
            do
            {
                ParseTelnet(sb);
                System.Threading.Thread.Sleep(TimeOutMs);
            } while (tcpSocket.Available > 0);

            return sb.ToString();
        }

        public void Close()
        {
            try
            {
                tcpSocket.Close();
                tcpSocket = null;
            }
            catch { }
            
            //logger.Info("Connection aborted");
        }

        public bool IsConnected
        {
            get { return tcpSocket.Connected; }
        }

        void ParseTelnet(StringBuilder sb)
        {
            while (tcpSocket.Available > 0)
            {
                int input = tcpSocket.GetStream().ReadByte();
                switch (input)
                {
                    case -1:
                        break;
                    case (int)Verbs.IAC:
                        // interpret as command
                        int inputverb = tcpSocket.GetStream().ReadByte();
                        if (inputverb == -1) break;
                        switch (inputverb)
                        {
                            case (int)Verbs.IAC:
                                //literal IAC = 255 escaped, so append char 255 to string
                                sb.Append(inputverb);
                                break;
                            case (int)Verbs.DO:
                            case (int)Verbs.DONT:
                            case (int)Verbs.WILL:
                            case (int)Verbs.WONT:
                                // reply to all commands with "WONT", unless it is SGA (suppres go ahead)
                                int inputoption = tcpSocket.GetStream().ReadByte();
                                if (inputoption == -1) break;
                                tcpSocket.GetStream().WriteByte((byte)Verbs.IAC);
                                if (inputoption == (int)Options.SGA)
                                    tcpSocket.GetStream().WriteByte(inputverb == (int)Verbs.DO ? (byte)Verbs.WILL : (byte)Verbs.DO);
                                else
                                    tcpSocket.GetStream().WriteByte(inputverb == (int)Verbs.DO ? (byte)Verbs.WONT : (byte)Verbs.DONT);
                                tcpSocket.GetStream().WriteByte((byte)inputoption);
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        sb.Append((char)input);
                        break;
                }
            }
        }
    }
}
