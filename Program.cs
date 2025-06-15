using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> actions = new Stack<int>();
            Stack<int> actionsNum = new Stack<int>();
            ProductList products = new ProductList(new List<Product1>());
            List<Product1> wishlistItems = new List<Product1>();
            Wishlist wishlist = new Wishlist(products, wishlistItems);
            List<Product1> productsList = new List<Product1>();
            List<Product1> cartItems = new List<Product1>();
            Cart cart = new Cart(products, cartItems);
            //Initailizing products in the store
            products.GetProducts().Add(new Product1(id: 1, name: "Product1", price: 200));
            products.GetProducts().Add(new Product1(id: 2, name: "Product2", price: 400));
            products.GetProducts().Add(new Product1(id: 3, name: "Product3", price: 300));
            products.GetProducts().Add(new Product1(id: 4, name: "Product4", price: 200));
            products.GetProducts().Add(new Product1(id: 5, name: "Product5", price: 240));
            products.GetProducts().Add(new Product1(id: 6, name: "Product6", price: 20));
            products.GetProducts().Add(new Product1(id: 7, name: "Product7", price: 200));
            products.GetProducts().Add(new Product1(id: 8, name: "Product8", price: 200));
            products.GetProducts().Add(new Product1(id: 9, name: "Product9", price: 2290));
            products.GetProducts().Add(new Product1(id: 10, name: "Product10", price: 10));
            products.GetProducts().Add(new Product1(id: 11, name: "Product11", price: 10));
            products.GetProducts().Add(new Product1(id: 12, name: "Product12", price: 200));
            products.GetProducts().Add(new Product1(id: 13, name: "Product13", price: 200));
            products.GetProducts().Add(new Product1(id: 14, name: "Product14", price: 1000));
            products.GetProducts().Add(new Product1(id: 15, name: "Product15", price: 200));
            products.GetProducts().Add(new Product1(id: 16, name: "Product16", price: 200));
            Console.WriteLine("Shopping Hub");
            Console.WriteLine();
            Console.WriteLine("Products available in the store: ");
            foreach (Product1 product in products)
            {
                Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}");
            }

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine("1.Add item to cart");
                Console.WriteLine("2.View cart");
                Console.WriteLine("3.Remove item from cart");
                Console.WriteLine("4.Add item to wishlist");
                Console.WriteLine("5.View wishlist");
                Console.WriteLine("6.Remove item from wishlist");
                Console.WriteLine("7.Checkout");
                Console.WriteLine("8.Undo last action");
                Console.WriteLine("9.Exit");
                Console.Write("Enter your choice: ");
                bool flag = int.TryParse(Console.ReadLine(), out int choice);
                while (flag == true)
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter the product ID to add to cart: ");
                            bool flag1 = int.TryParse(Console.ReadLine(), out int addId);

                            if (flag1 == false)
                            {
                                Console.WriteLine("Please enter a valid product ID.");

                            }
                            else
                            {


                                if (cart.AddItem(addId))
                                {
                                    actions.Push(addId);
                                    actionsNum.Push(1);
                                }
                                flag = false;
                            }
                            break;
                        case 2:
                            cart.DisplayCartItems();
                            flag = false;
                            break;
                        case 3:
                            //removing item from cart if it exists (get the id)
                            Console.Write("Enter the product ID to remove from cart: ");

                            bool flag5 = int.TryParse(Console.ReadLine(), out int removeId);
                            if (flag5 == true)
                            {
                                bool found = false;
                                foreach (Product1 product in cartItems)
                                {
                                    if (product.Id == removeId)
                                    {
                                        cartItems.Remove(product);
                                        Console.WriteLine("Item removed from cart.");
                                        actions.Push(removeId);
                                        actionsNum.Push(3);
                                        found = true;
                                        break;
                                    }
                                }
                                if (!found)
                                {
                                    Console.WriteLine("Product not found in cart.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Please enter a valid product ID.");

                            }
                            flag = false;
                            actions.Push(removeId);
                            break;
                        case 4:
                            //adding item to wishlist if it exists (get the id)
                            Console.Write("Enter the product ID to add to wishlist: ");
                            bool flag2 = int.TryParse(Console.ReadLine(), out int addIdToWishlist);

                            if (flag2 == false)
                            {
                                Console.WriteLine("Please enter a valid product ID.");

                            }
                            else
                            {
                                wishlist.AddItem(addIdToWishlist);
                                Console.WriteLine("Item added to wishlist.");
                                actions.Push(addIdToWishlist);
                                actionsNum.Push(4);
                                flag = false;
                            }
                            break;
                        case 5:
                            //viewing wishlist items
                            wishlist.DisplayWishlistItems();
                            if (wishlistItems.Count != 0)
                            {
                                bool exit2 = false;
                                while (!exit2)
                                {
                                    Console.WriteLine("Do you want to move items to cart?(yes or no)");
                                    string answer = Console.ReadLine().ToLower();
                                    if (answer == "yes")
                                    {
                                        Console.Write("Enter the product ID to move to cart: ");
                                        bool flag3 = int.TryParse(Console.ReadLine(), out int moveIdToCart);
                                        if (flag3 == true)
                                        {
                                            bool found = false;
                                            foreach (Product1 product in wishlistItems)
                                            {
                                                if (product.Id == moveIdToCart)
                                                {
                                                    cartItems.Add(product);
                                                    wishlistItems.Remove(product);
                                                    Console.WriteLine("Item moved to cart.");
                                                    actions.Push(moveIdToCart);
                                                    actionsNum.Push(5);
                                                    found = true;
                                                    exit2 = true;
                                                    break;
                                                }
                                            }
                                            if (!found)
                                            {
                                                Console.WriteLine("Product not found in wishlist.");
                                                exit2 = true;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Please enter a valid product ID.");
                                        }
                                    }
                                    else if (answer == "no")
                                    {
                                        Console.WriteLine("You can continue shopping.");
                                        exit2 = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Please enter a valid answer.");
                                    }
                                }
                            }

                            flag = false;
                            break;
                        case 6:
                            //removing item from wishlist if it exists (get the id)
                            if (wishlistItems.Count == 0)
                            {
                                Console.WriteLine("Your wishlist is empty.");
                                flag = false;
                                break;
                            }
                            else
                            {
                                Console.Write("Enter the product ID to remove from cart: ");

                                bool flag6 = int.TryParse(Console.ReadLine(), out int removeIdFromWishlist);
                                if (flag6 == true)
                                {
                                    bool found = false;
                                    foreach (Product1 product in cartItems)
                                    {
                                        if (product.Id == removeIdFromWishlist)
                                        {
                                            cartItems.Remove(product);
                                            Console.WriteLine("Item removed from cart.");
                                            actions.Push(removeIdFromWishlist);
                                            actionsNum.Push(6);
                                            found = true;
                                            break;
                                        }
                                    }
                                    if (!found)
                                    {
                                        Console.WriteLine("Product not found in cart.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Please enter a valid product ID.");

                                }

                                flag = false;

                            }
                            break;
                        case 7:
                            //Very simple checkout process, we will calculate the total price and tax(the tax could be the delivery fees) and ask if user wants to complete the process
                            cart.Checkout();
                            actionsNum.Push(7);
                            flag = false;
                            break;
                        case 8:
                            //(undoing last action)if last action was to add something then we will remove it and vice verca, purshasing orders can't be undone

                            if (actionsNum.Peek() == 1)
                            {
                                choice = 3;
                                removeId = actions.Pop();
                                foreach (Product1 product in cartItems)
                                {
                                    if (product.Id == removeId)
                                    {
                                        cartItems.Remove(product);
                                        Console.WriteLine("Item removed from cart.");
                                        actionsNum.Push(3);
                                        break;
                                    }
                                }

                            }
                            else if (actionsNum.Peek() == 3)
                            {
                                choice = 1;
                                addId = actions.Pop();
                                foreach (Product1 product in products)
                                {
                                    if (product.Id == addId)
                                    {
                                        cartItems.Add(product);
                                        Console.WriteLine("Item added to cart.");
                                        actionsNum.Push(1);
                                        break;
                                    }
                                }
                            }
                            else if (actionsNum.Peek() == 4)
                            {
                                choice = 6;
                                addId = actions.Pop();
                                foreach (Product1 product in products)
                                {
                                    if (product.Id == addId)
                                    {
                                        wishlistItems.Remove(product);
                                        Console.WriteLine("Item removed from wishlist");
                                        actions.Push(addId);
                                        actionsNum.Push(6);
                                        break;
                                    }
                                }
                            }
                            else if (actionsNum.Peek() == 6)
                            {
                                choice = 4;
                                addId = actions.Pop();
                                foreach (Product1 product in products)
                                {
                                    if (product.Id == addId)
                                    {
                                        wishlistItems.Add(product);
                                        Console.WriteLine("Item added to wishlist");
                                        actions.Push(addId);
                                        actionsNum.Push(4);
                                        break;
                                    }
                                }
                            }
                            else if (actionsNum.Peek() == 7)
                            {
                                Console.WriteLine("You can't undo purshased orders");
                            }
                            flag = false;
                            break;
                        case 9:
                            Console.WriteLine("Thank you for shopping with us! Goodbye!");
                            flag = false;
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
            }
        }
    }
}
