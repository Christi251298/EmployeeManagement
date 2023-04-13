using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace WPF.Models
{
    public class Employee : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private int Id;

        public int id
        {
            get { return Id; }
            set { Id = value; OnPropertyChanged("id"); }
        }
        private string Name;

        public string name
        {
            get { return Name; }
            set { Name = value; OnPropertyChanged("name"); }
        }

        private string Email;

        public string email
        {
            get { return Email; }
            set { Email = value; OnPropertyChanged("email"); }
        }
        private string Gender;

        public string gender
        {
            get { return Gender; }
            set { Gender = value; OnPropertyChanged("gender"); }
        }

        private string Status;

        public string status
        {
            get { return Status; }
            set { Status = value; OnPropertyChanged("status"); }
        }

    }

}
