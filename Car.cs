namespace Lpz1
{
    public class Car : Vehicle
    {

        public bool IsElectric { get; private set; }


        public Car(string model, int power, bool isElectric) : base(model, power)
        {
            IsElectric = isElectric;
        }


        public override string GetInfo()
        {
            string typeDesc = IsElectric ? "Электромобиль" : "Легковой";
            return $"{typeDesc} | {base.GetInfo()}";
        }


        public override double CalculateTax()
        {

            double rate = IsElectric ? 5.0 : 12.0;
            return Power * rate;
        }
    }
}