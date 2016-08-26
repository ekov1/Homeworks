namespace VariableAsString
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Startup
    {
        public static void Main()
        {
            VariableParser parser = new VariableParser();

            parser.ParseBoolToString(true);
        }
    }
}
