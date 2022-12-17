using System;

namespace WindowsFormsApp1
{
    public class Room
    {
        public Room(int id, Guid[] instIds, string[] workNum, int minInst, int maxInst, 
            int minWorkers, int maxWorkers, int recCost, int instCount, int workersCount)
        {
            Id = id;
            InstIds = instIds;
            WorkNum = workNum;
            MinInst = minInst;
            MaxInst = maxInst;
            MinWorkers = minWorkers;
            MaxWorkers = maxWorkers;
            RecCost = recCost;
            InstCount = instCount;
            WorkersCount = workersCount;
        }

        public int Id { get; set; }

        public Guid[] InstIds { get; set; }

        public string[] WorkNum { get; set; }

        public int MinInst { get; set; }

        public int MaxInst { get; set; }

        public int MinWorkers { get; set; }

        public int MaxWorkers { get; set; }

        public int RecCost { get; set; }

        public int InstCount { get; set; }

        public int WorkersCount { get; set; }

        public static Room CreateRoom(int id, Guid[] instIds, string[] workNum, int minInst, int maxInst, 
            int minWorkers, int maxWorkers, int recCost, int instCount, int workersCount)
        {
            return new Room(id, instIds, workNum, minInst, maxInst, minWorkers, maxWorkers, recCost, instCount, workersCount);
        }
    }
}
