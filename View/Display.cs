using DogHouse.Controller;
using DogHouse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DogHouse.View
{
    internal class Display
    {
        private DogsController dogContr = new DogsController();
        private int closeOperation = 6;
        public Display()
        {
            Input();
        }
        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string('-', 18) + "MENU" + new string('-', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Add new entry");
            Console.WriteLine("3. Update entry");
            Console.WriteLine("4. Fench entry by ID");
            Console.WriteLine("5. Delete entry by ID");
            Console.WriteLine("6. Exit");
        }
        private void Input()
        {
            var operation = -1;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {


                    case 1:
                        ListAll();
                        break;
                    case 2:
                        Add();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Fetch();
                        break;
                    case 5:
                        Delete();
                        break;
                    default:
                        break;
                }


            }
            while (true);
        }
        private void PrintDog(Dog dog)
        {
            Console.WriteLine($"{dog.Id}. {dog.Name} -- Age: {dog.Age} BreedId: {dog.BreedId}");
        }

        private void Delete()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            DogsController dogContorller = new DogsController();
            Dog dog = dogContorller.Get(id);
            if (dog != null)
            {
                dogContorller.Delete(id);
            }
        }

        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            DogsController dogContorller = new DogsController();
            Dog dog = dogContorller.Get(id);
            if (dog != null)
            {
                PrintDog(dog);
            }
        }

        private void Update()
        {
            Console.Write("Enter the DOG's id: ");
            int dogId = int.Parse(Console.ReadLine());
            Dog newDog = dogContr.Get(dogId);
            if (newDog == null)
            {
                Console.WriteLine("No searching dog");
                return;
            }
            PrintDog(newDog);

            Console.WriteLine("Enter the new values: ");
            Console.Write("Name: ");
            newDog.Name = Console.ReadLine();

            Console.Write("Age: ");
            newDog.Age = int.Parse(Console.ReadLine());

            BreedsController breedsLogic = new BreedsController();
            List<Breed> allBreeds = breedsLogic.GetAllBreeds();
            Console.WriteLine("Porodi:");
            Console.WriteLine(new string('-', 4));
            foreach (var item in allBreeds)
            {
                Console.WriteLine(item.Id + ". " + item.Name);
            }
            Console.WriteLine("Izberi poroda:");
            newDog.BreedId = int.Parse(Console.ReadLine());

            DogsController dogContorller = new DogsController();
            dogContorller.Update(dogId, newDog);
        }

        private void Add()
        {
            Dog newDog = new Dog();
            Console.Write("Name: ");
            newDog.Name = Console.ReadLine();

            Console.Write("Age: ");
            newDog.Age = int.Parse(Console.ReadLine());

            BreedsController breedsLogic = new BreedsController();
            List<Breed> allBreeds = breedsLogic.GetAllBreeds();
            Console.WriteLine("Porodi:");
            Console.WriteLine(new string('-', 4));
            foreach (var item in allBreeds)
            {
                Console.WriteLine(item.Id + ". " + item.Name);
            }
            Console.WriteLine("Izberi poroda:");
            newDog.BreedId = int.Parse(Console.ReadLine());

            DogsController dogContorller = new DogsController();
            dogContorller.Create(newDog);

            Console.WriteLine($"{newDog.Id}. {newDog.Name} >>> {newDog.Age} >> breed:{newDog.BreedId}");
        }
        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "DOGS" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            DogsController dogContorller = new DogsController();
            var products = dogContorller.GetAll();
            foreach (var item in products)
            {
                Console.WriteLine($"{item.Id} {item.Name} {item.Age}{item.BreedId}");
            }
        }
    }
}