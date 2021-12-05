using AttendanceLog.Models;
using AttendanceLog.Storage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            CheckInput(groupsName);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _studentsList = _fileIO.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
            _fileIO = new FileIO(PATH);
            dg_Attendance.ItemsSource = _studentsList;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }



        private void Button_StartDate_Click(object sender, RoutedEventArgs e)
        {

            //DateTime startDate = 
        }

        //private void SaveStartDate_Click(object sender, RoutedEventArgs e)
        //{
        //    DateTime startDay = StartDate.DisplayDate.Date;
        //    MainWindow.StartDateTextBox = Convert.ToString(startDay);
        //}

        private void CheckInput(string checkString)
        {
            if(checkString == "")
            {
                MessageBox.Show("Введите значение");
            }
        }
    }
}
