using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Events
{
    public class StudentIsGraduatedEventArgs : EventArgs
    {
        public Guid StudentId { get; private set; }

        public StudentIsGraduatedEventArgs(Guid studentId)
        {
            StudentId = studentId;
        }
    }
}
