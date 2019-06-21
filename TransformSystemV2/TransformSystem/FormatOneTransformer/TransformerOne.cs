using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FormatTrasformerInterface;

namespace FormatOneTransformer
{
    
    /// <summary>
    /// Concrete class to perform validation and transformation on List of InputFormatOne and convert it to standard format.
    /// </summary>
    public class TransformerOne : ITransformer
    {
        //private List<InputFormatOne> _inputFormat;

        /// <summary>
        /// Parameterized constructor to initialize object of FormatOneTransformer
        /// </summary>
        /// <param name="InputFormat"></param>
        //public FormatOneTransformer(List<InputFormatOne> InputFormat)
        //{
        //    _inputFormat = InputFormat;
        //}

        public List<BaseInputFormat> LoadInput()
        {
            return LoadFormatOne().Cast<BaseInputFormat>().ToList();
        }
        /// <summary>
        /// Concrete method to perform transformation on List of InputFormatOne type and convert it to standard format
        /// </summary>
        /// <returns>It returns List of StandardFormat</returns>
        public List<StandardFormat> PerformTransformation(List<BaseInputFormat> InputData)
        {
            List<StandardFormat> standardFormatList = new List<StandardFormat>();

            foreach (InputFormatOne item in InputData)
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
            //Either skip the row which has faulty data OR skip processing entire list/file.
            return true;
        }

        /// <summary>
        /// Mock code to load Input format one data
        /// </summary>
        /// <returns></returns>
        //TODO: Replace this code with actual code to read the details from CSV file
        static private List<InputFormatOne> LoadFormatOne()
        {
            List<InputFormatOne> inputFormaterList = new List<InputFormatOne>();
            InputFormatOne item1 = new InputFormatOne
            {
                Identifier = "123|AbcCode",
                Name = "My Account",
                Type = 1,
                Opened = Convert.ToDateTime("01-01-2018"),
                Currency = "CD"
            };
            inputFormaterList.Add(item1);

            InputFormatOne item2 = new InputFormatOne
            {
                Identifier = "456|TestCode",
                Name = "Test Account",
                Type = 2,
                Opened = Convert.ToDateTime("03-02-2018"),
                Currency = "US"
            };
            inputFormaterList.Add(item2);

            InputFormatOne item3 = new InputFormatOne
            {
                Identifier = "789|SomeCode",
                Name = "Some Account",
                Type = 3,
                Opened = Convert.ToDateTime("03-12-2018"),
                Currency = "CD"
            };
            inputFormaterList.Add(item3);

            return inputFormaterList;
        }
    }
    
}
