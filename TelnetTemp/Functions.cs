using System.IO;
using System.Net;
using System.Text;
using Microsoft.Win32;

namespace TelnetTemp
{
    public static class Functions
    {
        public static bool SetAutorunValue(bool autorun)
        {
            string ExePath = System.Windows.Forms.Application.ExecutablePath;
            RegistryKey reg;
            reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");
            try
            {
                if (autorun)
                    reg.SetValue(Variables.ApplicationName, ExePath);
                else
                    reg.DeleteValue(Variables.ApplicationName);

                reg.Close();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static bool IsAutorun()
        {
            try
            {
                string ExePath = System.Windows.Forms.Application.ExecutablePath;
                RegistryKey reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");
                if (ExePath == reg.GetValue(Variables.ApplicationName).ToString()) return true;
            }
            catch { }

            return false;
        }

        public static string PostRequest(string url, string data)
        {
            byte[] sentData = Encoding.UTF8.GetBytes(data);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            //request.SendChunked = true;
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = sentData.Length;

            using (var newStream = request.GetRequestStream())
            {
                newStream.Write(sentData, 0, sentData.Length);
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string responseToString = "";

            if (response != null)
            {
                var strreader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                responseToString = strreader.ReadToEnd();
            }

            return responseToString;
        }
    }
}
