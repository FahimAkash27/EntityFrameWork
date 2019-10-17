using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EfCoreA
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            const string connectionString = "Server = DESKTOP-G4I44H7; Database = EfCoreA; User Id = akash; Password = 1234;";

            var context = new LibaryContext(connectionString);

            UserInterface(context);
        }

        private static void UserInterface(LibaryContext context)
        {

            Console.WriteLine("Welcome to library system.");
            Console.WriteLine("Please enter your choice:");
            Console.WriteLine("To entry student information enter: 1");
            Console.WriteLine("To entry book information enter: 2");
            Console.WriteLine("To issue a book, enter: 3");
            Console.WriteLine("To return a book enter: 4");
            Console.WriteLine("To check fine, enter: 5");
            Console.WriteLine("To receive fine, enter: 6");
            Console.WriteLine("To exit, enter: 7");

            Console.Write("Enter : ");

            int choice = Convert.ToInt32(Console.ReadLine());

            while(choice != 7)
            {
                switch (choice)
                {
                    case 1:
                        CreateStudent(context);
                        //UserInterface(context);
                        break;
                    case 2:
                        CreateBook(context);
                        //UserInterface(context);
                        break;
                    case 3:
                        IssueBook(context);
                        //UserInterface(context);
                        break;
                    case 4:
                        ReturnBook(context);
                        //UserInterface(context);
                        break;
                    case 5:
                        ViewFine(context);
                        //UserInterface(context);
                        break;
                    case 6:
                        GiveFine(context);
                        //UserInterface(context);
                        break;
                    case 7:
                        break;
                    default:
                        Console.WriteLine("Wrong Input.");
                        break;

                }
                Console.WriteLine(" ");
                Console.WriteLine("Welcome to library system.");
                Console.WriteLine("Please enter your choice:");
                Console.WriteLine("To entry student information enter: 1");
                Console.WriteLine("To entry book information enter: 2");
                Console.WriteLine("To issue a book, enter: 3");
                Console.WriteLine("To return a book enter: 4");
                Console.WriteLine("To check fine, enter: 5");
                Console.WriteLine("To receive fine, enter: 6");
                Console.WriteLine("To exit, enter: 7");

                Console.Write("Enter : ");
                choice = Convert.ToInt32(Console.ReadLine());


            }



        }

        private static void CreateStudent(LibaryContext context)
        {
            Console.Write("Please enter student Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var checkId = context.StudentInfos.Where(s => s.Id == id).FirstOrDefault();

            if(checkId == null)
            {
                Console.Write("Please enter student name: ");
                string name = Console.ReadLine();

                var book = context.BookInfos.Where(b => b.Id == 11).FirstOrDefault();

                context.StudentInfos.Add(new StudentInfo
                {
                    Id = id,
                    Name = name,

                    //StudentIssuedBooks = new List<StudentBook>
                    //    {
                    //        new StudentBook
                    //        {
                    //            BookInfo = book,
                    //            IssueDate = DateTime.Now
                    //        }

                    //    }
                });

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Please choose another student id");
            }



        }

        private static void CreateBook(LibaryContext context)
        {
            var book = new BookInfo();

            Console.Write("Please enter book id: ");
            book.Id = Convert.ToInt32(Console.ReadLine());

            var checkBook = context.BookInfos.Where(b => b.Id == book.Id).FirstOrDefault();

            if(checkBook == null)
            {
                Console.Write("Please enter book title: ");
                book.Title = Console.ReadLine();

                Console.Write("Please enter book author: ");
                book.Author = Console.ReadLine();

                Console.Write("Please enter book edition: ");
                book.Edition = Console.ReadLine();

                Console.Write("Please enter book barcode: ");
                book.Barcode = Console.ReadLine();

                Console.Write("Please enter book copy count: ");
                book.Count = Convert.ToInt32(Console.ReadLine());

                context.BookInfos.Add(book);

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Please choose another book id");
            }



        }

        private static void IssueBook(LibaryContext context)
        {
            Console.WriteLine("Please enter student id: ");
            int studentid = Convert.ToInt32(Console.ReadLine());

            var student = context.StudentInfos.Where(s => s.Id == studentid).FirstOrDefault();

            if (student != null)
            {
                Console.WriteLine("Please enter book barcode: ");
                string bookbarcode = Console.ReadLine();

                var book = context.BookInfos.Where(b => b.Barcode == bookbarcode).FirstOrDefault();

                if(book != null)
                {
                    if(book.Count > 0)
                    {

                        var studentBook = context.StudentBooks.Where(s => s.StudentId == studentid).FirstOrDefault();

                        var studentBookR = context.StudentBooks.Where(s => s.StudentId == studentid && s.BookInfoId == book.Id && s.Returned == false).FirstOrDefault();

                        var count = context.StudentBooks.Count();

                  

                        

                        if(studentBook == null)
                        {
                            if(studentBookR == null)
                            {
                                    student.StudentIssuedBooks = new List<StudentBook>
                                {
                                        new StudentBook
                                        {
                                            BookInfo = book,
                                            IssueDate = DateTime.Now,
                                            Id = count++
                                       
                                        


                                        }
                                };

                                Console.WriteLine("Book issued successfully,");

                                book.Count = book.Count - 1;
                            }
                            else
                            {
                                Console.WriteLine("This book is already issued by you.");
                            }
                        }
                        else
                        {   

                            if(studentBookR == null)
                            {
                                StudentBook sb = new StudentBook();
                                sb.BookInfo = book;
                                sb.IssueDate = DateTime.Now;
                                sb.Id = count++;

                                student.StudentIssuedBooks.Add(sb);
                                book.Count = book.Count - 1;
                                Console.WriteLine("Book issued successfully,");
                            }
                            else
                            {
                                Console.WriteLine("This book is already issued by you.");
                            }

                        }


                        

                        context.SaveChanges();

                    }
                    else
                    {
                        Console.WriteLine("Right now book is not available");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter valid book barcode");
                }
            }
            else
            {
                Console.WriteLine("Please enter valid student id");
            }

        }

        private static void ReturnBook(LibaryContext context)
        {
            Console.WriteLine("Please enter student id: ");
            int studentid = Convert.ToInt32(Console.ReadLine());

            StudentInfo student = context.StudentInfos.Where(s => s.Id == studentid).FirstOrDefault();

            Console.WriteLine("Please enter book barcode: ");
            string bookbarcode = Console.ReadLine();

            var book = context.BookInfos.Where(b => b.Barcode == bookbarcode).FirstOrDefault();

            var studentbook = context.StudentBooks.Where(s => s.StudentId == studentid && s.BookInfoId == book.Id && s.Returned == false).FirstOrDefault();


            if(studentbook != null)
            {
                studentbook.ReturnDate = DateTime.Now;
                studentbook.Returned = true;

                book.Count = book.Count + 1;

                int dayDifference = Convert.ToInt32((studentbook.IssueDate - studentbook.ReturnDate).TotalDays);

                //Console.WriteLine(dayDifference);

                if (dayDifference > 7)
                {
                    int fineAmount = (dayDifference - 7) * 10;
                    studentbook.StudentInfo.FineAmount = fineAmount;
                }


                context.SaveChanges();

                Console.WriteLine("Book return successfully.");
            }
            else
            {
                Console.WriteLine("This book does not belong to us.");
            }


        }

        private static void ViewFine(LibaryContext context)
        {
            Console.Write("Please enter student id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var student = context.StudentInfos.Where(s => s.Id == id).FirstOrDefault();

            if(student != null)
            {
                Console.WriteLine("Your fine due is : " + student.FineAmount);
            }
        }

        private static void GiveFine(LibaryContext context)
        {
            Console.Write("Please enter student id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var student = context.StudentInfos.Where(s => s.Id == id).FirstOrDefault();

            if (student != null && student.FineAmount > 0)
            {
                Console.Write("Enter the amount you want to give : ");

                int amount = Convert.ToInt32(Console.ReadLine());

                student.FineAmount = student.FineAmount - amount;

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Your fine are all clear.");
            }
        }
    }
}
