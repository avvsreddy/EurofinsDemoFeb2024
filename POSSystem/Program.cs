using System;
using System.Configuration;

namespace POSSystem
{
    internal class Program // UI
    {
        static void Main(string[] args)
        {
            TaxCalculatorFactory factory = new TaxCalculatorFactory();
            BillingSystem billingSystem = new BillingSystem(factory.CreateTaxCalculator());
            billingSystem.GenerateBill();
        }
    }



    class TaxCalculatorFactory
    {
        public ITaxCalculator CreateTaxCalculator()
        {
            string className = ConfigurationManager.AppSettings["CALC"];
            // Reflextion
            Type theType = Type.GetType(className);
            return (ITaxCalculator)Activator.CreateInstance(theType);


            //new className();
        }
    }

    public class BillingSystem
    {
        private ITaxCalculator _taxCalculator;// = new KATaxCalculator();

        public BillingSystem(ITaxCalculator calculator)
        {
            this._taxCalculator = calculator;
        }

        public void GenerateBill()
        {
            // scan all the products and find the total
            double total = 5630.40;
            // calculate discounts
            // apply coupons
            // calculate tax
            double tax = _taxCalculator.CalculateTax(total);

            // generate the final bill

        }
    }


    public interface ITaxCalculator
    {
        double CalculateTax(double amt);
    }

    public class KATaxCalculator : ITaxCalculator
    {
        public double CalculateTax(double amt)
        {
            Console.WriteLine("Using KA Tax Calculator");
            double vat = 120;
            int cess = 60;
            int st = 30;
            int sbt = 100;
            int abc = 20;
            double tax = vat + cess + st + sbt + abc;
            return tax;
        }
    }

    public class TNTaxCalculator : ITaxCalculator
    {
        public double CalculateTax(double amt)
        {
            Console.WriteLine("Using TN Tax Calculator");
            double vat = 120;
            int cess = 60;
            int st = 30;
            int sbt = 100;
            int xyz = 20;
            double tax = vat + cess + st + sbt + xyz;
            return tax;
        }
    }
}
