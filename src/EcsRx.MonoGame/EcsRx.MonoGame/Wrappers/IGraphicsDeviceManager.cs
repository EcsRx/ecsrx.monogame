using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EcsRx.MonoGame.Wrappers
{
    public interface IGraphicsDeviceManager
    {
        bool BeginDraw();
        void EndDraw();
        void Dispose();
        void ApplyChanges();
        void ToggleFullScreen();
        GraphicsProfile GraphicsProfile { get; set; }
        GraphicsDevice GraphicsDevice { get; }
        bool IsFullScreen { get; set; }
        bool HardwareModeSwitch { get; set; }
        bool PreferMultiSampling { get; set; }
        SurfaceFormat PreferredBackBufferFormat { get; set; }
        int PreferredBackBufferHeight { get; set; }
        int PreferredBackBufferWidth { get; set; }
        DepthFormat PreferredDepthStencilFormat { get; set; }
        bool SynchronizeWithVerticalRetrace { get; set; }
        DisplayOrientation SupportedOrientations { get; set; }
        event EventHandler<EventArgs> DeviceCreated;
        event EventHandler<EventArgs> DeviceDisposing;
        event EventHandler<EventArgs> DeviceReset;
        event EventHandler<EventArgs> DeviceResetting;
        event EventHandler<PreparingDeviceSettingsEventArgs> PreparingDeviceSettings;
        event EventHandler<EventArgs> Disposed;
    }
}