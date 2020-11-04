using System;

namespace XmlToJson
{
    public class DataNullException : Exception
    {
        public DataNullException() : base("Data can't be null")
        {
            
        }
    }
}
