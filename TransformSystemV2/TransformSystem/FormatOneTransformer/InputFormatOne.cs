using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FormatTrasformerInterface;

namespace FormatOneTransformer
{
    /// <summary>
    /// Derived input format class for input format one   
    /// </summary>
    public class InputFormatOne : BaseInputFormat
    {
        public string Identifier { get; set; }
        public Int16 Type { get; set; }
        public DateTime Opened { get; set; }
    }
}
