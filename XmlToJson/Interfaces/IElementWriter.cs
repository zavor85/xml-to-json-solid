using System.Collections.Generic;

namespace XmlToJson
{
    public interface IElementWriter
    {
        void Write(List<IElement> elements, string filePath);
        void WriteDataToJsonFile(List<IOutput> outputList, string filePath);
        List<IOutput> AddOutputToList(List<IElement> elements);
    }
}
