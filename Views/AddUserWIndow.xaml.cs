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
using System.Windows.Shapes;
using UserManagementSystem.ViewModels;

namespace UserManagementSystem.Views
{
    /// <summary>
    /// Interaction logic for AddUserWIndow.xaml
    /// </summary>
    public partial class AddUserWIndow : Window
    {
        public AddUserWIndow()
        {
            InitializeComponent();
            AddUserViewModel addUserVM = new AddUserViewModel();
            this.DataContext = addUserVM;
        }
    }
}
