using NLog;
using System;
using System.Collections.Generic;
using System.IO;

namespace BookDemo
{
    public class StorageR : IStorage
    {
        private Logger logger = LogManager.GetCurrentClassLogger();
        private string pathToFile;

        /// <summary>
        /// Initializes a new instance of <see cref="StorageR"/>
        /// </summary>
        public StorageR()
        {
            try
            {
                PathToFile = System.Configuration.ConfigurationManager.AppSettings["pathToFile"].ToString();
            }
            catch (Exception)
            {
                PathToFile = "Book.txt";
            }
        }

        /// <summary>
        /// Gets or sets path to the file.
        /// </summary>
        public string PathToFile
        {
            get
            {
                return pathToFile;
            }
            set
            {
                if (value is null)
                {
                    logger.Error("ArgumentNullException was thrown: Path can't be null.");
                    throw new ArgumentNullException("Path can't be null.");
                }
                else
                {
                    pathToFile = value;
                }
            }
        }

        #region Public methods.
        /// <summary>
        /// Writes books to the file.
        /// </summary>
        /// <param name="Books">Books.</param>
        public void WriteBooksToTheFile(IEnumerable<Book> Books)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(PathToFile, FileMode.OpenOrCreate), System.Text.Encoding.Default))
            {
                foreach (Book book in Books)
                {
                    writer.Write(String.Format(book.ISBN + "/" + book.Author + "/" + book.BookTitle + "/" + book.PublishingHouse + "/" + book.PublishingYear + "/" + book.NumberOfPages + "/" + book.Price + "/"));
                }
                writer.Close();
            }
        }

        /// <summary>
        /// Reads books from the file.
        /// </summary>
        /// <param name="Books">Book.</param>
        public List<Book> ReadBooksFromTheFile()
        {
            List<Book> Books = new List<Book>();
            using (BinaryReader reader = new BinaryReader(File.Open(PathToFile, FileMode.OpenOrCreate), System.Text.Encoding.Default))
            {
                while (reader.PeekChar() > -1)
                {
                    string s = reader.ReadString();
                    try
                    {
                        Books.Add(GetBookFromString(s));
                    }
                    catch (Exception) { }
                }
                reader.Close();
            }
            return Books;
        }
        #endregion

        #region Private methods.
        /// <summary>
        /// Returns a new instance of a book from string representation.
        /// </summary>
        /// <param name="book">String representation.</param>
        /// <returns>Returns a new instance of a book.</returns>
        private static Book GetBookFromString(string book)
        {
            string[] bookString = book.Split('/');
            return new Book(bookString[0], bookString[1], bookString[2], bookString[3], int.Parse(bookString[4]), int.Parse(bookString[5]), int.Parse(bookString[6]));
        }
        #endregion
    }
}
