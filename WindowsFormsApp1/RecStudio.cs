namespace WindowsFormsApp1
{
    public class RecStudio
    {
        public RecStudio(string nameOfStudio, string adressOfStudio, int countOfWorkers, double trackCreationCost, double trackCreationTime,
            double oneWorkerSalary, double allWorkersSalary, int numberOfInstruments, int numberOfRooms)
        {
            NameOfStudio = nameOfStudio;
            AdressOfStudio = adressOfStudio;
            CountOfWorkers = countOfWorkers;
            TrackCreationCost = trackCreationCost;
            TrackCreationTime = trackCreationTime;
            OneWorkerSalary = oneWorkerSalary;
            AllWorkersSalary = allWorkersSalary;
            NumberOfInstruments = numberOfInstruments;
            NumberOfRooms = numberOfRooms;
        }

        public string NameOfStudio { get; set; }

        public string AdressOfStudio { get; set; }

        public int CountOfWorkers { get; set; }

        public double TrackCreationCost { get; set; }

        public double TrackCreationTime { get; set; }

        public double OneWorkerSalary { get; set; }

        public double AllWorkersSalary { get; set; }

        public int NumberOfInstruments { get; set; }

        public int NumberOfRooms { get; set; }

        public static RecStudio CreateRecStudio(string nameOfStudio)
        {
            return new RecStudio(nameOfStudio, "None", 0, 0, 0, 0, 0, 0, 0);
        }
    }
}
