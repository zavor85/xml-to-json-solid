using System.Collections.Generic;

namespace XmlToJson
{
    public interface IElementReader
    {
        List<IElement> Read(string filePath);
        IRoot ReadXml(string filePath);
        List<IElement> AddElementsToList(IRoot rootObject);
    }
}
