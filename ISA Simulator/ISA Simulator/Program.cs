using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISA_Simulator
{
    class Program
    {
        
        static void Main(string[] args)
        {
            FunctionCaller caller = new FunctionCaller();
            StreamReader sr;
            //Program program;
            //string line;
            string path;

            bool correctPath;
            do
            {
                correctPath = true;
                Console.WriteLine("Unesite putanju vaše skripte: ");
                path = Console.ReadLine();

                try
                {
                    sr = new StreamReader(path);
                }
                catch (Exception)
                {
                    correctPath = false;
                    Console.WriteLine("Nevalidna putanja.");
                }
            } while (correctPath!=true);

            
            var test = File.ReadAllLines(path);
            Console.WriteLine("==========START==========");
            for (int lineNum = 1; lineNum <= test.Length; lineNum++)
            {
                if (caller.CheckAndCallFunction(test[lineNum-1], ref lineNum, test.Length, test))
                {
                    Console.WriteLine("GRESKA! Linija " + lineNum);
                    break;
                } 
            }
            Console.WriteLine("===========END===========");
            Console.ReadKey();

            
        }
    }
}
