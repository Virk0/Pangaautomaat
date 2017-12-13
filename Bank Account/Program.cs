using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account
{
    class Program
    {
        static void Main(string[] args)
        {
            MM:
            string path = @"C:\Users\opilane\Documents\Visual Studio 2017\Projects\Bank Account\Bank Accounts\";
            Console.WriteLine("Please Enter your name");
            string name = Console.ReadLine();
            if (File.Exists(path + name + ".txt"))
            {
                Pincheck:
                Console.WriteLine("Enter your pin");
                string pin = Console.ReadLine();
                string[] lines = File.ReadAllLines(path + name + ".txt");
                if (pin == lines[0])
                {
                    WDD:
                    Console.WriteLine("Would you like to withdraw or deposit?");
                    string choise2 = Console.ReadLine();
                    if (choise2 == "deposit")
                    {
                        Console.WriteLine("How much would you like to deposit?");
                        int AmountD = Int32.Parse(Console.ReadLine());
                        int CurrentAmount = Int32.Parse(File.ReadLines(path + name + ".txt").Skip(1).Take(1).First());
                        int NewAmount = AmountD + CurrentAmount;
                        File.WriteAllText(path + name +".txt",pin + "\n" + NewAmount);
                        Console.WriteLine("Your new amount on account is " + NewAmount);
                        Console.ReadLine();

                    }
                    if (choise2 == "withdraw")
                    {
                        WD:
                        Console.WriteLine("How much would you like to withdraw?");
                        int AmountWD = Int32.Parse(Console.ReadLine());
                        int CurrentAmount = Int32.Parse(File.ReadLines(path + name + ".txt").Skip(1).Take(1).First());
                        if (AmountWD <= CurrentAmount)
                        {
                            int NewAmount = AmountWD - CurrentAmount;
                            File.WriteAllText(path + name + ".txt", pin + "\n" + NewAmount);
                            Console.WriteLine("Your new amount on account is " + NewAmount);
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("You dont have that much");
                            goto WD;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Wrong option");
                        Console.WriteLine("Options are:\nwithdraw \ndeposit");
                        goto WDD;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong pin");
                    goto Pincheck;
                }
            }
            else
            {
                Console.WriteLine("This account doesn't exist. Would you like to create an account?[Y/N][Type 'Q' to cancel action]");
                string choise1 = Console.ReadLine();
                if (choise1 == "Y")
                {
                    Console.WriteLine("Enter your name");
                    string NewName = Console.ReadLine();
                    Console.WriteLine("Enter your pin");
                    string NewPin = Console.ReadLine();
                    Console.WriteLine("How much would you like to deposit to your new account");
                    string NewAmount = Console.ReadLine();
                    using (StreamWriter sw = File.CreateText(path + NewName + ".txt"))
                    {
                        sw.WriteLine(NewPin);
                        sw.WriteLine(NewAmount);
                    }
                }
                if (choise1 == "N")
                {
                    Console.WriteLine("Returning to main menu");
                    goto MM;
                }
                if (choise1 == "Q")
                {
                    Environment.Exit(0);
                }
            }
        }

    }
}