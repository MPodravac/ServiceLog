using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsLoggingService
{
    public partial class Service1 : ServiceBase
    {
        public string sDateTime;
        public string sText;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            sDateTime = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            sText = "Servis je pokrenut " + sDateTime;
            WriteToFile(sText);
        }

        protected override void OnStop()
        {
            sDateTime = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            sText = "Servis je zaustavljen " + sDateTime;
            WriteToFile(sText);
        }
        private static void WriteToFile(string text)
        {
            string path = "D:\\DotNet\\DotNetServiceLog.txt";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(string.Format(text, DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")));

                writer.Close();

            }
        }
    }
}
