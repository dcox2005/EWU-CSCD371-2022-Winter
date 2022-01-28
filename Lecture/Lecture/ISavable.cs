namespace Lecture;
public interface ISavable
{
    string? ToText();

    Stream ToStream();
}

