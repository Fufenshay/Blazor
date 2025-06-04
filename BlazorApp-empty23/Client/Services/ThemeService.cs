using Microsoft.JSInterop;
namespace Client.Services;

public class ThemeService
{
    private readonly IJSRuntime _jsRuntime;
    public bool IsDarkMode { get; private set; }
    public event Action? OnChange;

    public ThemeService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task InitializeAsync()
    {
        IsDarkMode = await _jsRuntime.InvokeAsync<bool>("getThemePreference");
        await ApplyThemeAsync();
    }

    public async Task ToggleThemeAsync()
    {
        IsDarkMode = !IsDarkMode;
        await ApplyThemeAsync();
        OnChange?.Invoke();
    }

    private async Task ApplyThemeAsync()
    {
        var theme = IsDarkMode ? "dark-theme" : "light-theme";
        await _jsRuntime.InvokeVoidAsync("setTheme", theme);
    }
}