using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormatTrasformerInterface
{
        /// <summary>
        /// Interface for Format Transformer
        /// Operation PerformTransformation() is to Transform the Input format into standard format
        /// Operation ValidateInput() is to perform the validation of Input format
        /// </summary>
        public interface ITransformer
        {
            List<BaseInputFormat> LoadInput(); 
            List<StandardFormat> PerformTransformation(List<BaseInputFormat> InputData);
            bool ValidateInput();
        }
    }

