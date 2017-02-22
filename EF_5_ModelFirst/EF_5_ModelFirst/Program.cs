using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace EF_5_ModelFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AccountingSystemContainer())
            {
                var invHeader = db.InvoiceHeaders.Create();
                var invDetail = db.InvoiceDetails.Create();

                invHeader.Total = 250m;

                invDetail.Description = "New Descritpion";
                invDetail.Price = 95m;
                invDetail.Quantity = 3;

                invHeader.InvoiceDetails.Add(invDetail);

                db.InvoiceHeaders.Add(invHeader);
                db.SaveChanges();
                
            }

            using (var dbread = new AccountingSystemContainer())
            {

                var iheader = new InvoiceHeader();

                var results = from i in dbread.InvoiceDetails
                              where i.InvoiceDetail_Id == 1
                              select i;

                foreach (var item in results.ToList())
                {
                    Console.WriteLine(" ID: \t\t {0} \n Description: \t {1} \n Price: \t {2} \n Quantity: \t {3} \n \n",item.InvoiceDetail_Id,item.Description,item.Price,item.Quantity) ;
                }

                Console.WriteLine( iheader.Total+ " " + iheader.InvoiceHeader_Id);
                Console.WriteLine();
                Console.WriteLine();
                Console.Read();

            }
            Console.Read();
        }
    }
}
