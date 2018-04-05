using System.Collections.Generic;

namespace BookDemo
{
    /// <summary>
    /// Provides methods for storage.
    /// </summary>
    public interface IStorage
    {
        /// <summary>
        /// Writes books to the file.
        /// </summary>
        /// <param name="Books">Books.</param>
        void WriteBooksToTheFile(List<Book> Books);

        /// <summary>
        /// Reads books from the file.
        /// </summary>
        /// <param name="Books">Book.</param>
        void ReadBooksFromTheFile(List<Book> Books);
    }
}
