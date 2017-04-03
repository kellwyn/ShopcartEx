using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingCart.Model;
using ShoppingCart.Service;

namespace ShoppingCart
{
    class Program
    {
        static void Main(string[] args)
        {
            var productService = new ProductService();
            var products = productService.InitialiseProduct();
            Console.WriteLine("List of all products in the system");

            foreach(var p in products)
            {
                Console.WriteLine("Product Number is : {0)", p.IdGuid);
                Console.WriteLine("Product Name is : {0}", p.Name);
                Console.WriteLine("Product Price is : {0}", p.Price);
                Console.WriteLine("------------------------");
            }

            //Shopping Cart

            var shoppingCart = new List<ShoppingCarts>();
            bool continueShopping = true;

            do
            {
                Console.WriteLine("Please enter the product number you want to purchase");
                //Convert product ID to integer
                var productID = Convert.ToInt32(Console.ReadLine());
                //check if productID is valid
                //Use foreach to go through all product list
                foreach (var pr in products)
                {
                    //if product is same as in foreach
                    if(pr.IdGuid == productID)
                    {
                        // Get specified object by Get Type
                        var productType = pr.GetType();

                        //Use switch case to display products requested by user

                    switch (productType.Name)
                        {
                            case "Lawnmower":
                                {
                                    var lawMower = (Lawmower)pr;
                                    Console.WriteLine("Product number: {0}", lawMower.IdGuid);
                                    Console.WriteLine("Product name: {0}", lawMower.Name);
                                    Console.WriteLine("Product price: {0}", lawMower.Price);
                                    Console.WriteLine("Product brand: {0}", lawMower.Brand);
                                    Console.WriteLine("Product fuel efficiency: {0}", lawMower.FuelEfficiency);
                                    Console.WriteLine("----------------------");
                                    break;
                                }
                            case "Computer":
                                {
                                    var lawMower = (Computer)pr;
                                    Console.WriteLine("Product number: {0}", lawMower.IdGuid);
                                    Console.WriteLine("Product name: {0}", lawMower.Name);
                                    Console.WriteLine("Product price: {0}", lawMower.Price);
                                    Console.WriteLine("Product memory: {0}", lawMower.Memory);
                                    Console.WriteLine("Product hard drive: {0}", lawMower.HardDrive);
                                    Console.WriteLine("----------------------");
                                    break;
                                }

                            case "Car":
                                {
                                    var lawMower = (Car)pr;
                                    Console.WriteLine("Product number: {0}", lawMower.IdGuid);
                                    Console.WriteLine("Product name: {0}", lawMower.Name);
                                    Console.WriteLine("Product price: {0}", lawMower.Price);
                                    Console.WriteLine("Product color: {0}", lawMower.Color);
                                    Console.WriteLine("Product type: {0}", lawMower.Type);
                                    Console.WriteLine("Product brand: {0}", lawMower.Brand);
                                    Console.WriteLine("Product fuel efficiency: {0}", lawMower.FuelEfficiency);
                                    Console.WriteLine("----------------------");
                                    break;
                                }

                            case "Furniture":
                                {
                                    var lawMower = (Furniture)pr;
                                    Console.WriteLine("Product number: {0}", lawMower.IdGuid);
                                    Console.WriteLine("Product name: {0}", lawMower.Name);
                                    Console.WriteLine("Product price: {0}", lawMower.Price);
                                    Console.WriteLine("Product make: {0}", lawMower.Make);
                                    Console.WriteLine("Product color: {0}", lawMower.Color);
                                    Console.WriteLine("----------------------");
                                    break;
                                }

                            case "SportsEquipment":
                                {
                                    var lawMower = (SportsEquipment)pr;
                                    Console.WriteLine("Product number: {0}", lawMower.IdGuid);
                                    Console.WriteLine("Product name: {0}", lawMower.Name);
                                    Console.WriteLine("Product price: {0}", lawMower.Price);
                                    Console.WriteLine("Product sport: {0}", lawMower.Sport);
                                    Console.WriteLine("----------------------");
                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        
                        }

                        //Allow additional quantity
                        Console.WriteLine("Quantity?");
                        int quantity = Convert.ToInt32(Console.ReadLine());


                        //Create new object shopping cart and store value of chosen product - initializer 
                        var chosenProduct = new ShoppingCarts
                        {
                            IdGuid = pr.IdGuid,
                            Name = pr.Name,
                            Price = pr.Price,
                            Quantity = quantity
                        };


                        //Add product chosen to shopping cart 
                        shoppingCart.Add(chosenProduct);

                        Console.WriteLine("you have {0} products in your cart", shoppingCart.Count());
                        Console.WriteLine("Press Y to continue shopping or enter to proceed to checkout");
                        string input = Console.ReadLine();

                        if (input == "Y" || input == "y")
                        {
                            break;
                        }
                        else
                        {
                            /*Console.WriteLine("Total to pay: ${0}", pr.Price);
                            Console.WriteLine("Thank you for shopping with us. Bye bye");
                            Console.ReadKey();*/

                            DisplayReceipt(shoppingCart);
                            DisplayTotalToPay(shoppingCart);
                            Console.WriteLine("Thank You for shopping with us");
                            continueShopping = false;

                        }

                    }
                }

            } while (continueShopping);

        }

        public static void DisplayTotalToPay(List<ShoppingCarts> customerShoppingCart)
        {
            decimal totalToPay = 0;
            foreach (var shoppingCart in customerShoppingCart)
            {
                totalToPay += (shoppingCart.Price * shoppingCart.Quantity);
            }

            Console.WriteLine("Total to pay : {0}", totalToPay);

        }

        public static void DisplayReceipt(List<ShoppingCarts> customerShoppingCart)
        {
            foreach (var shoppingCart in customerShoppingCart)
            {
                Console.WriteLine("---------------------");
                Console.WriteLine("Product number : {0}", shoppingCart.IdGuid);
                Console.WriteLine("Name: {0} x {1}", shoppingCart.Name, shoppingCart.Quantity);
                Console.WriteLine("Price: ${0} x {1} = ${2}", shoppingCart.Price, shoppingCart.Quantity, shoppingCart.Price * shoppingCart.Quantity);
                Console.WriteLine("---------------------");
            }
        }
    }
}