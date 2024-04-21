using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserManagementSystem.Models;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Linq.Expressions;
using UserManagementSystem.Commands;
using System.ComponentModel;
using System.Windows;
using System.Runtime.CompilerServices;

namespace UserManagementSystem.ViewModels
{
    public class EditUserViewModel
    {   
        public ICommand doneEdit {  get; set; }
        public User UserPicked {  get; set; }
        public string? Name {  get; set; }
        public string? Email { get; set; }
        public DateTime? BirthDay { get; set; }
        public string? Description { get; set; }
       

        
        public EditUserViewModel(User userPicked)
        {
            doneEdit = new RelayCommand(Edit, CanEdit);
            UserPicked = userPicked;
            Name = userPicked.Name;
            Email = userPicked.Email;
            BirthDay = userPicked.Birthday;
            Description = userPicked.Description;
        }

        
        private bool CanEdit(object obj)
        {
            return true;
        }

        private void Edit(object obj)
        {
            UserPicked.Name = Name;
            UserPicked.Email = Email;
            UserPicked.Description = Description;
            UserPicked.Birthday = BirthDay;
            
            var editUserWindow = obj as Window;
            editUserWindow.Close();

            string message = "Update Complete!";
            string caption = "Information";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBox.Show(message, caption, button, icon);

        }

        
    }
}
