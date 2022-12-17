using System;

namespace WindowsFormsApp1
{
    public class Instrument
    {
        public Instrument(Guid id, string type, int price)
        {
            Id = id;
            Type = type;
            Price = price;
        }

        public Guid Id { get; set; }

        public string Type { get; set; }

        public int Price { get; set; }

        public static Instrument CreateInstrument(string type, int price)
        {
            return new Instrument(Guid.NewGuid(), type, price);
        }
    }
}
