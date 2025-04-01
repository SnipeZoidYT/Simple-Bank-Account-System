using System;
using System.Data.SqlTypes;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Simple_Bank_Account_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // In this program you will be able to deposit, withdraw money to and from your account

            // Here we are declaring and initilizing the vairables 
            int choice;
            bool isValidChoice = false;
            string filePath = @"C:\Users\snipe\Downloads\account.txt";

            // This if function is checking if the user all ready has an account
            if (File.Exists(filePath))
            {
                Console.WriteLine("Nice! You already have an account.");

                string[] accountInfo = File.ReadAllLines(filePath);

                Console.WriteLine($"Name: {accountInfo[0]}");
                Console.WriteLine($"Age: {accountInfo[1]}\n");
                Console.WriteLine($"Money: £{accountInfo[3]}\n");

            }
            // If they do not then it asks them to make an account
            else
            {
                Console.WriteLine("Please create an account.");

                Console.Write("What is your name?: ");
                string name = Console.ReadLine();

                Console.Write("What is your age?: ");
                int age = int.Parse(Console.ReadLine());

                Console.Write("Enter a password: ");
                string password = Console.ReadLine();

                double money = 0;

                string accountDetails = $"{name}\n{age}\n{password}\n{money}";


                File.WriteAllText(filePath, accountDetails);
                Console.WriteLine("Account created successfully!");
            }


            // Here we are asking the user what functions they want to execute
            Console.WriteLine("Welcome to this simple banking app!");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. View Account");
            Console.WriteLine("4. Exit");
            Console.Write(": ");

            // This if statement reads the users input and if it is not a whole number it asks again
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Please enter a valid number.");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. View Account");
                Console.WriteLine("4. Exit");
                Console.Write(": ");
            }

            // This switch statement decides what function to execute depending on the users correct inputted number
            switch (choice)
            {
                case 1:
                    Console.WriteLine("You picked Deposit.");
                    Deposit(filePath);
                    isValidChoice = true;
                    break;
                case 2:
                    Console.WriteLine("You picked Withdraw.");
                    isValidChoice = true;
                    Withdraw(filePath);
                    break;
                case 3:
                    Console.WriteLine("You picked View account");
                    isValidChoice = true;
                    Account(filePath);
                    break;
                case 4:
                    Console.WriteLine("You picked to exit the program.");
                    Console.WriteLine("GoodBye.");
                    isValidChoice = true;
                    break;
                default:
                    Console.WriteLine("Please enter a correct number");
                    break;
            }


            while (!isValidChoice)
            {
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. View Account");
                Console.WriteLine("4. Exit");
                Console.Write(": ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("You picked Deposit.");
                        Deposit(filePath);
                        isValidChoice = true;
                        break;
                    case 2:
                        Console.WriteLine("You picked Withdraw.");
                        isValidChoice = true;
                        Withdraw(filePath);
                        break;
                    case 3:
                        Console.WriteLine("You picked View account");
                        isValidChoice = true;
                        Account(filePath);
                        break;
                    case 4:
                        Console.WriteLine("You picked to exit the program.");
                        Console.WriteLine("GoodBye.");
                        isValidChoice = true;
                        break;
                    default:
                        Console.WriteLine("Please enter a correct number");
                        break;
                }

            }

        }

        // This function will carry out depositing money into their account 
        static void Deposit(string filePath)
        {
            string[] accountInfo = File.ReadAllLines(filePath);
            double currentBalance = double.Parse(accountInfo[3]);

            Console.Write("Enter amount to deposit: ");
            if (double.TryParse(Console.ReadLine(), out double amount) && amount > 0)
            {
                currentBalance += amount;
                accountInfo[3] = currentBalance.ToString();
                File.WriteAllLines(filePath, accountInfo);
                Console.WriteLine($"Deposited {amount:C}. New balance: {currentBalance:C}");
            }
            else
            {
                Console.WriteLine("Invalid amount. Please enter a positive number.");
            }
        }

        // This function will carry out withdrawing money from their account
        static void Withdraw(string filePath)
        {
            string[] accountInfo = File.ReadAllLines(filePath);
            double currentBalance = double.Parse(accountInfo[3]);

            Console.Write("Enter an amount to withdraw: ");
            if (double.TryParse(Console.ReadLine(), out double amount) && amount > 0)
            {
                currentBalance -= amount;
                accountInfo[3] = currentBalance.ToString();
                File.WriteAllLines(filePath, accountInfo);
                Console.WriteLine($"Withdrew {amount:C}. New balance: {currentBalance:C}");
            }
            else
            {
                Console.WriteLine("Invalid amount please enter a positive number.");
            }



        }

        // This function will let the user view their bank account
        static void Account(string filePath)
        {
            string[] accountInfo = File.ReadAllLines(filePath);


            Console.WriteLine($"Welcome to the account page");
            Console.WriteLine($"---------------------------");
            Console.WriteLine($"|   Name: {accountInfo[0]}     |");
            Console.WriteLine($"|                         |");
            Console.WriteLine($"|   Age: {accountInfo[1]}               |");
            Console.WriteLine($"|                         |");
            Console.WriteLine($"|   Money: £{accountInfo[3]}           |");
            Console.WriteLine($"|                         |");
            Console.WriteLine($"|                         |");
            Console.WriteLine($"---------------------------");

        }


    }
}
