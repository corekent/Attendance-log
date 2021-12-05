using AttendanceLog.Models;
using AttendanceLog.Storage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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

namespace AttendanceLog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly string PATH = $"{Environment.CurrentDirectory}\\Storage\\Students.json";
        private FileIO _fileIO;
        ObservableCollection<StudentModel> _studentsList = new ObservableCollection<StudentModel> { };

        
        public MainWindow()
        {
            InitializeComponent();                        
        }

        private void Button_AddNameGroup_Click(object sender, RoutedEventArgs e)
        {
            string groupsName = GroupsName.Text.Trim();
            CheckInput(groupsName, 1);
        }

        private void Button_AddStartDate_Click(object sender, RoutedEventArgs e)
        {

            string startDate = Convert.ToString(StartDate);
            CheckInput(startDate, 2);
        }

        private void CheckInput(string checkString, int type)
        {
            if (checkString == "")
            {
                if (type == 1)
                {
                    MessageBox.Show("Введите значение");
                }
                else if (type == 2)
                {
                    MessageBox.Show("Выберете дату");
                }
                else
                {
                    MessageBox.Show("Выберете дни занятий");
                }

            }
        }

        //private void SaveStartDate_Click(object sender, RoutedEventArgs e)
        //{
        //    DateTime startDay = StartDate.DisplayDate.Date;
        //    MainWindow.StartDateTextBox = Convert.ToString(startDay);
        //}

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
            _fileIO = new FileIO(PATH);            

            try
            {
                _studentsList = _fileIO.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }

            dg_Attendance.ItemsSource = _studentsList;
            _studentsList.CollectionChanged += _studentsList_CollectionChanged;
        }

        private void _studentsList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            //if (e.Action == NotifyCollectionChangedAction.Add ||
            //    e.Action == NotifyCollectionChangedAction.Remove || 
            //    e.Action == NotifyCollectionChangedAction.Replace)
            //{
                try
                {
                    _fileIO.SaveData(sender);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }                
            //}
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }



       

       
    }
}
