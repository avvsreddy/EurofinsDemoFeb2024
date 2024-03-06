using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace SimpleCalculator.Business.UnitTest
{
    [TestClass]
    public class CalculatorUnitTest
    {
        Calculator target = null;
        [TestInitialize]
        public void Init()
        {
            // before every test case
            target = new Calculator();
        }


        [TestCleanup]
        public void Cleanup()
        {
            // after every test case
            target = null;
        }


        [TestMethod]
        public void SumTest_WithValidInput_ShouldGiveCorrectOutput()
        {

            // unit test code

            // do not write condition statements
            // do not use looping statements
            // do not use try...catch blocks


            // plain simple code 

            // unit testing approach

            // AAA
            // A - Arrange

            //Calculator target = new Calculator();
            int fno = 10;
            int sno = 10;
            int expected = 20;

            // A - Act

            int actual = target.Sum(fno, sno);
            // A - Assert

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void SumTest_WithNegativeInput_ShouldReturnZero()
        {
            //A
            //Calculator target = new Calculator();
            int actual = target.Sum(-1, -1);
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(NonEvenNumbersException))]
        public void SumTest_WithNonEvenNumbers_ThrowsExp()
        {
            //Calculator target = new Calculator();
            int actual = target.Sum(2, 1);

        }

        [TestMethod]
        public void EvensFilter_WithValidInput_ShouldReturnsEvensList()
        {
            Mock<IRepository> mock = new Mock<IRepository>();
            List<int> numbers = new List<int>() { 2, 4, 6, 8 };
            mock.Setup(m => m.Save(numbers));


            Calculator target = new Calculator(mock.Object);
            List<int> input = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<int> expected = new List<int> { 2, 4, 6, 8 };
            List<int> actual = target.FilterEvens(input);
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EvensFiter_WithValidInput_ShouldCallSave()
        {
            Mock<IRepository> mock = new Mock<IRepository>();
            List<int> numbers = new List<int>() { 2, 4, 6, 8 };
            mock.Setup(m => m.Save(numbers));


            Calculator target = new Calculator(mock.Object);
            List<int> input = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<int> expected = new List<int> { 2, 4, 6, 8 };
            List<int> actual = target.FilterEvens(input);
            //CollectionAssert.AreEqual(expected, actual);
            mock.Verify(m => m.Save(numbers), Times.AtLeastOnce);
        }




        [TestMethod]
        [ExpectedException(typeof(InputEmptyException))]
        public void EvensFilter_WithNullInput_ThrowsExp()
        {
            //Calculator target = new Calculator();
            target.FilterEvens(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InputEmptyException))]
        public void EvensFilter_WithEmptyInput_ThrowsExp()
        {
            //Calculator target = new Calculator();
            target.FilterEvens(new List<int>());
        }


    }


    //class MockRepo : IRepository
    //{
    //    public void Save(List<int> data)
    //    {
    //        //
    //    }

    //}
}
