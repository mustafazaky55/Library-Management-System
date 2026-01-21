using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Channels;

namespace Library_System
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("    Library Management System    ");
            Console.WriteLine("-----------------------------------");
            Library library = new Library();
            int _Option;
            do
            {
                Console.WriteLine("1. Add, 2. View, 3. Search, 4. Remove ,5. Borrow , 6. Exit");
                _Option = INPUT();
                if (_Option == 1)
                {
                    library.AddNewBook();
                }else if(_Option == 2)
                {
                    library.View();
                }else if(_Option == 3)
                {
                    library.Search();
                }else if( _Option == 4)
                {
                    library.RemoveBook();
                }else if (_Option == 5)
                {
                   library.BorrowBook();
                }
            } while (_Option != 6);
            Console.WriteLine();
            Console.WriteLine("Thanks For your Time :) ");
        }
        public static int INPUT()
        {
            int result;
            do
            {

            } while (!int.TryParse(Console.ReadLine()!, out result));
            return result;
        }

    }
}
