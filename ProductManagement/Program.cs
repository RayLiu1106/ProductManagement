using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement
{
    internal class Program
    {
        public static void GetCalculationService()
        {
            OrderDao<Model> dao = new Order();
            CalculationService<Model> service = new CalculationService<Model>(dao);
            service.GetGroupTotal(1, "Revenue");
        }

        public class Order : OrderDao<Model>
        {
            public override List<Model> GetAll()
            {
                throw new NotImplementedException();
            }
        }
    }
}
