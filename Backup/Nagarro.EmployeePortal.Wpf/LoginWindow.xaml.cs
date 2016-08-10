using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Nagarro.EmployeePortal.BLL;
using System.Threading;

namespace Nagarro.EmployeePortal.Wpf
{
	/// <summary>
	/// Interaction logic for LoginWindow.xaml
	/// </summary>
	public partial class LoginWindow : Window
	{
		public event EventHandler LoginSuccess;
		public event EventHandler LoginCancel;

		public LoginWindow()
		{
			InitializeComponent();
		}

		private void loginButton_Click(object sender, RoutedEventArgs e)
		{
			EPPrincipal principal = new EPPrincipal();
			if (principal.Login(this.usernameTextBox.Text, this.passwordTextBox.Password))
			{
				Thread.CurrentPrincipal = principal;
				OnLoginSuccess();
			}
			else
			{
				MessageBox.Show("Invalid username or password.", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void cancelButton_Click(object sender, RoutedEventArgs e)
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

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			this.usernameTextBox.Focus();
		}
	}
}
