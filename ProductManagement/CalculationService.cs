using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement
{
    public class CalculationService<T>
    {
        private readonly OrderDao<T> _dao;

        public CalculationService(OrderDao<T> dao)
        {
            _dao = dao;
        }

        /// <summary>
        /// 取得Cost的總和
        /// </summary>
        /// <returns></returns>
        public List<int> GetGroupTotal(int pen, string fieldName)
        {
            if (pen < 0)
            {
                throw new ArgumentException();
            }
            return new List<int>();
        }

        public int GetGroupTotal(int pen)
        {
            int result = 1;
            if (pen == 0)
            {
                result = 0;
            }
            return result;
        }
    }

    public abstract class OrderDao<T>
    {
        public abstract List<T> GetAll();
    }
}
