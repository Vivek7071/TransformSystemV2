using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FormatTrasformerInterface;

namespace FormatOneTransformer
{
    public static class CustomExtension
    {
        /// <summary>
        /// Extension method for InputFormatOne type to convert the object of InputFormatOne into StandardFormat
        /// </summary>
        /// <param name="item">Object of InputFormatOne</param>
        /// <returns>Object of StandardFormat</returns>
        public static StandardFormat ToStandardFormat(this InputFormatOne item)
        {
            StandardFormat result = null;
            result = new StandardFormat
            {
                AccountCode = item.Identifier.Split('|')[1],
                Name = item.Name,
                Type = item.Type.ToAccountType(),
                OpenDate = item.Opened,
                Currency = item.Currency.ToCurrencyCode(),
            };
            return result;
        }

        #region AccountType Methods
        /// <summary>
        /// Extension method on Int16 to convert int value to associated account type description
        /// </summary>
        /// <param name="value">integer value</param>
        /// <returns>associated account type description</returns>
        public static string ToAccountType(this Int16 value)
        {
            string accountType = string.Empty;
            switch (value)
            {
                case 1:
                    accountType = "Trading";
                    break;
                case 2:
                    accountType = "RRSP";
                    break;
                case 3:
                    accountType = "RESP";
                    break;
                case 4:
                    accountType = "Fund";
                    break;
                default:
                    accountType = "Unknown";
                    break;
            }
            return accountType;
        }
        #endregion AccountType Methods

        #region CurrencyCode Methods
        /// <summary>
        /// Extension method to convert currency code into standard format
        /// </summary>
        /// <param name="value">string value</param>
        /// <returns>associated currency code</returns>
        public static string ToCurrencyCode(this string value)
        {
            string currency = string.Empty;
            switch (value)
            {
                case "CD":
                case "C":
                    currency = "CAD";
                    break;
                case "US":
                case "U":
                    currency = "USD";
                    break;
                default:
                    currency = "Unknown";
                    break;
            }
            return currency;
        }
        #endregion CurrencyCode Methods
    }
}
