using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EisenhowerMatrix.Web.Models.TodoTaskOldSchool
{
    public class TaskModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Urgency { get; set; }

        public double Importance { get; set; }

        public bool IsFinished { get; set; }
    }
}
