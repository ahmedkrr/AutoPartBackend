using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Domain
{
    public class ManufactureYear
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        public DateTime Year { get; private set; }

        public CarType Types { get; set; }
        public int TypeId { get; private set; }

        public ManufactureYear(DateTime year, int typeId)
        {
            Year = year;
            TypeId = typeId;
        }
        public void update(DateTime year)
        {
            Year = year;

        }

    }
}
