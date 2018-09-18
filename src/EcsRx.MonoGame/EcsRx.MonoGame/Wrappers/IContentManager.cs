using System;

namespace EcsRx.MonoGame.Wrappers
{
    public interface IContentManager
    {
        void Dispose();
        T LoadLocalized<T>(string assetName);
        T Load<T>(string assetName);
        void Unload();
        string RootDirectory { get; set; }
        IServiceProvider ServiceProvider { get; }
    }
}