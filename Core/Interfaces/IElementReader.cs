using System.Collections.Generic;

namespace xmltojson
{
    public interface IElementReader
    {
        List<IElement> Read(string filePath);
    }

}
