using AttendanceLog.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceLog.Storage
{
    public class FileStudentsIO
    {
        private string PATH_Students;

        public FileStudentsIO(string path)
        {
            PATH_Students = path;
        }

        public void SaveData(object studentModels)
        {
            using (StreamWriter writer = File.CreateText(PATH_Students))
            {
                string output = JsonConvert.SerializeObject(studentModels);
                writer.Write(output);
            }
        }

        public ObservableCollection<StudentModel> LoadData()
        {
            var fileExist = File.Exists(PATH_Students);
            if (!fileExist)
            {
                File.CreateText(PATH_Students).Dispose();
                return new ObservableCollection<StudentModel>();
            }
            var reader = File.OpenText(PATH_Students);

            var fileText = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<ObservableCollection<StudentModel>>(fileText);

        }

    }
}
