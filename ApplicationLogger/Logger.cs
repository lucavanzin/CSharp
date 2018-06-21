using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using LaserIndustries;


namespace LaserIndustries.ApplicationLogger
{
    public class Logger
    {
        private string m_path = string.Empty;
        private string m_name = string.Empty;
        private string m_filepath = string.Empty;
        private bool LogEnabled; 

        public Logger (string path, string name)
        {
            m_path = path;
            m_name = name;
            m_filepath = m_path + "\\" + m_name + ".txt";

            try
            {
                CheckStrings.CheckFileNameExtension(m_filepath);
                if (Directory.Exists(m_path) == false)
                {
                    Directory.CreateDirectory(m_path);
                }
                FileStream fs = new FileStream(m_filepath,
                   FileMode.OpenOrCreate, FileAccess.ReadWrite);
                fs.Close();
                LogEnabled = true;
            }
            catch (Exception ex)
            {
                string defaultpath = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents");
                string logstring =(String.Format("Unable to access the file {0}. Details: {1}", m_filepath, ex.Message));
                LogElement(defaultpath, logstring);
                LogEnabled = false;
            }
        }



        public static void LogEvent(string s)
        {
            if (LogEnabled == false)

        }


        private void LogElement (string path, string s)
        {

            StreamWriter sw = new StreamWriter(path, true);
            sw.Write(s);
            sw.Flush();
            sw.Close();
        }

    }
}
