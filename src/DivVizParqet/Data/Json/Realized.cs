using System.Diagnostics.CodeAnalysis;

namespace DivVizParqet.Data.Json;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class Realized
{
    public Realized(
        int invested,
        int value,
        int gainGross,
        int gainNet,
        double returnGross,
        double returnNet
    )
    {
        this.invested = invested;
        this.value = value;
        this.gainGross = gainGross;
        this.gainNet = gainNet;
        this.returnGross = returnGross;
        this.returnNet = returnNet;
    }

    public int invested { get; }
    public int value { get; }
    public int gainGross { get; }
    public int gainNet { get; }
    public double returnGross { get; }
    public double returnNet { get; }
}