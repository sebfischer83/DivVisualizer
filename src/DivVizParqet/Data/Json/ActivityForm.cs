namespace DivVizParqet.Data.Json;

public class ActivityForm
{
    public ActivityForm(
        bool showTimeField,
        bool showTaxFeeField,
        string lockedField
    )
    {
        this.showTimeField = showTimeField;
        this.showTaxFeeField = showTaxFeeField;
        this.lockedField = lockedField;
    }

    public bool showTimeField { get; }
    public bool showTaxFeeField { get; }
    public string lockedField { get; }
}