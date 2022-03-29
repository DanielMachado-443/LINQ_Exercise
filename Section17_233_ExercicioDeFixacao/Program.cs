using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using Section17_233_ExercicioDeFixacao.Entities;
using Section17_233_ExercicioDeFixacao.Services;

namespace Section17_233_ExercicioDeFixacao {
    class Program {
        static void Main(string[] args) {
            Console.Write("\nType the file path you want to use: ");
            //string filePath = Console.ReadLine();
            string filePath = @"C:\Users\Daniel\source\repos\Section17_233_ExercicioDeFixacao\Testes\233Query.csv";

            List<Employee> empList = new List<Employee>();
            using(StreamReader sr = File.OpenText(filePath)) {
                while (!sr.EndOfStream) {
                    string[] line = sr.ReadLine().Split(",");
                    string name = line[0];
                    string email = line[1];
                    double salary = double.Parse(line[2]);
                    empList.Add(new Employee(name, email, salary));
                }
            }

            Console.Write("\nType the minimum salary requirement: ");
            //double minSalary = double.Parse(Console.ReadLine());
            double minSalary = 2000.00;

            Console.WriteLine("\nEmail of people whose salary is more than $2000.00: ");
            foreach(string str in Query.firstQuery(empList, minSalary)) { //<< calling the static method (not needed to instanciate an object
                Console.WriteLine(str);
            }

            char firstLetter = 'A';
            try { // << PUT INSIDE A BIG WHILE TO MAKE IT UNBREAKABLE
                Console.Write("\nType the employees first letter that you want to use: ");
                //char firstLetter = char.Parse(Console.ReadLine());
                firstLetter = 'M';
            }
            catch(Exception e) {
                Console.WriteLine("\n" + e);
            }
            
            Console.WriteLine("\nThe sum of first name letter 'M' employees salary is: $" + Query.firstLetterSalarySum(empList, firstLetter).ToString("f2", CultureInfo.InvariantCulture));
            Console.WriteLine();                       
        }
    }
}
