using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Model
{
    public class CategoryModel
    {

    }
    public class AddCategories
    {
        public string CategoryName { get; set; }

    }
    public class AddSubCategories
    {
        public string SubCategoryName { get; set; }
    }

    public class SubCategoriesResponse
    {
        public int SubCategoryId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public string ImageData { get; set; }
        public string SubCategoryName { get; set; }
    }
    public class AddCategoryResponse
    {
        public bool success { get; set; }
        public string Categoryname { get; set; }
    }
    public class AddSubCategoryResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
    }
    public class DeleteCategoryResponse
    {
        public bool success { get; set; }
        public int CategoryId { get; set; }
        public string categoryName { get; set; }

    }
    public class DeleteSubCategoryResponse
    {
        public bool success { get; set; }
        public int CategoryId { get; set; }
        public string categoryName { get; set; }

    }
}
