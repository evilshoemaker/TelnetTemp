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

        public static string PostMethod(string data)
        {
            //создаем ссылку на которую будем слать наш запрос
            //string postUrl = "http://arsenal.army/index.php?option=com_jshopping&controller=modem&task=smsGet";

            byte[] sentData = Encoding.UTF8.GetBytes("json=" + System.Web.HttpUtility.UrlEncode(data, Encoding.UTF8));

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Settings.Instance.UrlHost);
            request.Method = "POST";
            request.SendChunked = true;

            request.ContentType = "application/x-www-form-urlencoded";

            request.ContentLength = sentData.Length;

            //начинаем передачу
            using (var newStream = request.GetRequestStream())
            {
                newStream.Write(sentData, 0, sentData.Length);
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();//ждем ответа от сервера
            /*string responseToString = "";

            //если ответ пришел и он не нулевой
            if (response != null)
            {
                var strreader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);//получаем ответ в кодировке утф8
                responseToString = strreader.ReadToEnd();
            }
            return responseToString; //возвращаем строку с ответом*/
            return null;
        }
    }
}
