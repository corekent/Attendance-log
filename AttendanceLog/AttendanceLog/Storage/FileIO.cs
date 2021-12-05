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
    class FileIO
    {
        private string PATH;

        public FileIO(string path)
        {
            PATH = path;
        }

        public void SaveData(ObservableCollection<StudentModel> studentModels)
        {
            using(StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(studentModels);
                writer.Write(output);
            }
        }

        public ObservableCollection<StudentModel> LoadData()
        {
            var fileExist = File.Exists(PATH);
            if (!fileExist)
            {
                File.CreateText(PATH).Dispose();
                return new ObservableCollection<StudentModel>();
            }
            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<ObservableCollection<StudentModel>>(fileText);
            }
            
        }

    }
}
