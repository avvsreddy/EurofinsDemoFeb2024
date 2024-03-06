using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace SimpleCalculator.Business
{
    public class Calculator
    {

        // Dependency Injection
        IRepository repository = null;
        public Calculator()
        {
            repository = new FileRepository();
        }

        public Calculator(IRepository repo)
        {
            this.repository = repo;
        }

        public int Sum(int a, int b)
        {
            // only +ve numbers else return 0
            if (a < 0 || b < 0)
                return 0;

            // only even numbers else throw exp
            if (a % 2 != 0 || b % 2 != 0)
                throw new NonEvenNumbersException("Enter only even numbers");

            return a + b;
        }


        public List<int> FilterEvens(List<int> numbers)
        {
            // return evens list

            List<int> evens = new List<int>();

            // input is null
            if (numbers == null)
            {
                throw new InputEmptyException("Input array is  null");
            }

            if (numbers.Count == 0)
            {
                throw new InputEmptyException("Input array is empty");
            }

            //foreach (int n in numbers)
            //{
            //    if (n % 2 == 0)
            //        evens.Add(n);
            //}

            evens = GetEvens(numbers);

            // save the result into file
            //original
            //FileRepository repo = new FileRepository(); // wrong
            repository.Save(evens);
            // mock
            //MockRepo.Save(evens);

            return evens;

        }

        private List<int> GetEvens(List<int> numbers)
        {
            //List<int> evens = new List<int>();
            //foreach (int n in numbers)
            //{
            //    if (n % 2 == 0)
            //        evens.Add(n);
            //}

            //var evens = from e in numbers
            //            where e % 2 == 0
            //            select e;

            var evens = numbers.Where(n => n % 2 == 0).ToList();

            return evens;
        }
    }


    public interface IRepository
    {
        void Save(List<int> data);
    }

    public class FileRepository : IRepository
    {
        public void Save(List<int> data)
        {
            string numbers = data.ToString();
            File.WriteAllText("B:\\numberslist.txt", numbers);
        }
    }
}
