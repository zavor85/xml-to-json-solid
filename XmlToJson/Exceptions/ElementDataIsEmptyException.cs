using System;

namespace XmlToJson
{
    public class ElementDataIsEmptyException : Exception
    {
        public ElementDataIsEmptyException() : base("Element list data is empty")
        {
            
        }
    }
}
