using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookCatalogue.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

namespace BookCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {

            SeedDataBase();

  Console.WriteLine("Welcome to the NIftyBooks Datatbase");
 bool validChoice;
 
 do // inner do...while loop is to keep looping until the user picks a valid menu selection
            {            //Menu Stuff
             validChoice = true;

              

                Console.WriteLine("--------------------------------------------");

                Console.WriteLine("Please select a menu option below:");
                Console.WriteLine("--------------------------------------------");

                Console.WriteLine( "Commands:");
                Console.WriteLine("1) Full List of Everyone!"); 
                Console.WriteLine("2) Show books with publish Apress");
                Console.WriteLine("0) exit)");
                Console.WriteLine("--------------------------------------------");

              try
                {
                Console.Write("> ");
                var command = Console.ReadLine();
                switch (command)
                {

                    
                    case "1":
                        Commands.ListAll();
                        validChoice = false;
                        break;

                         case "2":
                        Commands.CertianBookPublisher();
                        validChoice = false;
                        break;

                    
                  
                         
                    case "0":
                        return;
                    default: 
                        validChoice = false;
                        Console.WriteLine("Unknown command.");
                        break;
                }

                }
                catch (FormatException)
                {
                    // This try...catch block catches the FormatException that Convert.ToInt32 will throw 
                    // if the user inputs text or something that cannot be converted to an integer.
                    validChoice = false;
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            } while (validChoice == false); // Inner loop ends when validChoice is true


            //end menu stuff

            



            
        }


//Begin Seed Database Method


public static void SeedDataBase()
{ 
  using(var db = new AppDbContext())
            {
                try
                {

                    //no matter what, delete and then create
                   db.Database.EnsureDeleted();
                    db.Database.EnsureCreated();

                    if(!db.Books.Any())
                    {
                        List<Books> books = new List<Books>()
                        {
                            new Books()
                            {

                                Title = "Pro ASP.NET Core MVC 2 7th ed. Edition",
                                Publisher = "Apress",
                                PublishDate = new DateTime(2017, 10, 25),
                                Pages = 1017,
                                AuthorId = 1, 
                            },

                            new Books()
                            {

                                Title = "Pro Angular 6 3rd Edition",
                                Publisher = "Apress",
                                PublishDate = new DateTime(2018, 10, 28),
                                AuthorId = 1,
                                Pages = 776

                                
                            },

                            new Books()
                            {

                                Title = "Programming Microsoft Azure Service Fabric (Developer Reference) 2nd EditionPro Angular 6 3rd Edition",
                                Publisher = "Microsoft Press",
                                PublishDate = new DateTime(2018, 5, 25),
                                AuthorId = 2,
                                Pages = 528
                            },
                                           
                        };

   if(!db.Authors.Any())
                    {
                        List<Authors> authors = new List<Authors>()
                        {
                            new Authors()
                                   {

                                Id = 1,
                                AuthorName = "Adam Freeman",
                                   },

                               new Authors()
                                   {

                                Id = 2,
                                AuthorName = "Haishi Bai",
                                   }
                        };
                        
                        db.Books.AddRange(books);  
                        db.Authors.AddRange(authors);  

                        db.SaveChanges();                                              



                    }
                    else
                    {
                        var Books = db.Books.ToList();
                        var Authors = db.Authors.ToList();
            
            
                   
                    }
                }
                }
                catch(Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
        }
//End See Database Method
    }
}

             
        
    
            
