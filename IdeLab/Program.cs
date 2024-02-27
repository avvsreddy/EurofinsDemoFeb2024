using System;
using System.Collections.Generic;

namespace IdeLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDE ide = new IDE();
            LangJava java = new LangJava();
            LangCSharp cs = new LangCSharp();
            LangC c = new LangC();
            Fortran f = new Fortran();

            ide.Languages.Add(java);
            ide.Languages.Add(cs);
            ide.Languages.Add(c);
            ide.Languages.Add(f);
            ide.Work();

        }
    }

    class IDE
    {
        //public LangJava Java { get; set; }
        //public LangCSharp CSharp { get; set; }
        //public LangC C { get; set; }

        // List<ILanguage> languages = new List<ILanguage>();
        public List<ILanguage> Languages { get; set; } = new List<ILanguage>();


        public void Work()
        {
            foreach (var l in Languages)
            {
                Console.WriteLine(l.GetName());
                Console.WriteLine(l.GetUnit());
                Console.WriteLine(l.GetParadigm());
                Console.WriteLine("----------------");
            }
            //Console.WriteLine("--------------");
            //Console.WriteLine(CSharp.GetName());
            //Console.WriteLine(CSharp.GetUnit());
            //Console.WriteLine(CSharp.GetParadigm());

            //Console.WriteLine("--------------");
            //Console.WriteLine(C.GetName());
            //Console.WriteLine(C.GetUnit());
            //Console.WriteLine(C.GetParadigm());


        }

    }


    interface ILanguage
    {

        string GetName();
        string GetUnit();
        string GetParadigm();
    }


    abstract class OOLanguage : ILanguage
    {
        abstract public string GetName();


        public string GetParadigm()
        {
            return "Object Oriented";
        }

        public string GetUnit()
        {
            return "Class";
        }
    }

    abstract class ProceduralLanguage : ILanguage
    {
        abstract public string GetName();


        public string GetParadigm()
        {
            return "Procedural Oriented";
        }

        public string GetUnit()
        {
            return "Function";
        }
    }

    class LangJava : OOLanguage //, ILanguage
    {
        public override string GetName() { return "Java Language"; }
        //public string GetUnit() { return "Class"; }
        //public string GetParadigm() { return "Object Oriented"; }
    }
    class LangCSharp : OOLanguage, ILanguage
    {
        public override string GetName() { return "CSharp Language"; }
        //public string GetUnit() { return "Class"; }
        //public string GetParadigm() { return "Object Oriented"; }
    }
    class LangC : ProceduralLanguage, ILanguage
    {
        public override string GetName() { return "C Language"; }
        //public string GetUnit() { return "Function"; }
        //public string GetParadigm() { return "Procedural Oriented"; }
    }

    class Fortran : ProceduralLanguage, ILanguage
    {
        public override string GetName() { return "Fortran Language"; }
        //public string GetUnit() { return "Function"; }
        //public string GetParadigm() { return "Procedural Oriented"; }
    }
}
