namespace VariableAsString
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class VariableParser
    {
        private const int ParseBoolToStringMaxExecutionCount = 6;

        public void ParseBoolToString(bool variable)
        {
            string stringVariable = variable.ToString();
            Console.WriteLine("\"{0}\"", stringVariable);
        }
    }
}
