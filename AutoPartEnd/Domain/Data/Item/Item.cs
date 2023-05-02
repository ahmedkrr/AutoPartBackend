using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Domain
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public string Discription { get; private set; }
        public double Price { get; private set; }
        public string ImageData { get; set; }

        public DateTime CreatedTime { get; private set; }
        public DateTime? ModifiedAt { get; set; }
        public int? ModifiedBy { get; set; }

        public UserProfile UserProfile { get; private set; }
        public int UserProfileId { get; private set; }

        public CompanyProfile CompanyProfile { get; set; }
        public int CompanyProfileId { get; private set; }

        public CarModel CarModel { get; set; }
        public int? CarModelId { get; private set; }

        public CarType CarType { get; set; }
        public int? CarTypeId { get; private set; }

        public ManufactureYear ManufactureYear { get; set; }
        public int? ManufactureYearId { get; private set; }

        public SubCategory SubCategory { get; set; }
        public int SubCategoryId { get; private set; }

        public Item() { }
        public Item(string name ,string discription ,double price, int companyProfileId, int userProfileId, int? carModelId, int? carTypeId, int? manufactureYearId, int subCategoryId ,DateTime createdTime ,string imageData)
        {
            Name = name;
            Discription = discription;
            Price = price;
            CompanyProfileId = companyProfileId;
            UserProfileId = userProfileId;
            CarModelId = carModelId;
            CarTypeId = carTypeId;
            ManufactureYearId = manufactureYearId;
            SubCategoryId = subCategoryId;
            CreatedTime = createdTime;
            ImageData = imageData;
        }


        public void setCarModelId(int id)
        {
            CarModelId = id;
        }
        public void setCarTypeId(int id)
        {
            CarTypeId = id;
        }
        public void setManufactureYearId(int id)
        {
            ManufactureYearId = id;
        }
        public void setSubCategoryId(int id)
        { 
            SubCategoryId = id; 
        }
        public void Update(string name, string discription, double price)
        {
            if (!string.IsNullOrEmpty(name))
            {
                Name = name;
            }
            if (!string.IsNullOrEmpty(discription))
            {
                Discription = discription;
            }
            if (price != 0)
            {
                Price = price;
            }
        }
    }
}
