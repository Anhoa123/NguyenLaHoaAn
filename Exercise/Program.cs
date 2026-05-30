namespace Exercise
{
    class Pet
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class PetOwner
    {
        public string Name { get; set; }
        public List<string> Pets { get; set; }
    }
    internal class Program
    {
        public static void SelectManyEx3()
    {
        PetOwner[] petOwners = { 
            new PetOwner { Name="Higa", Pets = new List<string>{ "Scruffy", "Sam" } },
            new PetOwner { Name="Ashkenazi", Pets = new List<string>{ "Walker", "Sugar" } },
            new PetOwner { Name="Price", Pets = new List<string>{ "Scratches", "Diesel" } },
            new PetOwner { Name="Hines", Pets = new List<string>{ "Dusty" } } 
        };

        var query = petOwners
            .SelectMany(
                petOwner => petOwner.Pets, 
                (petOwner, petName) => new { petOwner, petName } 
            )
            .Where(ownerAndPet => ownerAndPet.petName.StartsWith("S")) 
            .Select(ownerAndPet => new {
                Owner = ownerAndPet.petOwner.Name,
                Pet = ownerAndPet.petName
            }); 
        Console.WriteLine("Danh sach chu va thu cung co ten bat dau bang chu 'S':");
        foreach (var item in query)
        {
            Console.WriteLine($"Chu: {item.Owner,-10} | Thu cung: {item.Pet}");
        }
    }
        public static void OrderByEx1()
        {
            Pet[] pets = { new Pet { Name="Barley", Age=8 },
                       new Pet { Name="Boots", Age=4 },
                       new Pet { Name="Whiskers", Age=1 } };

            IEnumerable<Pet> query = pets.OrderBy(pet => pet.Age);

            Console.WriteLine("Danh sach thu cung sau khi sap xep theo tuoi tang dan:");
            foreach (Pet pet in query)
            {
                Console.WriteLine($"Ten: {pet.Name,-10} | Tuoi: {pet.Age}");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("câu 1");
            int[] n1 = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            // nQuery is an IEnumerable<int>
            var nQuery = from tmp in n1
                         where (tmp % 2) == 0
                         select tmp;
            foreach(int s in nQuery)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("câu 2");
            int[] n2 = { 1, 3, -2, -4, -7, -3, -8, 12, 19, 6, 9, 10, 14 };
            nQuery = from tmp in n2
                         where tmp > 0
                         where tmp < 12
                         select tmp;
            foreach(int t in nQuery)
            {
                Console.WriteLine(t);
            }

            Console.WriteLine("Câu 3");
            List<string> animals = new List<string> { "zebra", "elephant", "cat", "dog", "rhino", "bat" };
            var selectedAnimals = animals.Where(s => s.Length >= 5).Select(x => x.ToUpper());

            Console.WriteLine("Cac con vat co do dai tu 5 ky tu tro len (viet hoa):");
            foreach (var animal in selectedAnimals)
            {
                Console.WriteLine(animal);
            }

            Console.WriteLine("câu 4");
            List<int> numbers = new List<int> { 6, 0, 999, 11, 443, 6, 1, 24, 54 };

            var top5 = numbers.OrderByDescending(x => x).Take(5);

            Console.WriteLine("Top 5 so lon nhat trong danh sach:");
            foreach (var num in top5)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("câu 5");
            OrderByEx1();

            Console.WriteLine("câu 6");
            SelectManyEx3();

            Console.ReadLine();
        }
    }
}
