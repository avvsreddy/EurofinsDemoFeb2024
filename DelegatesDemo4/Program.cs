using System;
using System.Net.Mail;

namespace DelegatesDemo4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // client dev 1
            Account account = new Account();

            account.Notify += Notification.SendMail;// subscribed for mail
            account.Notify += Notification.SendSMS; // sub for sms
            account.Notify -= Notification.SendMail; // unsub for mail

            account.Notify += Notification.SendWA;

            account.Deposit(1000);

            //account.Subscribe(Notification.SendSMS);
            //account.Subscribe(Notification.SendMail);


            // account.Notify("Deposited $9999999999999999.00");

            Console.WriteLine($"Balance : {account.Balance}");
            account.Withdraw(500);
            Console.WriteLine($"Balance : {account.Balance}");
        }
    }

    // Dev 1
    class Account // business class
    {
        public int Balance { get; set; }

        public event NotifyDelegate Notify = null; //new NotifyDelegate(Notification.SendMail);


        //public void Subscribe(NotifyDelegate notify)
        //{
        //    Notify += notify;
        //}

        //public void Unsubscribe(NotifyDelegate notify)
        //{
        //    Notify -= notify;
        //}

        public void Deposit(int amount)
        {
            Balance += amount;
            //Console.WriteLine("Deposited");
            // send email notification
            string msg = $"{amount} is deposited";
            //Notification.SendMail(msg);
            //Notification.SendSMS(msg);
            if (Notify != null)
                Notify(msg);


        }

        public void Withdraw(int amount)
        {
            Balance -= amount;
            //Console.WriteLine("Withdrawn");
            // send email notification
            string msg = $"{amount} is Withdrawn";
            //Notification.SendMail(msg);
            //Notification.SendSMS(msg);
            if (Notify != null)
                Notify(msg);

        }
    }

    // dev 1
    public delegate void NotifyDelegate(string str);


    // Dev 2
    class Notification
    {
        public static void SendMail(string msg)
        {
            SmtpClient client = new SmtpClient();
            //client.Port = 465;
            //client.Host = "smtp.gmail.com";
            //client.Credentials = null; // user id and password

            client.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
            client.PickupDirectoryLocation = "E:\\mails";

            MailMessage message = new MailMessage("manager@XYZBank.com", "customer@mail.com");
            //message.Bcc = "";
            //message.From = "";
            //message.To = "";
            message.Subject = msg;
            message.Body = msg;
            //message.Attachments.Add("");

            //client.Send(message);
            Console.WriteLine($"Email: {msg}");
        }

        public static void SendSMS(string msg)
        {
            Console.WriteLine($"SMS : {msg}");
        }

        public static void SendWA(string msg)
        {
            Console.WriteLine($"Whats App {msg}");
        }

    }
}



