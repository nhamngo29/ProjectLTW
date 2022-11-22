using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    
    public class ShoppingCart
    {
        public List<ShoppingCartItem> items { get; set; }
        public ShoppingCart()
        {
            this.items = new List<ShoppingCartItem>();
        }
        public void AddToCart(ShoppingCartItem item,int Quantity)
        {
            var checkExits = items.FirstOrDefault(x => x.ProductId == item.ProductId);
            if (checkExits != null)
            {
                checkExits.Quantity += Quantity;
                checkExits.TotalPrice = checkExits.Price * checkExits.Quantity;
            }    
            else
            {
                items.Add(item);
            }    
        }
        public bool remove(string id)
        {
            var checkExits=items.SingleOrDefault(x => x.ProductId == id);
            if (checkExits!=null)
            {
                items.Remove(checkExits);
                return true;
            }
            return false;
        }
        public void UpdateQuantity(string id,int quantity)
        {
            var checkExits=items.SingleOrDefault(x=>x.ProductId == id);
            if (checkExits!=null)
            {
                checkExits.Quantity = quantity;
                checkExits.TotalPrice = checkExits.Quantity * checkExits.Price;
            }
        }   
        public double GetTotalPrice()
        {
            return items.Sum(x => x.TotalPrice);
        }
        public double GetTotalQuantity()
        {
            return items.Sum(x => x.TotalPrice);
        }
        public void Clear()
        {
            items.Clear();
        }
    }
    public class ShoppingCartItem
    {
        public string ProductId { get; set; }//Mã sản phẩm

        public string Name { get; set; }//Tên sản phẩm

        public double Price { get; set; }//Giá sản phẩm

        
        public double TotalPrice { get; set; }
        public int Quantity { get; set; }
        public string img { get; set; }
    }
}