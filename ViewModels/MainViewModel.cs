using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices; //CallerMemberName
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UserManagementSystem.Commands;
using UserManagementSystem.Models;
using UserManagementSystem.Views;
namespace UserManagementSystem.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<User> Users { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        public ICommand ShowAddUserWindowCommand { get; set; }
        public ICommand DeleteEntryCommand { get; set; }
        public ICommand EditUserEntryCommand { get; set; }
        public ICommand NextPageCommand {  get; set; }
        public ICommand PreviousPageCommand { get; set; }
        public ICommand GoToLastPageCommand {  get; set; }
        public ICommand GoToFirstPageCommand { get; set; }

        private User _selectedUser;
        private int _selectedIndex;
        private int _currentPage = 1;
        private int _numberOfPages = 1;
        private int _selectedRecord;

        public int SelectedRecordPerPage
        {
            get { return _selectedRecord; }
            set { _selectedRecord = value;
                CurrentPage = 1;
                OnPropertyChanged("CurrentPage");
                UpdateRecordCount();
            }
        }

        private void UpdateRecordCount()
        {
            NumberOfPages = Users.Count / SelectedRecordPerPage;
        }

        public int CurrentPage
        {
            get { return _currentPage; }
            set { _currentPage = value; 
                OnPropertyChanged("CurrentPage"); }
        }

        public int NumberOfPages
        {
            get { return _numberOfPages; }
            set { _numberOfPages = value; OnPropertyChanged("NumberOfPages"); }
        }


        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                OnPropertyChanged("SelectedUser");
                
            }
        }
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set { _selectedIndex = value; }
        }
        public MainViewModel()
        {
            Users = UserManagement.GetUsers();
            ShowAddUserWindowCommand = new RelayCommand(ShowAddWindow, CanShowAddWindow);
            DeleteEntryCommand = new RelayCommand(DeleteEntry,CanDeleteEntry);
            EditUserEntryCommand = new RelayCommand(ShowEditWindow, CanShowEditWindow);
            NextPageCommand = new RelayCommand(NextPage, CanNextPage);
            PreviousPageCommand = new RelayCommand(PreviousPage, CanPreviousPage);
            GoToLastPageCommand = new RelayCommand(GoToLastPage, CanGoToLastPage);
            GoToFirstPageCommand = new RelayCommand(GoToFirstPage, CanGoToFirstPage);
        }


        private bool CanGoToFirstPage(object obj)
        {
            return true;
        }

        private void GoToFirstPage(object obj)
        {
            CurrentPage = 1;
        }

        private bool CanGoToLastPage(object obj)
        {
            return true;
        }

        private void GoToLastPage(object obj)
        {   if(SelectedRecordPerPage != 0)
            {
                CurrentPage = Users.Count / SelectedRecordPerPage;
            }
            else
            CurrentPage = 1;
           
        }

        private bool CanPreviousPage(object obj)
        {
            return true;
        }

        private void PreviousPage(object obj)
        {   
            if(CurrentPage > 1) CurrentPage--;
            
        }

        private bool CanNextPage(object obj)
        {
            return true;
        }

        private void NextPage(object obj)
        {   if(SelectedRecordPerPage == 0)
            {
                SelectedRecordPerPage = Users.Count;
            }
            if (CurrentPage < Users.Count / SelectedRecordPerPage)
            {
                CurrentPage++;
            }
        
           
        }

        private bool CanShowEditWindow(object obj)
        {
            return true;
        }

        private void ShowEditWindow(object obj)
        {
            EditUserWindow editUserWindow = new EditUserWindow(SelectedUser);
            editUserWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen; 
            editUserWindow.Show();
        }

        private bool CanShowAddWindow(object obj)
        {
            return true;
        }

        private void ShowAddWindow(object obj)
        {
            //create instance of AddUserWindow view
            AddUserWIndow addUserWIndow = new AddUserWIndow();
            addUserWIndow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            addUserWIndow.Show(); //Actually show the window
        }
        private bool CanDeleteEntry(object obj)
        {
            return true;
        }
        private void DeleteEntry(object obj)
        {
            UserManagement.DeleteUser(SelectedUser);
        }
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
