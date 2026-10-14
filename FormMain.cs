namespace Lpz1
{
    public partial class FormMain : Form
    {

        private List<Vehicle> fleet = new List<Vehicle>();

        public FormMain()
        {
            InitializeComponent();


            cmbVehicleType.Items.AddRange(new string[] { "Легковой", "Грузовой" });
            cmbVehicleType.SelectedIndex = 0;
        }


        private void cmbVehicleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isCar = cmbVehicleType.SelectedItem.ToString() == "Легковой";
            chkIsElectric.Visible = isCar;
            numCapacity.Visible = !isCar;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string model = txtModel.Text;
                int power = (int)numPower.Value;

                Vehicle vehicle;
                if (cmbVehicleType.SelectedItem.ToString() == "Легковой")
                {
                    bool isElectric = chkIsElectric.Checked;
                    vehicle = new Car(model, power, isElectric);
                }
                else
                {
                    double capacity = (double)numCapacity.Value;
                    vehicle = new Truck(model, power, capacity);
                }

                fleet.Add(vehicle);
                lstFleet.Items.Add(vehicle.GetInfo());
                MessageBox.Show("Транспорт успешно добавлен в автопарк!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка ввода: {ex.Message}");
            }
        }


        private void btnCalculateTax_Click(object sender, EventArgs e)
        {
            double totalTax = 0;
            foreach (var v in fleet)
            {

                totalTax += v.CalculateTax();
            }
            lblTotalTax.Text = $"Суммарный налог: {totalTax} руб.";
        }


        private void btnSaveStorable_Click(object sender, EventArgs e)
        {
            int savedCount = 0;
            foreach (var v in fleet)
            {

                if (v is IStorable storable)
                {
                    storable.Save(storable.FilePath);
                    savedCount++;
                }
            }
            MessageBox.Show($"Данные объектов IStorable успешно сохранены (файлов: {savedCount}).");
        }
    }
}