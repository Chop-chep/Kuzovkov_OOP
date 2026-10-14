namespace Lpz1
{
    public abstract class Vehicle
    {

        public string Model { get; private set; }
        public int Power { get; private set; }


        protected Vehicle(string model, int power)
        {
            if (power <= 0)
                throw new ArgumentException("Мощность должна быть положительным числом.", nameof(power));

            Model = model;
            Power = power;
        }


        public virtual string GetInfo()
        {
            return $"Модель: {Model}, Мощность: {Power} л.с.";
        }


        public abstract double CalculateTax();
    }
}