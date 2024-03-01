namespace ExceptionsDemo2
{
    /// <summary>
    /// 
    /// </summary>
    public class Account
    {
        public int AccNo { get; set; }
        public int CurrentBalance { get; set; }
        public int MinimumBalance { get; set; }
        public int Pin { get; set; }
        public bool IsActive { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accNo"></param>
        /// <param name="amount"></param>
        /// <exception cref="InvalidAccountNumberException"></exception>
        public void Deposit(int accNo, int amount)
        {
            // valid accNo 

            if (this.AccNo != accNo)
            {
                throw new InvalidAccountNumberException("Account number not found");
            }


            // valid amount (amount > 0)
            // should be active acc
            // else should throw exp


        }

        public void Withdraw(int accNo, int amount, int pin)
        {
            // valid accno
            // valid amount (> 0)
            // sufficcient balance
            // must maintain min balance 5000-1000 <= 1000
            // must be active account
            // valid pin

            // else throw exp

        }

        public void Transfer(int fromAccNo, int toAccNo, int amount, int fromAccPin)
        {
            // all deposit business rules
            // all withdrawal business rules
            // else throw exp

        }

        public void Close(int accNo, int pin)
        {
            // valid accno
            // valid pin
            // balance must be zero
            // should be active account

        }

    }
}
