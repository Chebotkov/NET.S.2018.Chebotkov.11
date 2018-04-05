using System;

namespace BookDemo
{
    /// <summary>
    /// Contains information about book.
    /// </summary>
    public class Book
    {
        private string isbn;
        private string author;
        private string bookTitle;
        private string publishingHouse;
        private int publishingYear;
        private int numberOfPages;
        private decimal price;

        /// <summary>
        /// Initializes a new instance of <see cref="Book"/>
        /// </summary>
        /// <param name="isbn">Book ISBN.</param>
        /// <param name="author">Book author.</param>
        /// <param name="bookTitle">Book title.</param>
        /// <param name="publishingHouse">Publishing house of the book.</param>
        /// <param name="publishingYear">Year of publication of the book.</param>
        /// <param name="numberOfPages">Number of pages in a book.</param>
        /// <param name="price">Book price.</param>
        /// <exception cref="ArgumentException">Throws when entered invalid price, year or number of pages.</exception>
        public Book(string isbn, string author, string bookTitle, string publishingHouse, int publishingYear, int numberOfPages, decimal price)
        {
            if (isbn is null || author is null || bookTitle is null || publishingHouse is null)
            {
                throw new ArgumentNullException("ISBN, author, book title and publishing house are required parametres.");
            }

            if (price < 0 || numberOfPages < 0 || publishingYear < 0)
            {
                throw new ArgumentException("Price, number of pages and publishing year must be positive.");
            }
            
            this.isbn = isbn;
            this.author = author;
            this.bookTitle = bookTitle;
            this.publishingHouse = publishingHouse;
            this.publishingYear = publishingYear;
            this.numberOfPages = numberOfPages;
            this.price = price;
        }

        /// <summary>
        /// Gets book ISBN.
        /// </summary>
        public string ISBN
        {
            get
            {
                return isbn;
            }
        }

        /// <summary>
        /// Gets book author.
        /// </summary>
        public string Author
        {
            get
            {
                return author;
            }
        }

        /// <summary>
        /// Gets book title.
        /// </summary>
        public string BookTitle
        {
            get
            {
                return bookTitle;
            }
        }
        /// <summary>
        /// Gets publishing house of the book.
        /// </summary>
        public string PublishingHouse
        {
            get
            {
                return publishingHouse;
            }
        }

        /// <summary>
        /// Gets publishing year of the book.
        /// </summary>
        public int PublishingYear
        {
            get
            {
                return publishingYear;
            }
        }

        /// <summary>
        /// Gets number of pages in a book.
        /// </summary>
        public int NumberOfPages
        {
            get
            {
                return numberOfPages;
            }
        }

        /// <summary>
        /// Gets book price.
        /// </summary>
        public decimal Price
        {
            get
            {
                return price;
            }
            private set
            {
                price = value > 0 ? value : throw new ArgumentException("Price must be positive.");
            }
        }
        
        /// <summary>
        /// Changes the price of the book.
        /// </summary>
        /// <param name="newPrice">New book price.</param>
        /// <exception cref="ArgumentException">Throws when entered invalid price.</exception>
        public void ChangePrice(decimal newPrice)
        {
            if (newPrice < 0)
            {
                throw new ArgumentException("Price must be positive.");
            }

            Price = newPrice;
        }

        /// <summary>
        /// Checks if books equal. 
        /// </summary>
        /// <param name="otherBook">Other book.</param>
        /// <returns>True if books are equal. False - don't equal.</returns>
        public override bool Equals(object otherBook)
        {
            return ReferenceEquals(this, otherBook) ? true : false;
        }

        /// <summary>
        /// Checks if books equal. 
        /// </summary>
        /// <param name="otherBook">Other book.</param>
        /// <param name="equatable">The way for checking.</param>
        /// <returns>True if books are equal. False - don't equal.</returns>
        /// <exception cref="ArgumentNullException">Throws when one of the books doesn't exists</exception>
        public bool Equals(Book otherBook, IEquatable<Book> equatable)
        {
            if (this.Equals(otherBook))
            {
                return true;
            }

            if (ReferenceEquals(this, null) || ReferenceEquals(otherBook, null))
            {
                throw new ArgumentNullException("Book can't be null.");
            }

            return equatable.Equals(otherBook);
        }

        /// <summary>
        /// Returns hash code of the book.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return this.ISBN.GetHashCode();
        }
    }
}
