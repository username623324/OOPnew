using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementSystem.Models
{
    public class User: INotifyPropertyChanged
    {
        private string? _name;

        public event PropertyChangedEventHandler? PropertyChanged;

        private string? _email;
        private DateTime? _birthDay;
        private string? _description;
      
        public string? Name
        {
            get { return _name; }
            set { _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string? Email
        {
            get { return _email; }
            set { _email = value; 
                OnPropertyChanged("Email"); }
        }

        public DateTime? Birthday
        {
            get { return _birthDay; }
            set { _birthDay = value; 
                OnPropertyChanged("Birthday"); }
        }
        public string? Description
        {
            get { return _description; }
            set { _description = value; 
                OnPropertyChanged("Description"); }
        }

        public User(string? name, string? email, DateTime? birthday, string? description)
        {
            Name = name;
            Email = email;
            Birthday = birthday;
            Description = description;
        }
        public User()
        {
            
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
