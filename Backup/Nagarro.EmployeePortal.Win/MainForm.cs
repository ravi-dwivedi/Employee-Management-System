using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Nagarro.EmployeePortal.BLL;
using Nagarro.EmployeePortal.Win.Controls;

namespace Nagarro.EmployeePortal.Win
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
		}

		private void MainForm_Shown(object sender, EventArgs e)
		{
			ShowLogin();
		}

		private void ShowLogin()
		{
			LoginForm loginForm = new LoginForm();
			loginForm.LoginSuccess += new EventHandler(loginForm_LoginSuccess);
			loginForm.LoginCancel += new EventHandler(loginForm_LoginCancel);
			loginForm.ShowDialog(this);
		}

		void loginForm_LoginSuccess(object sender, EventArgs e)
		{
			((Form)sender).Close();

			this.adminToolStripMenuItem.Visible = Thread.CurrentPrincipal.IsInRole("Admin");

			// Set user name in welcome message
			this.loginStatusLabel.Text = string.Format("Welcome {0}", Thread.CurrentPrincipal.Identity.Name);

			// Show dashboard on login
			ShowDashboard();
		}

		void loginForm_LoginCancel(object sender, EventArgs e)
		{
			((Form)sender).Close();
			this.Close();
		}

		private void logoutButton_Click(object sender, EventArgs e)
		{
			if (Thread.CurrentPrincipal is EPPrincipal)
			{
				EPPrincipal principal = Thread.CurrentPrincipal as EPPrincipal;
				principal.Logout();
				Thread.CurrentPrincipal = principal;
			}

			ClearAllControl();
			this.loginStatusLabel.Text = "<none>";

			ShowLogin();
		}

		private void dashboardButton_Click(object sender, EventArgs e)
		{
			ShowDashboard();
		}

		void ShowDashboard()
		{
			AddControl(new DashboardControl());
		}

		private void AddControl(DashboardControl dashboardControl)
		{
			ClearAllControl();

			dashboardControl.Dock = DockStyle.Fill;
			this.mainContentPanel.Controls.Add(dashboardControl);
		}

		private void ClearAllControl()
		{
			this.mainContentPanel.Controls.Clear();
		}
	}
}
