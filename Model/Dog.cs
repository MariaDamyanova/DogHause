using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogHouse.Model
{
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        // relation M M:1
        public int BreedId { get; set; } //FK
        public Breed Breeds { get; set; }//table with connect
    }
}
