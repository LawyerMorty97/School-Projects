using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace SoftwareDesignExam
{
    public class Utilities
    {
        private static readonly Random  _RandomGenerator = new Random();
        private static bool             _runningUnitTest = false;

        static Utilities()
        {
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (assembly.FullName.ToLowerInvariant().StartsWith("nunit.framework")) {
                    _runningUnitTest = true;
                    break;
                }
            }
        }

        public static void Sleep(int millisecondsTimeout)
        {
            Thread.Sleep(millisecondsTimeout);
        }

        /// <summary>
        /// Property to check if Unit Tests are being ran
        /// </summary>
        public static bool IsUnitTestRunning
        {
            get { return _runningUnitTest; }
        }

        /// <summary>
        /// Creates a random number
        /// </summary>
        /// <param name="low">A start number</param>
        /// <param name="high">An end number, this should be larger than the 'low' argument.</param>
        /// <returns>Returns the rendom number was generated</returns>
        public static int GetRandomNumber(int low, int high)
        {
            return _RandomGenerator.Next(low, high);
        }

        /// <summary>
        /// Populates a string list with the contents of a JSON array
        /// </summary>
        /// <param name="filename">The name of the file</param>
        /// <returns>Returns a list containing the JSON array values. The list will be empty if the file doesn't exist.</returns>
        public static List<string> ConvertJSONToList(string filename)
        {
            List<string> result = new List<string>();
            if (File.Exists(filename))
            {
                string raw;
                using (StreamReader reader = new StreamReader(filename))
                {
                    raw = reader.ReadToEnd();
                }

                JArray array = JsonConvert.DeserializeObject(raw) as JArray;
                result = array.ToObject<List<string>>();
            }

            return result;
        }
    }
}
