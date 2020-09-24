using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using log4net.Config;

namespace TeamsWrapper
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private void Main_Load(object sender, EventArgs e)
        {

            XmlConfigurator.Configure(new System.IO.FileInfo(Path.Combine(
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "logging.xml"
                )));


            log.Info($"===============================================");
            log.Info($"Launched at {DateTime.Now}");


            string teamsPath = Environment.ExpandEnvironmentVariables(
                Path.Combine("%LOCALAPPDATA%", "Microsoft", "Teams", "current", "Teams.exe")
                );
            string teamsInstallerPath = Environment.ExpandEnvironmentVariables(
                Path.Combine("%PROGRAMFILES(x86)%", "Teams Installer", "Teams.exe")
                );
            string teamsUpdatePath = Environment.ExpandEnvironmentVariables(
                    Path.Combine("%LOCALAPPDATA%", "Microsoft", "Teams", "Update.exe")
                );

            bool procFound = false;

            // if Teams is running, front-most it
            try {
                if (Process.GetProcessesByName("Teams").Length > 0)
                {
                    log.Info("Teams is running. Launching it");
                    Process.Start("msteams://");
                    procFound = true;
                    Application.Exit();
                }
                else { 
                    log.Info("Didn't find teams running");
                }
            }
            catch (Exception ex)
            {
                log.Error("Failed to determine if Teams is running");
                log.Error(ex.ToString());
            }

            // if Teams is already installed, launch it

            if (!procFound) // apparently Application.Exit() isn't immediate
            {
                if (File.Exists(teamsUpdatePath))
                {
                    log.Info($"Teams update path exists at {teamsUpdatePath}. Starting it with --processStart Teams.exe");
                    Process.Start(teamsPath, "--processStart Teams.exe");
                    label.Text = "Launching Teams...";
                    progressBar.Value = 50;
                    Application.Exit();
                }

                else if (File.Exists(teamsInstallerPath))
                {
                    log.Info("Installing Teams for the user on the computer -- wasn't found in LocalAppData");
                    label.Text = "Installing Teams for you on this computer...";
                    progressBar.Value = 25;
                    Process installer = Process.Start(teamsInstallerPath);

                    installer.WaitForExit();
                    if (installer.ExitCode == 0)
                    {
                        Process.Start(teamsPath);
                        log.Info("Teams installer completed");
                        label.Text = "Launching Teams...";
                        progressBar.Value = 50;
                        Application.Exit();
                    }
                    else
                    {
                        log.Error($"Teams installer failed with exit code {installer.ExitCode}");
                        label.Text = "The install of Teams failed. 😥";
                    }
                }
                else
                {
                    log.Error($"Teams installer was not in {teamsInstallerPath}");
                    label.Text = "The Teams installer isn't on this computer. 😥";
                }
            }
            
            

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
