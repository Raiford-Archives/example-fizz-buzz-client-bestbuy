using FizzBuzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FizzBuxzz.Web.Controllers
{

    /// <summary>
    /// Controller for all FizzBuzz related actions
    /// </summary>
    public class FizzBuzzController : Controller
    {
        #region Action Methods


        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Index()
        {
            // Initialize some default model data
            FizzData data = new FizzData()
            {
                LowerNumber = 2,
                HigherNumber = 10,
                InputCollectionString = "4,5,99,100,0,r,w,22, 3, 34, 2, 555, 7777, -3, 555, 22, 3, 5,6,7,8,89,2465246, 3",
                OutputResults = new List<string>()
            };

            return View(data);
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(FizzData data)
        {            
            
            //NOTE: in a real application I like to push the logic down into a Facade / Reppository layer. I like to keep the controllers LIGHT!
            
            // Calulate the Results
            data.OutputResults = CalculateResults(data.LowerNumber, data.HigherNumber, data.InputCollectionString);

            return View(data);
        }
        #endregion

        #region Helper Methods - NOTE: These would usually be in a Business Logic layer and not in the controller

        /// <summary>
        /// Calculates the result string and return a collection of results
        /// </summary>
        /// <param name="lowerNumber"></param>
        /// <param name="higherNumber"></param>
        /// <param name="inputCollectionString"></param>
        /// <returns></returns>
        private List<string> CalculateResults(int lowerNumber, int higherNumber, string inputCollectionString)
        {
            List<string> results = new List<string>();

            // Parse the object collection string
            List<string> items = inputCollectionString.Split(',').ToList();

            // Iterate input and calulate output
            foreach(string item in items)
            {
                string result = BuildResult(lowerNumber, higherNumber, item);

                results.Add(result);
            }
            
            return results;
        }

        /// <summary>
        /// Build a single result item
        /// </summary>
        /// <param name="lowerNumber"></param>
        /// <param name="higherNumber"></param>
        /// <param name="itemString"></param>
        /// <returns></returns>
        private string BuildResult(int lowerNumber, int higherNumber, string itemString)
        {
            string result = "";
            string divisionDone = "";
            
            string code = "";
            int divCount = 0; 


            // First check if the item is not a number
            int number;
            bool success = int.TryParse(itemString, out number);
            if(!success)
            {                
                // Its not a number so assign message
                result = string.Format(@"Invalid Item ({0} is not a number)", itemString);
                return result;
            }
            
            // If the object is divisible by the lower number then output the word “Fizz”
            divisionDone += string.Format("Divided {0} by {1}", number, lowerNumber);
            if (lowerNumber > 0)
            {
                if (number % lowerNumber == 0)
                {
                    divCount++;
                    code = "Fizz";
                }
            }
            else
            {
                code = "Invalid Item";
            }

            // If the object is divisible by the higher number then output the word “Buzz”
            // NOTE: This will append the Buzz since the requirement want FizzBuzz if both divisible
            divisionDone += string.Format(" and Divided {0} by {1}", number, higherNumber);
            if (higherNumber > 0)
            {
                if (number % higherNumber == 0)
                {
                    divCount++;
                    code += "Buzz";
                }
            }
            else
            {
                code = "Invalid Item";
            }


            // If Divisible by both then tweak the code
            code = divCount == 2 ? "FizzBuzz" : code;

            // Append the results to a single string
            result = divisionDone + " : " +  code;

            return result;
        }
        #endregion
    }
}