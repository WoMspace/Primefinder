using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace primefinder
{
    class Program
    {
        static void Main(string[] args)
        {
            primeLoop();
        }
        static List<ulong> primes = new List<ulong> //the list of found prime numbers.
        {
            3,
            5
        };
        static bool checkNumber(ulong numberToCheck) //checks the number against the list of existing primes.
        {
            ulong root = (ulong)Math.Ceiling(Math.Sqrt(numberToCheck)); //maybe check to see if it's worth checking if the root is whole
            bool isPrime = true;
            for(ulong i = 0; primes[(int)i] <= root; i++)
            {
                if(numberToCheck%primes[(int)i] == 0) //ignore the cast of a ulong to an int...
                {
                    return false; //if the number is found to not be a prime, return false.
                }
            }
            if (isPrime) //if we've got to the end of the loop and the number is still marked as prime, it is a prime. Return true.
            {
                return true;
            }
            else //visual studio complains that there are paths without a return... there aren't but this stops it complaining.
            {
                return false;
            }
        }
        static void primeLoop() //the loop that decides what to check as a prime number
        {
            Stopwatch millionCounter = new Stopwatch();
            millionCounter.Restart();
            Stopwatch tenThousandCounter = new Stopwatch();
            tenThousandCounter.Restart();
            bool quit = false;
            ulong numberToCheck = 7;
            while(!quit)
            {
                bool isPrime = checkNumber(numberToCheck);
                if(isPrime)
                {
                    primes.Add(numberToCheck);
                    if ((primes.Count + 1) % 1000000 == 0) //every millionth prime it says how ulong it's been since the last million.
                    {
                        Console.WriteLine("The {0} millionth prime was {1}. That took {2} seconds.\nPrimeN|Prime Number|Time(ms)", (primes.Count / 1000000) + 1, numberToCheck, millionCounter.Elapsed.Seconds);
                        millionCounter.Restart();
                    }
                    if ((primes.Count + 1) % 10000 == 0) //every 10,000th prime it says how many ms elapsed.
                    {
                        Console.WriteLine("{0:000000}|{1:000000000000}|{2}ms", (primes.Count / 10000) + 1, numberToCheck, (ulong)tenThousandCounter.ElapsedMilliseconds);
                        tenThousandCounter.Restart();
                    }
                }
                numberToCheck+= 2;
            }
        }
    }
}