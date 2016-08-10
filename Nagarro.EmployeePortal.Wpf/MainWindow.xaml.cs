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
using System.Threading;

namespace Nagarro.EmployeePortal.Wpf
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			ShowLogin();
		}

		private void ShowLogin()
		{
			LoginWindow loginForm = new LoginWindow();
			loginForm.LoginSuccess += new EventHandler(loginForm_LoginSuccess);
			loginForm.LoginCancel += new EventHandler(loginForm_LoginCancel);
			loginForm.ShowDialog();
		}

		void loginForm_LoginSuccess(object sender, EventArgs e)
		{
			((Window)sender).Close();
			this.menuTree.Visibility = Visibility.Visible;

			this.adminMenuTree.Visibility = 
				Thread.CurrentPrincipal.IsInRole("Admin") 
				? Visibility.Visible 
				: Visibility.Hidden;

			this.statusLabel.Content = string.Format("Welcome {0}", Thread.CurrentPrincipal.Identity.Name);
			
		}

		void loginForm_LoginCancel(object sender, EventArgs e)
		{
			((Window)sender).Close();
			this.Close();
		}
	}
}
