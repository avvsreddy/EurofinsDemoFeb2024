using System;
using System.Configuration;

namespace POSSystem
{
    internal class Program // UI
    {
        static void Main(string[] args)
        {
            //TaxCalculatorFactory factory = new TaxCalculatorFactory();
            //TaxCalculatorFactory factory = TaxCalculatorFactory.GetInstance();
            TaxCalculatorFactory factory = TaxCalculatorFactory.Instance;
            Console.WriteLine($"Instance of factory in Main {factory.GetHashCode()}");
            BillingSystem billingSystem = new BillingSystem(factory.CreateTaxCalculator());
            //BillingSystem billingSystem = new BillingSystem(TaxCalculatorFactory.CreateTaxCalculator());
            billingSystem.GenerateBill();
            //POS();
        }

        // client 2
        public static void POS()
        {
            //TaxCalculatorFactory factory = new TaxCalculatorFactory();
            //TaxCalculatorFactory factory = TaxCalculatorFactory.GetInstance();
            TaxCalculatorFactory factory = TaxCalculatorFactory.Instance;
            Console.WriteLine($"Instance of factory in POS() {factory.GetHashCode()}");
            BillingSystem billingSystem = new BillingSystem(factory.CreateTaxCalculator());
            //BillingSystem billingSystem = new BillingSystem(TaxCalculatorFactory.CreateTaxCalculator());
            billingSystem.GenerateBill();
        }
    }



    class TaxCalculatorFactory // OCP  - Singleton
    {

        // 1. don't allow clients to create an instance - private/protected ctor

        protected TaxCalculatorFactory()
        {

        }

        // 2. internalize the object creation - self obj creation

        public static readonly TaxCalculatorFactory Instance = new TaxCalculatorFactory();

        //private static TaxCalculatorFactory instance = null;
        //private static object lockObj = new object();
        //public static TaxCalculatorFactory GetInstance()
        //{
        //    lock (lockObj)
        //    {
        //        lock (lockObj)
        //        {
        //            if (instance == null)
        //            {
        //                instance = new TaxCalculatorFactory();
        //            }
        //        }
        //    }
        //    return instance;
        //}

        public virtual ITaxCalculator CreateTaxCalculator()
        {
            string className = ConfigurationManager.AppSettings["CALC"];
            // Reflextion
            Type theType = Type.GetType(className);
            return (ITaxCalculator)Activator.CreateInstance(theType);


            //new className();
        }
    }

    class TaxCalcFactory2 : TaxCalculatorFactory
    {
        public override ITaxCalculator CreateTaxCalculator()
        {
            return base.CreateTaxCalculator();
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

    public class APTaxCalculator : ITaxCalculator
    {
        //sdfsdfsdf
        //sdfsdfsdf
        //sdfsdfsd
        public double CalculateTax(double amt)
        {
            Console.WriteLine("Using AP Tax Calculator");
            return 120.0;
        }
    }

    // vendor : US tax calculator (ustax.dll)

    public class USTaxCalculator
    {
        public float ComputeTax(float amt)
        {
            //sfsdfsd
            //sdfsdfd
            //sdfsdfd
            //sdfsdf
            return 120.0f;
        }
    }

    public class USTaxCalculatorAdaptor : ITaxCalculator
    {
        public double CalculateTax(double amt)
        {
            //fsdfsdfsdf
            //USTaxCalculator calc = new USTaxCalculator();
            //float tax = calc.ComputeTax((float) amt);
            //return tax;

            Console.WriteLine("Using US Tax Calculator");
            return new USTaxCalculator().ComputeTax((float)amt);

        }
    }
}
