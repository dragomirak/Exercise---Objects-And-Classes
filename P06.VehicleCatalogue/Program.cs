namespace P06.VehicleCatalogue
{
    class Truck
    {
        public Truck(string brand, string model, int weight)
        {
            Brand = brand;
            Model = model;
            Weight = weight;
        }

        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }
    }

    class Car
    {
        public Car(string brand, string model, int horsePower)
        {
            Brand = brand;
            Model = model;
            HorsePower = horsePower;
        }

        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
    }

    class Catalog
    {

        public List<Truck> Trucks { get; set; } = new List<Truck>();
        public List<Car> Cars { get; set; } = new List<Car>();
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Catalog catalog = new Catalog();

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] data = input.Split("/");
                string type = data[0];
                string brand = data[1];
                string model = data[2];

                if (type == "Car")
                {
                    int horsePower = int.Parse(data[3]);
                    Car car = new Car(brand, model, horsePower);
                    catalog.Cars.Add(car);
                }
                else if (type == "Truck")
                {
                    int weight = int.Parse(data[3]);
                    Truck truck = new Truck(brand, model, weight);
                    catalog.Trucks.Add(truck);
                }
            }

            List<Car> orderedCars = catalog.Cars.OrderBy(car => car.Brand).ToList();
            Console.WriteLine("Cars:");
            foreach (Car car in orderedCars)
            {
                Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
            }

            List<Truck> orderedTrucks = catalog.Trucks.OrderBy(truck => truck.Brand).ToList();
            Console.WriteLine("Trucks:");
            foreach (Truck truck in orderedTrucks)
            {
                Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
            }

        }
    }
}