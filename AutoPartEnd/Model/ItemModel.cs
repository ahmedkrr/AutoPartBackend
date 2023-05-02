using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartEnd.Model
{
    public class ItemModel
    {
    }
    public class AddItems
    {
        public string MyProperty { get; set; }
        public string ItemName { get; set; }
        public string Discription { get; set; }
        public Double Price { get; set; }
        public int CarModelId { get; set; }
        public int CartTypeId { get; set; }
        public int YearId { get; set; }
        public int SubCategoryId { get; set; }

    }
    public class GetItemResponsee
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public double Price { get; set; }
        public DateTime CreatedTime { get; set; }
        public string CarName { get; set; }
        public string CarType { get; set; }
        public string CarYear { get; set; }
        public string UserName { get; set; }
        public string SubCatName { get; set; }
        public string CatName { get; set; }
    }
 
    public class UpdateItemsRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public Double Price { get; set; }
    }
    public class AddItemResponse
    {
        public bool success { get; set; }
        public string  message { get; set; }
    }
}
