using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ProductInterface;

namespace ProductClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<IWCFProductService> channelFactory = new 
                ChannelFactory<IWCFProductService>("ProductServiceEndpoint");

            IWCFProductService proxy = channelFactory.CreateChannel();

            List<string> products = proxy.ListProducts();

            foreach (var p in products)
            {
                Console.WriteLine(p);
            }

            Console.ReadLine();
        }
    }
}
