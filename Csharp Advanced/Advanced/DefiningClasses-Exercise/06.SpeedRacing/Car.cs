namespace DefiningClasses
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance;

        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
            }
        }

        public double FuelAmount
        {
            get
            {
                return this.fuelAmount;
            }
            set
            {
                this.fuelAmount = value;
            }
        }

        public double FuelConsumptionPerKilometer
        {
            get
            {
                return this.fuelConsumptionPerKilometer;
            }
            set
            {
                this.fuelConsumptionPerKilometer=value;
            }
        }

        public double TravelledDistance
        {
            get
            {
                return this.travelledDistance;
            }
            set
            {
                this.travelledDistance = value;
            }
        }
        public void CanMoveDistance(string model, double amountKm)
        {
            double neededLiters = amountKm * this.FuelConsumptionPerKilometer;

            if (this.FuelAmount >= neededLiters)
            {
                this.fuelAmount -= neededLiters;
                this.TravelledDistance += amountKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
