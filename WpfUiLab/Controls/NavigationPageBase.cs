using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WpfUiLab.Controls;

public abstract class NavigationPageBase : Page
{
    private readonly ILogger<NavigationPageBase> _logger = App.Services.GetRequiredService<ILogger<NavigationPageBase>>();

    public virtual void OnAppeared()
    {
        _logger.LogDebug("OnAppeared: {type}", GetType().Name);
    }

    public virtual void OnDisappeared()
    {
        _logger.LogDebug("OnDisappeared: {type}", GetType().Name);
    }
}