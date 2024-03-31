﻿using System.Windows;
using System.Windows.Controls;

namespace Mediag.Views.LogIn
{
    /// <summary>
    /// Interaction logic for SignLogIn.xaml
    /// </summary>
    public partial class SignLogIn : Window
    {
        public SignLogIn()
        {
            InitializeComponent();
        }

        private void GoToRegister_Click(object sender, RoutedEventArgs e)
        {
            LogInTabs.SelectedItem = RegisterTab;
        }

        private void GoToLogIn_Click(object sender, RoutedEventArgs e)
        {
            LogInTabs.SelectedItem = LogInTab;
        }
    }
}
