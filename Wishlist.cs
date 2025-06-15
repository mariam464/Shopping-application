using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp
{
   public class Wishlist : Iproduct
    {
        public ProductList Products { get; set; }
        public List<Product1> WishlistItems { get; set; } = new List<Product1>();
        public Wishlist(ProductList products, List<Product1> wishlistItems)
        {
            Products = products;
            WishlistItems = wishlistItems;
        }
        public bool AddItem(int id)
        {
            bool found = false;
            foreach (Product1 item in Products)
            {
                if (item.Id == id)
                {
                    WishlistItems.Add(item);
                    Console.WriteLine("Product is added to wishlist");
                    found = true;
                    return true;
                    
                }

            }
            if(found == false)
            {
                Console.WriteLine("Product does not exist");
                return false;
            }
            else
            {
                return true;
            }
        }


        public void RemoveItem(int id)
        {
            foreach (var item in WishlistItems)
            {
                if (item.Id == id)
                {
                    WishlistItems.Remove(item);
                }
            }
        }
        public void DisplayWishlistItems()
        {
            if (WishlistItems.Count == 0)
            {
                Console.WriteLine("Your wishlist is empty.");

            }
            else
            {

                Console.WriteLine("Items in your wishlist:");
                foreach (Product1 product in WishlistItems)
                {
                    Console.WriteLine($"{product.Id}: {product.Name}-->{product.Price}$");
                }


            }
        }
        public void ClearWishlist()
        {
            WishlistItems.Clear();
            Console.WriteLine("Wishlist is cleared");
        }
       
    }
}
