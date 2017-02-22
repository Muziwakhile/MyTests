using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ProductInterface;
using System.Data.Entity.Core;

namespace ProductService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WCFProductService" in both code and config file together.
    public class WCFProductService : IWCFProductService
    {
       

        public List<string> ListProducts()
        {
            Console.WriteLine("ListPtoducts has been called by a client");
            List<string> productsList = new List<string>();

            try
            {
                using (AdventureWorks database = new AdventureWorks())
                {
                    var products = from p in database.Products
                                   select p.ProductNumber;
                    productsList = products.ToList<string>();

                }
            }
            
            catch (EntityException ex)
            {

                Console.WriteLine(ex.Message);
            }
            return productsList;
        }
    }
}
