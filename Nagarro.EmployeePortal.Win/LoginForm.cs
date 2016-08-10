using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nagarro.EmployeePortal.BLL;
using System.Threading;

namespace Nagarro.EmployeePortal.Win
{
	public partial class LoginForm : Form
	{
		public event EventHandler LoginSuccess;
		public event EventHandler LoginCancel;

		public LoginForm()
		{
			InitializeComponent();
		}

		private void loginButton_Click(object sender, EventArgs e)
		{
			EPPrincipal principal = new EPPrincipal();
			if (principal.Login(this.usernameTextBox.Text, this.passwordTextBox.Text))
			{
				Thread.CurrentPrincipal = principal;
				OnLoginSuccess();
			}
			else
			{
				MessageBox.Show("Invalid username or password.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			OnLoginCancel();
		}

		protected void OnLoginSuccess()
		{
			if (this.LoginSuccess != null)
			{
				this.LoginSuccess(this, EventArgs.Empty);
			}
		}

		protected void OnLoginCancel()
		{
			if (this.LoginCancel != null)
			{
				this.LoginCancel(this, EventArgs.Empty);
			}
		}
	}
}
