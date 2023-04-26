using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Domain
{
    public class CarType 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        public string Name { get; private set; }

        public CarModel Model { get; private set; }
        public int ModelId { get; private set; }

        public ICollection<ManufactureYear> ManufactureYears { get; set; }


        public CarType(string name, int modelId) 
        {
            Name = name;
            ModelId = modelId;
        }

    }
}
