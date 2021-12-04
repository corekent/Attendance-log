using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceLog.Models
{
    class GroupModel
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        private int СounWeeks { get; set; }
        private int DaysOfWeek { get; set; }


    }
}
