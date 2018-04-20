using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace scharpCertification
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculateInterrest(12, 8, 5);
            Console.ReadKey();
        }
        public static decimal CalculateInterrest(decimal loanAmount, int loanTerm, decimal loanRate)
        {
            decimal interrestAmount = loanAmount * loanRate * loanRate;
//#if DEBUG
            Log("message", "details");
//#endif
            return interrestAmount;
        }
        [Conditional("DEBUG")]
        public static void Log(string message, string details)
        {
            Console.WriteLine("message : {0}, details : {1}", message, details);
        }
    }
}
