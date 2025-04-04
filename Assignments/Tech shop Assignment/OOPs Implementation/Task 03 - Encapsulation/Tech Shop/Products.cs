using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tech_Shop
{
    public class Products
    {
        // Attributes
        private int product_id { get; set; }
        public string product_name { get; set; }
        private string product_description { get; set; }
        private double product_price;
        //product price should not have -ve values..
        public double productprice
        {
            get { return product_price; }
            set
            {
                if (value < 0)
                {
                    throw new InvalidDataException("Warning! Negative value is not allowed");

                }
                else product_price = value;
            }
        }



        //parametrized constructor

        public Products(int product_id, string product_name, string product_description, double product_price)
        {
            this.product_id = product_id;
            this.product_name = product_name;
            this.product_description = product_description;
            this.product_price = product_price;
        }


        //Methods

        // To get product information
        public void GetProductDetails()
        {
            Console.WriteLine("-----------Product Details------------");
            Console.WriteLine($"Product Name :{product_name}");
            Console.WriteLine($"Description :{product_description}");
            Console.WriteLine($"Price :{product_price}");
            Console.WriteLine("--------------------------------------");

        }

        // To update product infor
        public void UpdateProductInfo(string? product_name = null, string? product_description = null, double? product_price = null)
        {
            if (!string.IsNullOrEmpty(product_name)) this.product_name = product_name;
            if (!string.IsNullOrEmpty(product_description)) this.product_description = product_description;
            if (product_price != null) this.product_price = Convert.ToDouble(product_price);

            Console.WriteLine("Product information updated successfully!");
        }

        //To check product is in stock or not
        public bool IsProductInStock(int StockQuantity)
        {
            return StockQuantity > 0;
        }

    }
}
