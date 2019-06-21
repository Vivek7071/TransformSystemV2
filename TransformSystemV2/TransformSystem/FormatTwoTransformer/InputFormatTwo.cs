using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FormatTrasformerInterface;

namespace FormatTwoTransformer
{
    /// <summary>
    /// Derived input format class for input format two   
    /// </summary>
    public class InputFormatTwo : BaseInputFormat
    {
        public string Type { get; set; }
        public string CustodianCode { get; set; }
    }
}
