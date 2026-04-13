using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradeManagement.Model
{
    public class Grade
    {
        public string Subject { get; set; }
        public int Value { get; set; }

        public Grade(string subject, int value) {
            this.Subject = subject;
            this.Value = value;
        }
    }
}
