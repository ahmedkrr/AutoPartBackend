using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Domain
{
    public class CarModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

       
        public string Name { get; private set; }

        public ICollection<CarType> CarTypes { get; private set; }


        public CarModel(string name)
        {
            Name = name;
        }
        public void update(string name)
        {
            Name = name;
        }
    }
}
