using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;

namespace XmlToJson
{
    public class ElementWriter : IElementWriter
    {
        private readonly List<IOutput> _listOutput;

        public ElementWriter()
        {
            _listOutput = new List<IOutput>();
        }

        public void Write(List<IElement> elements, string filePath)
        {
            var outputList = AddOutputToList(elements);
            WriteDataToJsonFile(outputList, filePath);
        }

        public void WriteDataToJsonFile(List<IOutput> outputList, string filePath)
        {
            if(filePath == null)
                throw new FilePathNullException();
            if(outputList == null)
                throw new DataNullException();
            if (!outputList.Any())
                throw new OutputDataIsEmpty();

            string json = new JavaScriptSerializer().Serialize(outputList);
            File.WriteAllText(filePath, json);
        }

        public List<IOutput> AddOutputToList(List<IElement> elements)
        {
            if (elements == null)
                throw new DataNullException();
            if (!elements.Any())
                throw new ElementDataIsEmptyException();

            _listOutput.AddRange(elements.Select(el =>
                new Output()
                {
                    divided = el.Variable1 / el.Variable2,
                    multiplied = el.Variable1 * el.Variable2
                }
            ));

            return _listOutput;
        }
    }
}
