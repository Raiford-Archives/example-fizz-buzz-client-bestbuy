using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; 

namespace FizzBuzz.Models
{
    /// <summary>
    /// Represents the Data flowing from client to server
    /// </summary>
    public class FizzData
    {
       
        /// <summary>
        /// Lower Number
        /// </summary>
        [Display(Name = "Lower Number"), Range(1, int.MaxValue)]
        public int LowerNumber { get; set; }


        /// <summary>
        /// Higher Number
        /// </summary>
        [Display(Name = "Higher Number"), Range(1, int.MaxValue)]
        public int HigherNumber { get; set; }


        /// <summary>
        /// Input collection string COMMA separated.
        /// </summary>
        [Display(Name = "Input Object Collection")]
        public string InputCollectionString { get; set; }


        /// <summary>
        /// Collection of results based on the input data
        /// </summary>
        [Display(Name = "Output Results")]
        public List<string> OutputResults { get; set; }

        public FizzData()
        {
            OutputResults = new List<string>();
        }


    }
}
