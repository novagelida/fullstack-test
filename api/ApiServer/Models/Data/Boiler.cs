namespace ApiServer.Models
{
    public class Boiler : DataModel
    {
        public string Brand { get; set; }

        public string ModelName { get; set; }

        public bool Available { get; set; }

        public string Type { get; set; }

        public int WattPower { get; set; }

        public string PoweredBy { get; set; }

        public string Usage { get; set; }

        public float Price { get; set; }

        public string Includes { get; set; }

        public bool Promo { get; set; }

        public string DiscountDisclaimer { get; set; }

        public float? OldPrice { get; set; }

        public int Rating { get; set; }
    }
}
