using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using BookCatalogue.Models;

namespace BookCatalogue
{
    public static class Commands
{

      public static void ListAll()
        {
            Console.WriteLine("The method ran");
            using (var db = new AppDbContext())              //#A
            {
                Console.WriteLine();

                Console.WriteLine($"NIFTYBOOKS DATABASE CONTENT:");

                Console.WriteLine();

                Console.WriteLine("Books");
                
                Console.WriteLine("--------------------------------------------------------------------");

                var books = db.Books.ToList();
                foreach(Books s in books)
                    {
                        Console.WriteLine($"{s.Title} - {s.Publisher} - {s.Pages}");
                    }
            Console.WriteLine();                        
            Console.WriteLine();
/*
                Console.WriteLine("Organizations");
            
                Console.WriteLine("--------------------------------------------------------------------");
                var organizations = db.Organizations.ToList();
            foreach(Organization o in organizations)
            {
                Console.WriteLine($"Organization: {o.OrganizationId}, {o.Name}");
            }

   */          
            
            Console.WriteLine();
                Console.WriteLine();

        }


        }
                



        public static void PrintList(IEnumerable<string> list)
        {
            foreach(var s in list)
            {
                Console.WriteLine(s);
            }
}

//Where publisher is a certain one
   public static void CertianBookPublisher()
         { Console.WriteLine("The Certain Book Publisher Method Ran");
            using(var db = new AppDbContext())
             {
                 var filteredResult = from s in db.Books
                 where s.Publisher == "Apress" 
                 select "Book Title: " + s.Title + ", Publisher:" + s.Publisher;

                 PrintList(filteredResult);
             }
}

//Where publisher is a certain one
    }
}
