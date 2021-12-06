using System.Diagnostics.CodeAnalysis;

namespace DivVizParqet.Data.Json;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class Sources
{
    public Sources(
        string arivaSecuID
    )
    {
        this.arivaSecuID = arivaSecuID;
    }

    public string arivaSecuID { get; }
}