using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogHouse.Model
{
    public class DogsDbContext:DbContext
    {
        public DogsDbContext():base("DogsDbContext")
        {

        }
        public DbSet<Dog> Dogs { get; set; }//creat table Dogs
        public DbSet<Breed> Breeds { get; set; }//creat table Breeds
    }
}
