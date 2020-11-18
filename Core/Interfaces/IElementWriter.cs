using System.Collections.Generic;

namespace xmltojson
{
    public interface IElementWriter
    {
        void Write(List<IElement> elements, string filePath);
    }

}
