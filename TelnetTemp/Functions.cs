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
    }
}
