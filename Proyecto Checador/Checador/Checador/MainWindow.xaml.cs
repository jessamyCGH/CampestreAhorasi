﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Checador
{
    delegate void Function();

    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();

            this.WindowState = WindowState.Maximized;
        }

        private void btnEmpleados_Click(object sender, RoutedEventArgs e)
        {
            Empleados emp = new Empleados();
            emp.Show();
        }

        private void btnChecador_Click(object sender, RoutedEventArgs e)
        {
            Check check = new Check();
            check.Show();
        }
    }
}
