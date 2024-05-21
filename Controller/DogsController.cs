using DogHouse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogHouse.Controller
{
    internal class DogsController
    {
        private DogsDbContext dogsDbContext = new DogsDbContext();

        public Dog Get(int id)
        {
            Dog findedDog = dogsDbContext.Dogs.Find(id);
            if (findedDog != null)
            {
                dogsDbContext.Entry(findedDog).Reference(x => x.Breeds).Load();
            }
            return findedDog;
        }
        public List<Dog> GetAll()
        {
            return dogsDbContext.Dogs.Include("Breeds").ToList();
        }
        public void Create(Dog dog)
        {
            dogsDbContext.Dogs.Add(dog);
            dogsDbContext.SaveChanges();
        }
        public void Update(int id, Dog dog)
        {
            Dog findedDog = dogsDbContext.Dogs.Find(id);
            if (findedDog == null)
            {
                return;
            }
            findedDog.Age = dog.Age;
            findedDog.Name = dog.Name;
            findedDog.BreedId = dog.BreedId;
            dogsDbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            Dog findedDog = dogsDbContext.Dogs.Find(id);
            dogsDbContext.Dogs.Remove(findedDog);
            dogsDbContext.SaveChanges();
        }

    }
}
