using System;

namespace XmlToJson
{
    public class FilePathNullException : Exception
    {
        public FilePathNullException() : base("File path can't be null")
        {
            
        }
    }
}
