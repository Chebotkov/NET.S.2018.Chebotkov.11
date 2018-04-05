using System;
using System.Collections;
using System.Collections.Generic;

namespace BookDemo
{
    /// <summary>
    /// Class for working with books.
    /// </summary>
    public static class BookListStorage
    {
        private static List<Book> Books;
        public static IStorage Storage { get; set; }

        /// <summary>
        /// Initializes book collection. Load it from file if it exists.
        /// </summary>
        static BookListStorage()
        {
            Books = new List<Book>();
            Storage = new StorageR();
            Storage.ReadBooksFromTheFile(Books);
        }

        /// <summary>
        /// Adds book in library.
        /// </summary>
        /// <param name="book">New book.</param>
        public static void AddBook(Book book)
        {
            Books.Add(book);
            Storage.WriteBooksToTheFile(Books);
        }

        /// <summary>
        /// Removes book from library.
        /// </summary>
        /// <param name="book">Removable book.</param>
        public static void RemoveBook(Book book)
        {
            Books.Remove(book);
            Storage.WriteBooksToTheFile(Books);
        }

        /// <summary>
        /// Sort books by tag.
        /// </summary>
        /// <param name="comparer">Comparer.</param>
        /// <exception cref="ArgumentNullException">Throws if one of the books doesn't exist.</exception>
        public static void SortBooksByTag(IComparer comparer)
        {
            if (Books.Count < 1)
            {
                throw new ArgumentNullException("There is no books to sort.");
            }

            bool isSorted = false;
            int endOfSortedPart = 0;
            while (!isSorted)
            {
                isSorted = true;
                for (int i = Books.Count - 1; i > endOfSortedPart; i--)
                {

                    if (comparer.Compare(Books[i], Books[i - 1]) < 0)
                    {
                        Book temp = Books[i];
                        Books[i] = Books[i - 1];
                        Books[i - 1] = temp;
                        isSorted = false;
                    }
                }
                endOfSortedPart++;
            }
        }

        /// <summary>
        /// Finds book by tag and returns it. 
        /// </summary>
        /// <returns>Returns wanted book.</returns>
        public static Book FindBookByTag()
        {
            throw new NotImplementedException();
        }
    }
}