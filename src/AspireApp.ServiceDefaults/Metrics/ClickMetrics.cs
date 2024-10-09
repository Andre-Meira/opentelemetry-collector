using AspireApp.ServiceDefaults.Models;
using System.Diagnostics.Metrics;

namespace Microsoft.Extensions.Hosting;

public interface IClickMetrics
{
    void UserClicked(Click click);
}

public class ClickMetrics : IClickMetrics
{
    public const string MeterName = "Clicks.Metricts";

    private readonly UpDownCounter<double> _TemperatureC;
    private double _TemperatureCLast;

    public ClickMetrics(IMeterFactory meterFactory)
    {
        var meter = meterFactory.Create(MeterName);
        _TemperatureC = meter.CreateUpDownCounter<double>("clicks.metrics.couters");
    }

    public void UserClicked(Click click)
    {
        _TemperatureC.Add(1,
            tag1: new("clicks.metrics.button.name", click.BottonName),
            tag2: new("clicks.metrics.button.usernam", click.UserClick));
    }
}
