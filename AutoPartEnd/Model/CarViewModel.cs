using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Model
{
    public class CarViewModel
    {
    }
    public class AddCarModelName
    {
        public string CarName { get;  set; }
        public string CarType { get; set; }
        public DateTime CarYear { get; set; }
    }

    public class AddCartype
    {
        public int Id { get; set; }
        public string CarType { get; set; }
        public DateTime CarYear { get; set; }

    }
    public class AddCaryear
    {
        public int CarId { get; set; }
        public int TypeId { get; set; }
        public DateTime CarYear { get; set; }

    }
    public class GetCarResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GetTypeResponse> Type { get; set; }
    }
    public class GetTypeResponse
    {
        public int Id { get; set; }
        public int CarID { get; set; }
        public string Type { get; set; }
        public List<GetManufactureResponse> Year { get; set; }
    }
    public class GetManufactureResponse
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string  Years { get; set; }
    }
    
    public class GetData
    {
        public int Carid { get; set; }
        public string CarName { get; set; }
        public string TypeName { get; set; }
        public int TypeId { get; set; }
        public string Year { get; set; }
        public int YearId { get; set; }

    }
    public class UpdateCarRequest
    {
        public int CarModelId { get; set; }
        public string Name { get; set; }

        public string TypeName { get; set; }

        public string Year { get; set; }

        public int TypeId { get; set; }

        public int YearId { get; set; }
    }
   
}
