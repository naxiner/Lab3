using System;
using System.Linq;

namespace WindowsFormsApp1
{
    public class Worker
    {
        public Worker(string id, string name, int salary, int trackCount)
        {
            Id = id;
            Name = name;
            Salary = salary;
            TrackCount = trackCount;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public int Salary { get; set; }

        public int TrackCount { get; set; }

        public static Worker CreateWorker(string id, string name, int salary, int trackCount)
        {
            return new Worker(id, name, salary, trackCount);
        }
    }
}
