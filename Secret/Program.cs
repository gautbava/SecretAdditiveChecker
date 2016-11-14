using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * Programming exercise for the following task.
 * 
 * You are given a function 'secret()' that accepts a single integer parameter and returns an integer.
 *  In your favorite programming language, write a command-line program that takes one command-line argument (a number) 
 *  and determines if the secret() function is additive [secret(x+y) = secret(x) + secret(y)], 
 *  for all combinations x and y, where x and y are all prime numbers less than the number passed 
 *  via the command-line argument.  Describe how to run your examples. 
 *  Please generate the list of primes without using built-in functionality.
 *
 * Execute this by running:
 * Please follow console intructions. 
 * 
 * 
 */
namespace Additive
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNumber;
            Console.WriteLine("Press enter an integer value.");


            if (!int.TryParse(Console.ReadLine(), out inputNumber))
            {
                Console.WriteLine("Input must be an integer.");
                Console.WriteLine("Press enter to close this window");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Secret function is {0} additive.", new AdditiveChecker().Check(inputNumber) ? "" : "not ");
            Console.WriteLine("Press enter to close this window");
            Console.ReadLine();
        }
    }



    public class AdditiveChecker
    {
        public bool Check(int num)
        {
            var tool = new PrimeTool();
            IList<int> primes = tool.GetPrimes(num);
            for (int i = 0; i < primes.Count; i++)
            {
                foreach (int prime in primes.Skip(i))
                {
                    if (!IsAdditive(primes[i], prime)) return false;
                }
            }
            return true;
        }

        private static bool IsAdditive(int x, int y)
        {
            return Secret(x + y) == Secret(x) + Secret(y);
        }

        private static int Secret(int num)
        {
            return num;
        }
    }

    public class PrimeTool
    {
        public IList<int> GetPrimes(int limit) // Returns collection of prime numbers up to limit
        {
            var primes = new List<int>();
            for (int i = 0; i <= limit; i++)
            {
                if (IsPrime(i)) primes.Add(i);
            }
            return primes;
        }

        private static bool IsPrime(int num)
        {
            if (num == 2) return true;
            if (num <= 1 || num % 2 == 0) return false;

            for (int i = 3; i <= Math.Sqrt(num); i += 2)
            {
                if (num % i == 0) return false;
            }
            return true;
        }
    }



}
