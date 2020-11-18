using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace xmltojson
{
    public class ElementWriter : IElementWriter
    {
        public void Write(List<IElement> elements, string filePath)
        {
            if(!Directory.GetParent(filePath).Exists)
                throw new DirectoryNotFoundException($"Directory for path: {filePath} not found");

            if (elements == null)
                throw new OutputDataCanNotBeNull("Output data can't be null");

            if (!elements.Any())
                throw new OutputDataIsEmpty("Output data can't be empty");

            var jsonResult = JsonConvert.SerializeObject(elements, Formatting.Indented);
            File.WriteAllText(filePath, jsonResult);
        }
    }
}
