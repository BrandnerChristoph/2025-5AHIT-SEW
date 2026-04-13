using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradeManagement.Model
{
    public class Student
    {
        public string Name { get; set; }
        public string Class { get; set; }

        public ObservableCollection<Grade> Grades { get; set; } = new();

    }
}
