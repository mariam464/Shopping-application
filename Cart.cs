using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp
{
    public class Cart : Iproduct
    {
        public ProductList Products { get; set; }
        public List<Product1> CartItems { get; set; } = new List<Product1>();
        public Cart(ProductList products, List<Product1> cartItems)
        {
            Products = products;
            CartItems = cartItems;
        }

        public bool AddItem(int id)
        {
            bool found = false;
            foreach (Product1 item in Products)
            {  
                if (item.Id == id)
                {
                    CartItems.Add(item);
                    Console.WriteLine("Product is added to cart");
                    found = true;
                    return true;
                }
                
            }
            if (found == false)
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
            foreach (var item in CartItems)
            {
                if (item.Id == id)
                {
                    CartItems.Remove(item);
                }
            }
        }
        public void ClearCart()
        {
            CartItems.Clear();
            Console.WriteLine("Cart is cleared");
        }
        public void DisplayCartItems()
        {
            if (CartItems.Count == 0)
            {
                Console.WriteLine("Your cart is empty.");

            }
            else
            {

                Console.WriteLine("Items in your cart:");
                foreach (Product1 product in CartItems)
                {
                    Console.WriteLine($"{product.Id}: {product.Name}-->{product.Price}$");
                }

            }
        }
        public decimal CalclateTotalPrice(decimal total)
        {
            decimal totalPrice = 0;
            decimal tax = 0.02M;
            foreach (Product1 item in CartItems)
            {
                totalPrice = totalPrice + item.Price;
            }
            tax *= totalPrice;
            total = totalPrice + tax;
            Console.WriteLine($"Total price is: {totalPrice}");
            Console.WriteLine($"Delivery fees is: {tax}");
            Console.WriteLine($"Total: {total}");
            return total;
        }
        public void Purchase(string answer)
        {
            bool exit = false;
            answer = answer.ToLower();
            while (!exit)
            {
                if (answer == "yes")
                {
                    Console.WriteLine("What is the payment method?(Enter command number)");
                    Console.WriteLine("1.Cash on delivery");
                    Console.WriteLine("2.Debate card or master card");

                    if (int.TryParse(Console.ReadLine(), out int paymentMethod) == true)
                    {
                        if (paymentMethod == 1 || paymentMethod == 2)
                        {
                            Console.WriteLine("Order is successfully done and you will recieve it two days after order placement. Track your order on our website");
                            Console.WriteLine("Continue shopping");
                            CartItems.Clear();   
                            exit = true;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid command");
                        }
                    }
                   
                    
                } else if (answer == "no")
                {
                    Console.WriteLine("Order is cancelled. You can continue shopping");
                    exit = true;
                    break;
                }
               
                else
                {
                    Console.WriteLine("Please enter a valid command");
                    Purchase(Console.ReadLine());
                }
            }
          
        }
       
        public void Checkout()
        {
            decimal total = 0;
            
            if (CalclateTotalPrice(total) == 0)
            {
                Console.WriteLine("Your cart is empty. Please add items to your cart before checking out.");
            }
            else
            {
                Console.WriteLine("Do you want to complete the order? (yes/no)");
                Purchase(Console.ReadLine());
            }
        }
    }

}


