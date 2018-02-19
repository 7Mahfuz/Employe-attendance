using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Employee_attendance_Web.Models
{
    public class Attendance
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Username { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [DataType(DataType.Time)]
        public DateTime Enter { get; set; }
        [DataType(DataType.Time)]
        public DateTime Out { get; set; }
        [DataType(DataType.Time)]
        public string Timing { get; set; }
    }
}