using NLog;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BookDemo
{
    /// <summary>
    /// Class for working with books.
    /// </summary>
    public class BookListStorage
    {
        public List<Book> Books;
        private Logger logger = LogManager.GetCurrentClassLogger();
        private IStorage storage = new StorageR();
        
        /// <summary>
        /// Gets or sets storage for BookListStorage.
        /// </summary>
        public IStorage Storage
        {
            get
            {
                return storage;
            }
            set => Storage = value is null ? new StorageR() : value;
        }

        /// <summary>
        /// Initializes book collection. Load it from file if it exists.
        /// </summary>
        public BookListStorage()
        {
            Books = new List<Book>();
        }

        /// <summary>
        /// Adds book in library.
        /// </summary>
        /// <param name="book">New book.</param>
        public bool AddBook(Book book)
        {
            if (Books.Contains(book))
            {
                return false;
            }

            Books.Add(book);
            Storage.WriteBooksToTheFile(Books);
            return true;
        }
        
        public void SetNewStorage(IStorage storage)
        {
            Storage = storage is null ? new StorageR() : storage;
            Books = Storage.ReadBooksFromTheFile();
        }

        /// <summary>
        /// Removes book from library.
        /// </summary>
        /// <param name="book">Removable book.</param>
        public void RemoveBook(Book book)
        {
            Books.Remove(book);
            Storage.WriteBooksToTheFile(Books);
        }

        /// <summary>
        /// Sort books by tag.
        /// </summary>
        /// <param name="comparer">Comparer.</param>
        /// <exception cref="ArgumentNullException">Throws if one of the books doesn't exist.</exception>
        public void SortBooksByTag(IComparer<Book> comparer)
        {
            if (Books.Count < 1)
            {
                logger.Error("ArgumentNullException was thrown: There is no books to sort."); 
                throw new ArgumentNullException("There is no books to sort.");
            }
            if (comparer is null)
            {
                logger.Error("ArgumentNullException was thrown: {0} is null.", nameof(comparer));
                throw new ArgumentNullException("{0} is null.", nameof(comparer));
            }

            Books.Sort(comparer);            
        }

        /// <summary>
        /// Finds book by tag and returns it. 
        /// </summary>
        /// <returns>Returns wanted book.</returns>
        public Book FindBookByTag()
        {
            throw new NotImplementedException();
        }
    }
}