namespace Lpz1
{
    public class Truck : Vehicle, IStorable
    {

        public double LoadCapacity { get; private set; }


        public string FilePath => "truck_data.txt";


        public Truck(string model, int power, double loadCapacity) : base(model, power)
        {
            LoadCapacity = loadCapacity;
        }


        public override string GetInfo()
        {
            return $"Грузовой | {base.GetInfo()}, Грузоподъемность: {LoadCapacity} т";
        }

        public override double CalculateTax()
        {
            return Power * 25.0;
        }


        public void Save(string path)
        {
            string data = $"Грузовик: {Model}\nМощность: {Power} л.с.\nГрузоподъемность: {LoadCapacity} т\nНалог: {CalculateTax()} руб.";
            File.WriteAllText(path, data);
        }
    }
}