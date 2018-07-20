using System;

namespace EisenhowerMatrix.Entities
{
    public class TodoTask
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Urgency { get; set; }

        public double Importance { get; set; }

        public bool IsFinished { get; set; }
    }
}
