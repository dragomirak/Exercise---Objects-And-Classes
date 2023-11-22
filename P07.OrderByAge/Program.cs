namespace P07.OrderByAge
{
    public class Person
    {
        public Person(string name, string idNumber, int age)
        {
            Name = name;
            IdNumber = idNumber;
            Age = age;
        }

        public string Name { get; set; }
        public string IdNumber { get; set; }
        public int Age { get; set; }

        public string UpdateName(string newName)
        {
            return Name = newName;
        }

        public int UpdateAge(int newAge)
        {
            return Age = newAge;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] personData = input.Split(" ");
                string name = personData[0];
                string idNumber = personData[1];
                int age = int.Parse(personData[2]);

                if (!persons.Any(x => x.IdNumber == idNumber))
                {
                    Person person = new Person(name, idNumber, age);
                    persons.Add(person);
                }
                else
                {
                    Person existingPerson = persons.First(x => x.IdNumber == idNumber);
                    existingPerson.UpdateName(name);
                    existingPerson.UpdateAge(age);
                }
            }

            List<Person> orderedPersons = persons.OrderBy(x => x.Age).ToList();
            foreach (Person person in orderedPersons)
            {
                Console.WriteLine($"{person.Name} with ID: {person.IdNumber} is {person.Age} years old.");
            }
        }
    }
}