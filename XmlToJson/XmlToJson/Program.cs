using System;

namespace XmlToJson
{
    class Program
    {
        static void Main(string[] args)
        {
            IElementReader elementReader = new ElementReader();
            var json= elementReader.Read("../../XML.xml");

            IElementWriter elementWriter = new ElementWriter();
            elementWriter.Write(json, "../../Output.json");

            Console.ReadLine();
        }
    }
}
