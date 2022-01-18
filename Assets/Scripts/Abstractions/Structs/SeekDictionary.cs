using System;
using Polarith.AI.Move;
[Serializable]
public class SeekDictionary
{
    public SeekLabels _label;
    public AIMSeek _seek;

    public SeekDictionary(SeekLabels label, AIMSeek seek)
    {
        _label = label;
        _seek = seek;
    }

    public SeekLabels Label => _label;
    public AIMSeek Seek => _seek;
}