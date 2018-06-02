using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class BankAccountSample
    {
        public string name;
        int accountNum;
        public double balance = 0;
        double interest = 0;
        public BankAccountSample(string namae, double firstDep)
        {
            name = namae;
            balance += firstDep;
        }

        public void setIntRate(double per)
        {
            interest = per;
        }

        public double getBal()
        {
            return balance;
        }

        public string getName()
        {
            return this.name;
        }

        public void deposit(double addAmt)
        {
            balance += addAmt;
        }

        public bool withdraw(double outAmt)
        {
            bool chk = true;
            if (outAmt <= balance)
            {
                balance -= outAmt;
            }
            else if (outAmt > balance)
            {
                chk = false;
            }
            return chk;
        }

        public double getBalAfter(int mos)
        {
            double prin = balance;
            double intFeed;
            for (int g = 1; g <= mos; g++)
            {
                intFeed = prin * interest;
                prin += intFeed;
            }
            return prin;
        }
    }
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        List<BankAccount> bank = new List<BankAccount>();
    //        while (true)
    //        {
    //            Console.Write("1. Set up account\n2. Check balance\n3. Deposit\n4. Withdraw\n5. Set interest rate\n6. Check compounding interest over time\nX. Terminate\n\nSelect Function: ");
    //            string selGo = Console.ReadLine().ToUpper();
    //            Console.WriteLine("\n");
    //            if (selGo == "1")
    //            {
    //                Console.Write("Enter name: ");
    //                string name = Console.ReadLine();
    //                Console.Write("Enter initial balance: ");
    //                double init = double.Parse(Console.ReadLine());
    //                bank.Add(new BankAccount(name, init));
    //                Console.WriteLine("Bank Account Added!");
    //                Console.ReadLine();
    //            }
    //            else if (selGo == "2")
    //            {
    //                Console.Write("Enter name: ");
    //                string nmChk = Console.ReadLine();
    //                for (int ix = 0; ix < bank.Count; ix++)
    //                {
    //                    if (bank[ix].name == nmChk)
    //                    {
    //                        Console.WriteLine("Account Found!\nName: {0}\nBalance: {1}", bank[ix].name, bank[ix].balance);
    //                    }
    //                }
    //                Console.ReadLine();
    //            }
    //            else if (selGo == "3")
    //            {
    //                Console.Write("Enter name: ");
    //                string nmChk = Console.ReadLine(), nmNow = null;
    //                int accNum = -1;
    //                for (int ix = 0; ix < bank.Count; ix++)
    //                {
    //                    if (bank[ix].name == nmChk)
    //                    {
    //                        nmNow = nmChk;
    //                        accNum = ix;
    //                    }
    //                }
    //                if (accNum != -1)
    //                {
    //                    Console.Write("Amount to Deposit: ");
    //                    bank[accNum].deposit(double.Parse(Console.ReadLine()));
    //                    Console.WriteLine("Amount successfully deposited!");
    //                }
    //                else { Console.WriteLine("Account not found!"); }
    //                Console.ReadLine();
    //            }
    //            else if (selGo == "4")
    //            {
    //                Console.Write("Enter name: ");
    //                string nmChk = Console.ReadLine(), nmNow = null;
    //                int accNum = -1;
    //                for (int ix = 0; ix < bank.Count; ix++)
    //                {
    //                    if (bank[ix].name == nmChk)
    //                    {
    //                        nmNow = nmChk;
    //                        accNum = ix;
    //                    }
    //                }
    //                if (accNum != -1)
    //                {
    //                    Console.Write("Amount to Withdraw: ");
    //                    bool ok = bank[accNum].withdraw(double.Parse(Console.ReadLine()));
    //                    if (ok) 
    //                    {
    //                        Console.WriteLine("Amount successfully withdrawn!");
    //                        if (bank[accNum].balance == 0)
    //                        {
    //                            bank[accNum] = null;
    //                            Console.WriteLine("Account closed!");
    //                        }
    //                    }
    //                    else { Console.WriteLine("Insufficient funds!"); }
    //                }
    //                else { Console.WriteLine("Account not found!"); }
    //                Console.ReadLine();
    //            }
    //            else if (selGo == "5")
    //            {
    //                Console.Write("Enter name: ");
    //                string nmChk = Console.ReadLine(), nmNow = null;
    //                int accNum = -1;
    //                for (int ix = 0; ix < bank.Count; ix++)
    //                {
    //                    if (bank[ix].name == nmChk)
    //                    {
    //                        nmNow = nmChk;
    //                        accNum = ix;
    //                    }
    //                }
    //                if (accNum != -1)
    //                {
    //                    Console.Write("Set interest rate (in percent): ");
    //                    bank[accNum].setIntRate((0.01 * double.Parse(Console.ReadLine())));
    //                    Console.WriteLine("Interest rate set!");
    //                }
    //                else { Console.WriteLine("Account not found!"); }
    //                Console.ReadLine();
    //            }
    //            else if (selGo == "6")
    //            {
    //                Console.Write("Enter name: ");
    //                string nmChk = Console.ReadLine(), nmNow = null;
    //                int accNum = -1;
    //                for (int ix = 0; ix < bank.Count; ix++)
    //                {
    //                    if (bank[ix].name == nmChk)
    //                    {
    //                        nmNow = nmChk;
    //                        accNum = ix;
    //                    }
    //                }
    //                if (accNum != -1)
    //                {
    //                    Console.Write("Months of compunding interest: ");
    //                    int mos = int.Parse(Console.ReadLine());
    //                    Console.WriteLine("Balance after {0} months: {1}", mos, bank[accNum].getBalAfter(mos));
    //                }
    //                else { Console.WriteLine("Account not found!"); }
    //                Console.ReadLine();
    //            }
    //            else if (selGo == "X")
    //            {
    //                break;
    //            }
    //            else
    //            {
    //                Console.WriteLine("Invalid Syntax!");
    //                Console.ReadLine();
    //            }
    //            Console.Clear();
    //        }
    //    }
    //}