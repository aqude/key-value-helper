namespace prod_keyValueHelper;

internal interface IFileInfo
{ 
    internal string FilePath { get; set; }
}

internal class FileInfo : IFileInfo
{ 
    public string FilePath { get; set; }
}
public interface IInteraction
{
    internal string AttributeKey { get; set; }
    internal string AttributeValue { get; set; }
}

public class Interaction : IInteraction
{
    public string AttributeKey { get; set; }
    public string AttributeValue { get; set; }
}

internal class Root
{
    internal List<IInteraction> InteractionsTable { get; set; }
}

