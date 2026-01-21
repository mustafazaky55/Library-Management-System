using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Library_System
{
    enum Status
    {
        Available, Borrowed
    }
    class Book
    {
        public String Title { get; private set; }
        public string[] Authors { get; set; }
        public string ISBN { get; set; }
        public Status __Status { get; set; }
        public Book()
        {
            Title = "";
            Authors = new string[0];
            ISBN = "";
            __Status = Status.Available;
        }
        public Book(string title, string[] authors, string iSBN, Status status)
        {
            Title = title;
            Authors = authors;
            ISBN = iSBN;
            __Status = status;
        }
        public override string ToString()
        {
            return $"Title = {Title} ||  Authors = {printAuthores(Authors)}  || ISBN = {ISBN}  || ({__Status})";
        }
        public string printAuthores(string[] _author)
        {
            return string.Join(',', _author);
        }
        
    }
    class Library : Collection<Book>
    {
        protected override void InsertItem(int index, Book item)
        {
            if(this.Any(b => b.ISBN == item.ISBN))
            {
                Console.WriteLine("This ISBN already exist!");
                return;
            }
            base.InsertItem(index, item);
        }
        protected override void RemoveItem(int index)
        {
            base.RemoveItem(index);
        }
        public void BorrowBook()
        {
            if (this.Count == 0) { Console.WriteLine("The Library is Empty :("); return; }
            Console.WriteLine("Title For The Book Borrowed");
            string _title = Console.ReadLine()!;
            for (int i = 0; i < this.Count; i++)
            {
                if (string.Equals(this[i].Title,_title,StringComparison.OrdinalIgnoreCase))
                {
                    this[i].__Status = Status.Borrowed;
                    Console.WriteLine("The status Updeted Successfully");
                    break;
                }
            }

        }
        public void AddNewBook()
        {
            Console.WriteLine("Book Title: ");
            string title = Console.ReadLine()!;

            Console.WriteLine("Number of Authores: ");
            int numberofauthers = Program.INPUT();
            string[] Authors = new string[numberofauthers];
            for (int i = 0; i < numberofauthers; i++)
            {
                Console.WriteLine($"Author {i + 1}: ");
                string name = Console.ReadLine()!;
                Authors[i] = name;
            }
            Console.WriteLine("Book ISBN: ");
            string ISBN = Console.ReadLine()!;
            this.Add(new Book(title, Authors, ISBN, 0));
        }
        public void View()
        {
            if (this.Count == 0) { Console.WriteLine("The Library is Empty :("); return; }
            for (int i = 0; i < (int)this.Count; i++)
            {
                Book book = this[i];
                Console.Write($"Book number {i + 1} ==> ");
                Console.WriteLine(book.ToString());
            }
        }
        public void Search()
        {
            if (this.Count == 0) { Console.WriteLine("The Library is Empty :("); return; }
            int num;
            do
            {
                Console.WriteLine("Choose option for search: 1.title 2.ISBN");
                num = Program.INPUT();
            } while (num != 1 && num != 2);

            if (num == 1)
            {
                Console.WriteLine("Title for Search");
                string _title = Console.ReadLine()!;
                SearchByTitle(_title);
            }
            else
            {
                Console.WriteLine("ISBN for Search");
                string _ISBN = Console.ReadLine()!;
                SearchByISBN(_ISBN);
            }
        }
        public void SearchByTitle(string title)
        {
            for (int i = 0; i < this?.Count; i++)
            {
                if (string.Equals(this[i].Title , title , StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(this[i].ToString());
                    return;
                }
            }        
           Console.WriteLine("There is no Books with given title");
        }
        public void SearchByISBN(string _ISBN)
        {
            for (int i = 0; i < this?.Count; i++)
            {
                if (this[i].ISBN == _ISBN)
                {
                    Console.WriteLine(this[i].ToString());
                    return;
                }
            }
            Console.WriteLine("There is no Books with given ISBN");    
        }
        public void RemoveBook()
        {
            if (this.Count == 0) { Console.WriteLine("The Library is Empty :("); return; }
            Console.WriteLine("Title for remove: ");
            string _title = Console.ReadLine()!;
            for (int i = 0; i < this?.Count; i++)
            {
                if (this[i].Title == _title)
                {
                    this.Remove(this[i]);
                    return;
                }
            }
            Console.WriteLine("There is no book with the given title to remove");
            return;
        }
    }
}
