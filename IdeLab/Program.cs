using System;

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

            ide.Java = java;
            ide.CSharp = cs;
            ide.C = c;

            ide.Work();

        }
    }

    class IDE
    {
        public LangJava Java { get; set; }
        public LangCSharp CSharp { get; set; }
        public LangC C { get; set; }

        public void Work()
        {
            Console.WriteLine(Java.GetName());
            Console.WriteLine(Java.GetUnit());
            Console.WriteLine(Java.GetParadigm());

            Console.WriteLine("--------------");
            Console.WriteLine(CSharp.GetName());
            Console.WriteLine(CSharp.GetUnit());
            Console.WriteLine(CSharp.GetParadigm());

            Console.WriteLine("--------------");
            Console.WriteLine(C.GetName());
            Console.WriteLine(C.GetUnit());
            Console.WriteLine(C.GetParadigm());


        }

    }

    class LangJava
    {
        public string GetName() { return "Java Language"; }
        public string GetUnit() { return "Class"; }
        public string GetParadigm() { return "Object Oriented"; }
    }
    class LangCSharp
    {
        public string GetName() { return "CSharp Language"; }
        public string GetUnit() { return "Class"; }
        public string GetParadigm() { return "Object Oriented"; }
    }
    class LangC
    {
        public string GetName() { return "C Language"; }
        public string GetUnit() { return "Function"; }
        public string GetParadigm() { return "Procedural Oriented"; }
    }


}
