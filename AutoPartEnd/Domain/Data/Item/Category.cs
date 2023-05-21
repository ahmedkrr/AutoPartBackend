using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; private set; }
        public string ImageData { get; set; }
        public ICollection<SubCategory> SubCategories { get; set; }

        public  Category(string categoryName)
        {
            CategoryName = categoryName;
        }
        public void UpdateCatgory(string name)
        {
            CategoryName = name;
        }
        public void UpdateCatgory(string name , string imageData)
        {
            CategoryName = name;
            ImageData = imageData;
        }
    }
}
