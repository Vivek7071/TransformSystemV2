using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FormatTrasformerInterface;

namespace FormatTwoTransformer
{
    public class TransformerTwo : ITransformer
    {
        public List<BaseInputFormat> LoadInput()
        {
            return LoadFormatTwo().Cast<BaseInputFormat>().ToList();
        }

        /// <summary>
        /// Concrete method to perform transformation on List of InputFormatTwo type and convert it to standard format
        /// </summary>
        /// <returns>It returns List of StandardFormat</returns>
        public List<StandardFormat> PerformTransformation(List<BaseInputFormat> InputData)
        {
            List<StandardFormat> standardFormatList = new List<StandardFormat>();

            foreach (InputFormatTwo item in InputData)
            {
                try
                {
                    standardFormatList.Add(item.ToStandardFormat());
                }
                catch (Exception ex)
                {
                    //TODO: Enhance code as per business need
                    //Custom code for detail exception handling can be added here.
                    //Error loging, Alert Email, etc
                    //Error logging can be done in Log file, Event Viewer, Database, etc
                }
            }
            return standardFormatList;
        }

        /// <summary>
        /// Concrete method to perfomr validation on List of InputFormatOne type before processing
        /// </summary>
        /// <returns>It returns the boolean result True or False</returns>
        public bool ValidateInput()
        {
            //TODO: Enhance code as per business need
            //Custom code to validate input details will be added here based on business requirement.
            //Either skip the row which has faulty data OR skip processing entire file.
            return true;
        }

        /// <summary>
        /// Mock code to load Input format two data
        /// </summary>
        /// <returns></returns>
        //TODO: Replace this code with actual code to read the details from CSV file
        private List<InputFormatTwo> LoadFormatTwo()
        {
            List<InputFormatTwo> inputFormaterList = new List<InputFormatTwo>();

            InputFormatTwo item1 = new InputFormatTwo
            {
                Name = "My Account",
                Type = "Fund",
                Currency = "C",
                CustodianCode = "NewCode"
            };
            inputFormaterList.Add(item1);

            InputFormatTwo item2 = new InputFormatTwo
            {
                Name = "XYZ Account",
                Type = "RESP",
                Currency = "U",
                CustodianCode = "RandomCode"
            };
            inputFormaterList.Add(item2);

            InputFormatTwo item3 = new InputFormatTwo
            {
                Name = "Your Account",
                Type = "Trading",
                Currency = "C",
                CustodianCode = "HashCode"
            };
            inputFormaterList.Add(item3);

            return inputFormaterList;
        }
    }
}
