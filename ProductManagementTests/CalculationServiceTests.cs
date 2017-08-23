using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpectedObjects;
using FluentAssertions;

namespace ProductManagement.Tests
{
    [TestClass()]
    public class CalculationServiceTests
    {
        /// <summary>
        /// 3筆成一組，取得Cost的總和的話，預期結果是 6,15, 24, 21
        /// </summary>
        [TestMethod()]
        public void GetCostTotalTest()
        {
            //arrange
            Order order = new Order();
            CalculationService<Model> service = new CalculationService<Model>(order);

            //act
            List<int> actual = service.GetGroupTotal(3, "Cost");
            List<int> expected = new List<int> { 6, 15, 24, 21 };

            //assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        /// <summary>
        /// 4筆一組，取得 Revenue 總和的話，預期結果會是 50,66,60
        /// </summary>
        [TestMethod()]
        public void GetRevenueTotalTest()
        {
            //arrange
            Order order = new Order();
            CalculationService<Model> service = new CalculationService<Model>(order);

            //act
            List<int> actual = service.GetGroupTotal(2, "Revenue");
            List<int> expected = new List<int> { 50, 66, 60 };

            //assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        /// <summary>
        /// 尋找的欄位若不存在，預期會拋 ArgumentException
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(DivideByZeroException))]
        public void FieldNameIsNotExistTest()
        {
            //arrange
            Order order = new Order();
            CalculationService<Model> service = new CalculationService<Model>(order);
            Action act = () => service.GetGroupTotal(1, "test1");
            act.ShouldThrow<DivideByZeroException>();
        }

        /// <summary>
        /// 筆數輸入負數，預期會拋 ArgumentException
        /// </summary>
        [ExpectedException(typeof(DivideByZeroException))]
        [TestMethod()]
        public void NegativeNumberTest()
        {
            Order order = new Order();
            CalculationService<Model> service = new CalculationService<Model>(order);
            Action act = () => service.GetGroupTotal(-1, "Revenue");
            act.ShouldThrow<DivideByZeroException>();
        }

        /// <summary>
        /// 筆數若輸入為0, 則傳回0
        /// </summary>
        [TestMethod()]
        public void PenIsZeroReturnTrue()
        {
            Order order = new Order();
            CalculationService<Model> service = new CalculationService<Model>(order);
            var result = service.GetGroupTotal(0, "Revenue");
            Assert.AreEqual(result, new List<int>());
        }


        /// <summary>
        /// 產生11筆訂單資料
        /// </summary>
        public class Order : OrderDao<Model>
        {
            public override List<Model> GetAll()
            {
                List<Model> result = new List<Model>();
                Model model = null;

                model = new Model()
                {
                    Id = 1,
                    Cost = 1,
                    Revenue = 11,
                    SellPrice = 21
                };
                result.Add(model);

                model = new Model()
                {
                    Id = 2,
                    Cost = 2,
                    Revenue = 12,
                    SellPrice = 22
                };
                result.Add(model);

                model = new Model()
                {
                    Id = 3,
                    Cost = 3,
                    Revenue = 13,
                    SellPrice = 23
                };
                result.Add(model);

                model = new Model()
                {
                    Id = 4,
                    Cost = 4,
                    Revenue = 14,
                    SellPrice = 24
                };
                result.Add(model);

                model = new Model()
                {
                    Id = 5,
                    Cost = 5,
                    Revenue = 15,
                    SellPrice = 25
                };
                result.Add(model);

                model = new Model()
                {
                    Id = 6,
                    Cost = 16,
                    Revenue = 16,
                    SellPrice = 26
                };
                result.Add(model);

                model = new Model()
                {
                    Id = 7,
                    Cost = 7,
                    Revenue = 17,
                    SellPrice = 27
                };
                result.Add(model);

                model = new Model()
                {
                    Id = 8,
                    Cost = 8,
                    Revenue = 18,
                    SellPrice = 28
                };
                result.Add(model);

                model = new Model()
                {
                    Id = 9,
                    Cost = 9,
                    Revenue = 19,
                    SellPrice = 29
                };
                result.Add(model);

                model = new Model()
                {
                    Id = 10,
                    Cost = 10,
                    Revenue = 20,
                    SellPrice = 30
                };
                result.Add(model);

                model = new Model()
                {
                    Id = 11,
                    Cost = 11,
                    Revenue = 21,
                    SellPrice = 31
                };
                result.Add(model);

                return result;
            }
        }

    }
}