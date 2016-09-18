using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace DelSole.XamUtilities.Samples
{
    public class Employee: INotifyPropertyChanged
    {
        private string fullName;
        public string FullName
        {
            get
            {
                return fullName;
            }

            set
            {
                fullName = value; OnPropertyChanged();
            }
        }

        private byte[] picture;
        public byte[] Picture
        {
            get
            {
                return picture;
            }

            set
            {
                picture = value; OnPropertyChanged();
            }
        }

        private RolesEnum role;
        public RolesEnum Role
        {
            get
            {
                return role;
            }

            set
            {
                role = value; OnPropertyChanged();
            }
        }

        private DateTime? dateOfBirth;
        public DateTime? DateOfBirth
        {
            get
            {
                return dateOfBirth;
            }

            set
            {
                dateOfBirth = value; OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
