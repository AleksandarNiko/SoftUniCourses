namespace RawData
{
    public class Car
    {
        public Car(string model, int speed, int power, int weight,string type, 
            double tire1Pressure, int tire1Age ,
            double tire2Pressure, int  tire2Age, double tire3Pressure, 
            int tire3Age, double tire4Pressure, int tire4Age)
        {
            Model=model;
            Engine = new Engine(speed, power);
            Cargo = new Cargo(type, weight);
            Tires = new Tyre[4];
            Tires[0] = new Tyre(tire1Pressure, tire1Age);
            Tires[1] = new Tyre(tire2Pressure, tire2Age);
            Tires[2] = new Tyre(tire3Pressure, tire3Age);
            Tires[3] = new Tyre(tire4Pressure, tire4Age);
        }

        public string Model { get; set; }

        public Engine Engine {get; set; }

        public Cargo Cargo { get; set; }

        public Tyre[] Tires { get; set; }
    }
}
