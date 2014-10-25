using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PWManager
{
	/// <summary>
	/// Interaction logic for StartScreen.xaml
	/// </summary>
	public partial class StartScreen : UserControl
	{
		public StartScreen()
		{
			this.InitializeComponent();
		}

		private void LoginBtn_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            Navigator.Navigate(new LoginScreen());
		}

		private void NewUserBtn_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            Navigator.Navigate(new UserScreen());
		}
	}
}