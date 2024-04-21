using System;
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
using UserManagementSystem.Models;
using UserManagementSystem.ViewModels;

namespace UserManagementSystem.Views
{
    /// <summary>
    /// Interaction logic for EditUserWindow.xaml
    /// </summary>
    public partial class EditUserWindow : Window
    {   
      
        public EditUserWindow(User selected)
        {
            InitializeComponent();
            EditUserViewModel editUserVM = new EditUserViewModel(selected);
            this.DataContext = editUserVM;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
