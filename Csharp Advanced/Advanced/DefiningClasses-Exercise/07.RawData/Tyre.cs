namespace RawData
{
    public class Tyre
    {
        public Tyre(double pressure,int age)
        {
            Age=age;
            Pressure=pressure;
        }
        public double Pressure
        {
            get;
            set;
        }
        public int Age
        {
            get;
            set;
        }

    }
}
