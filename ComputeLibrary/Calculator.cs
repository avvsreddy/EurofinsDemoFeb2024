namespace ComputeLibrary
{
    public class Calculator
    {
        public int FindMax(int fno, int sno) // SRP / BL
        {
            // find the max
            int max;
            if (fno > sno)
            {
                max = fno;
            }
            else
            {
                max = sno;
            }
            return max;
        }
    }
}
