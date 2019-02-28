using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator {
    class CalcController {
        private List<string> storedValues;

        public CalcController() {
            storedValues = new List<string>();
        }

        /* Store values to list */
        public void storeValues(string values, string prepend = "", string append = "") {
            storedValues.Add(prepend + values + append);
        }

        /* Return the list of stored values as a string array */
        public string[] getValueArray() {
            return storedValues.ToArray<string>();
        }

        /* Get two latest values from list of stored values as a single string */
        private string getOperation() {
            int lastIndex = storedValues.Count - 1;
            return storedValues[lastIndex - 1] + storedValues[lastIndex];
        }

        /* Calculate and return the result of calculation */
        public string Calculate() {
            string[] numbers;
            string operation = getOperation();

            if (operation.Contains("+")) {
                numbers = operation.Split('+');
                return (Convert.ToDouble(numbers[0]) + Convert.ToDouble(numbers[1])).ToString();
            } else if (operation.Contains("-")) {
                numbers = operation.Split('-');
                return (Convert.ToDouble(numbers[0]) - Convert.ToDouble(numbers[1])).ToString();
            } else if (operation.Contains("x")) {
                numbers = operation.Split('x');
                return (Convert.ToDouble(numbers[0]) * Convert.ToDouble(numbers[1])).ToString();
            } else if (operation.Contains("/")) {
                numbers = operation.Split('/');
                return (Convert.ToDouble(numbers[0]) / Convert.ToDouble(numbers[1])).ToString();
            } else {
                return null;
            }
        }
    }
}
