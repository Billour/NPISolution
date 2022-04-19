using System;
using System.Collections.Generic;
using System.Text;

using BatchLibrary.App;

namespace TestConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // ´ú¸ÕClass Create 
            object obj = Activator.CreateInstance<BatchLibrary.GenerateBOM>();

        }
    }

    public class AA
    {
        public AA()
            : base()
        { }

        public  int DoJob(string batchName)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
