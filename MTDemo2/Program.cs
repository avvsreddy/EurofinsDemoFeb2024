using System.Threading;
using System.Threading.Tasks;

namespace MTDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(M1);
            //Thread t2 = new Thread(M2);

            Task tt1 = new Task(M1);
            Task tt2 = new Task(() => { M2(100); });
            Task<int> tt3 = new Task<int>(M3);
            tt3.Start();

            int x = M3();

            int r = tt3.Result;

            Task<int> tt4 = new Task<int>(() => { return M4(100); });
            //
            //

            r = tt4.Result;
            //
        }

        static void M1() { }
        static void M2(int a) { }
        static int M3() { return 1; }
        static int M4(int i) { return 1; }



    }
}
