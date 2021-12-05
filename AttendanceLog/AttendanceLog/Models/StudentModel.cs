using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceLog.Models
{
    public class StudentModel: INotifyPropertyChanged
    {
        public int Number { get; set; }
        private string _name;
        
        public int Attendance { get; set; }

        public string Name 
        {
            get
            {
                return _name;
            } 
            set
            {
                if(_name == value)
                {
                    return;
                }
                else
                {
                    _name = value;
                    ChengedName("Name");
                }

            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void ChengedName(string Name = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(Name));
            }
        }
    }
}
 