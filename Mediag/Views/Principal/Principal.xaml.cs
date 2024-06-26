﻿using System.Windows;

namespace Mediag.Views.Principal
{
    /// <summary>
    /// Interaction logic for Principal.xaml
    /// </summary>
    public partial class Principal : Window
    {
        public Principal(Models.Doctor doctor)
        {
            InitializeComponent();
            DataContext = new ViewModels.PrincipalVM(doctor)
            {
                ClosePrincipal = () => Close()
            };
        }
    }
}
