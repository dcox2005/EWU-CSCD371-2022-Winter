using System.Runtime.Serialization;

namespace Lecture;

public class Document : Thing, ISavable, ISerializable
{
    public string Content { get; private set; }

    public Document(string name) => Name = name;

    string ISavable.ToText()
    {
        string text = "Inigo Montoya";
        text = text.ToUpper();
        return $"{nameof(Name)}: {Name} {text}";
    }

    public string ToText()
    {
        return Content;
    }

    void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
    {
        throw new NotImplementedException();
    }
}
