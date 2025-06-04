// Client/Services/ThemeService.cs
using Microsoft.JSInterop;

namespace Client.Services;

public class ThemeService
{
    private readonly IJSRuntime _jsRuntime;

    public bool IsDarkMode { get; private set; }
    public event Action? OnThemeChanged;

    public ThemeService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task ToggleThemeAsync()
    {
        IsDarkMode = !IsDarkMode;
        await ApplyThemeAsync();
        OnThemeChanged?.Invoke();
    }

    private async Task ApplyThemeAsync()
    {
        var theme = IsDarkMode ? "dark-theme" : "light-theme";
        await _jsRuntime.InvokeVoidAsync("setTheme", theme);
    }

    public async Task InitializeAsync()
    {
        // Загрузка сохраненной темы из localStorage
        IsDarkMode = await _jsRuntime.InvokeAsync<bool>("getThemePreference");
        await ApplyThemeAsync();
    }
}