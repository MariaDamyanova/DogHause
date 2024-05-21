using DogHouse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogHouse.Controller
{
    internal class BreedsController
    {
        private DogsDbContext dogsDbContext = new DogsDbContext();

        public List<Breed> GetAllBreeds()
        {
            return dogsDbContext.Breeds.ToList();
        }
        public string GetBreedById(int id)
        {
            return dogsDbContext.Breeds.Find(id).Name;
        }


    }
}
