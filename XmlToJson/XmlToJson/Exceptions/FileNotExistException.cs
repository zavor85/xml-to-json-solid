using System;

namespace XmlToJson
{
    public class FileNotExistException : Exception 
    {
        public FileNotExistException() : base("File path not exist")
        {
            
        }
    }
}
