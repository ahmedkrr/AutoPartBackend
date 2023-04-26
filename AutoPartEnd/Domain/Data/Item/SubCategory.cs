using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Domain
{
    public class SubCategory
    {
        public int Id { get; set; }
        public string SubCategoryName { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public string ImageData { get; set; }


        public SubCategory(string subCategoryName ,int categoryId ,string imageData)
        {
            SubCategoryName = subCategoryName;
            CategoryId = categoryId;
            ImageData = imageData;
        }
    }
}
