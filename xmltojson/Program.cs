namespace xmltojson
{
    class Program
    {
        private static string path1 = "../../XML.xml";
        private static string path2 = "../../Output.json";

        static void Main(string[] args)
        {
            IElementReader reader = new ElementReader();
            var items = reader.Read(path1);

            IElementWriter writer = new ElementWriter();
            writer.Write(items, path2);
        }
    }
}
