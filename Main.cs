using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamsWrapper
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

            string teamsPath = Environment.ExpandEnvironmentVariables(
                Path.Combine("%LOCALAPPDATA%", "Microsoft", "Teams", "current", "Teams.exe")
                );
            string teamsInstallerPath = Environment.ExpandEnvironmentVariables(
                Path.Combine("%PROGRAMFILES(x86)%", "Teams Installer", "Teams.exe")
                );


            // if Teams is already installed, launch it

            if (File.Exists(teamsPath)) {
                Process.Start(teamsPath);
                label.Text = "Launching Teams...";
                progressBar.Value = 50;
                Application.Exit();
            }

            if (File.Exists(teamsInstallerPath))
            {
                label.Text = "Installing Teams for you on this computer...";
                progressBar.Value = 25;
                Process installer = Process.Start(teamsInstallerPath);
                
                installer.WaitForExit();
                if (installer.ExitCode == 0)
                {
                    Process.Start(teamsPath);
                    label.Text = "Launching Teams...";
                    progressBar.Value = 50;
                    Application.Exit();
                }
                else
                {
                    label.Text = "The install of Teams failed. 😥";
                }
            }
            else
            {
                label.Text = "The Teams installer isn't on this computer. 😥";
            }


        }
    }
}
