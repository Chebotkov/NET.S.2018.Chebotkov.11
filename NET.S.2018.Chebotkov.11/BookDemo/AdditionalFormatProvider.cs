using System;
using System.Globalization;

namespace BookDemo
{
    /// <summary>
    /// Contains additional realization for String.Format.
    /// </summary>
    public class AdditionalFormatProvider : IFormatProvider, ICustomFormatter
    {
        private IFormatProvider provider;

        /// <summary>
        /// Initializes a new instance of AdditionalFormatProvider.
        /// </summary>
        public AdditionalFormatProvider() : this(CultureInfo.CurrentCulture) { }

        /// <summary>
        /// Initializes a new instance of AdditionalFormatProvider.
        /// </summary>
        /// <param name="provider"></param>
        public AdditionalFormatProvider(IFormatProvider provider)
        {
            this.provider = provider; 
        }

        /// <summary>
        /// Returns provider. 
        /// </summary>
        /// <param name="formatType"></param>
        /// <returns>Returns provider.</returns>
        public object GetFormat(Type formatType)
        {
            return formatType == typeof(ICustomFormatter) ? this : null;
        }

        /// <summary>
        /// Returns new string created with IFormatProvider.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="arg"></param>
        /// <param name="formatProvider"></param>
        /// <returns>Returns new string.</returns>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg.GetType() != typeof(Book))
            {
                return arg.ToString();
            }

            Book book = (Book)arg;
            return String.Format("Limited edition: {0}, {1}. Special Price: {2}", book.Author, book.BookTitle, book.Price);
        }
    }
}
