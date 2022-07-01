using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GAZ.CSCourse2022.FirstAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            // Buffer to hold a line as it is read in
            string line;
            // Loop until no more input (Ctrl-Z in a console, or end-of-file)
            while ((line = Console.ReadLine()) != null)
            {
                // Format the data
                line = line.Replace(",", " y:");
                line = "x:" + line;
                // Write the results out to the console window
                Console.WriteLine(line);
            }
        } 
    }
}
