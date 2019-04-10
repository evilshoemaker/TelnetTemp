using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TelnetTemp
{
    public class TeMonitorSocketInfo
    {
        public string SocketId;
        public string SensorIndex;
        public string SensorId;
        public string Temperature;
        public string Unit;

        public TeMonitorSocketInfo()
        {

        }

        public static TeMonitorSocketInfo FromTelnetString(string text)
        {
            string cleanedText = Regex.Replace(text, @"\s+", " ");
            string[] par = text.Split(new[] { " ", "\t", "\r\n", "\r", "\n" },
                                        StringSplitOptions.RemoveEmptyEntries);

            if (par.Length <= 5)
                return null;

            TeMonitorSocketInfo result = new TeMonitorSocketInfo();
            result.SocketId = par[1];
            result.SensorIndex = par[2];
            result.SensorId = par[3];
            result.Temperature = par[4];
            result.Unit = par[5];

            return result;
        }
    }
}
