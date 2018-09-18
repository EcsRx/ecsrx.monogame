using System;
using Microsoft.Xna.Framework.Content;

namespace EcsRx.MonoGame.Wrappers
{
    public interface IEcsRxContentManager
    {
        ContentManager InternalManager { get; }
        
        void Dispose();
        T LoadLocalized<T>(string assetName);
        T Load<T>(string assetName);
        void Unload();
        string RootDirectory { get; set; }
        IServiceProvider ServiceProvider { get; }
    }
}