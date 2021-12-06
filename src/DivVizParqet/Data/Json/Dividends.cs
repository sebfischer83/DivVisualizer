using System.Diagnostics.CodeAnalysis;

namespace DivVizParqet.Data.Json;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class Dividends
{
    public Dividends(
        int invested,
        int value,
        int gainGross,
        int gainNet,
        double returnGross,
        double returnNet,
        double personalReturnGross,
        double personalReturnNet
    )
    {
        this.invested = invested;
        this.value = value;
        this.gainGross = gainGross;
        this.gainNet = gainNet;
        this.returnGross = returnGross;
        this.returnNet = returnNet;
        this.personalReturnGross = personalReturnGross;
        this.personalReturnNet = personalReturnNet;
    }

    public int invested { get; }
    public int value { get; }
    public int gainGross { get; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Benennungsstile", Justification = "<Ausstehend>")]
    public int gainNet { get; }
    public double returnGross { get; }
    public double returnNet { get; }
    public double personalReturnGross { get; }
    public double personalReturnNet { get; }
}