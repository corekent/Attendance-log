using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceLog.Storage
{
    class FileGroupIO
    {
        private string PATH_Group;

        public FileGroupIO(string path)
        {
            PATH_Group = path;
        }

        //public void SaveData(object groupModels)
        //{
        //    using (StreamWriter writer = File.CreateText(PATH_Group))
        //    {
        //        string output = JsonConvert.SerializeObject(groupModels);
        //        writer.Write(output);
        //    }
        //}
    }
}
