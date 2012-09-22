using System;
namespace AntsX.Services
{
    public interface IViewportService
    {
        Microsoft.Xna.Framework.Graphics.Viewport MainView { get; }
        Microsoft.Xna.Framework.Graphics.Viewport RightSidebarView { get; }
        
        event AntsX.Services.ViewportService.ViewportChangedHandler MainViewChanged;
        event AntsX.Services.ViewportService.ViewportChangedHandler RightSidebarViewChanged;
    }
}
