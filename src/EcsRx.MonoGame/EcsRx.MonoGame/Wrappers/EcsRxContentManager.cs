using System;
using Microsoft.Xna.Framework.Content;

namespace EcsRx.MonoGame.Wrappers
{
    public class EcsRxContentManager : IContentManager
    {
        private readonly ContentManager _internalManager;

        public EcsRxContentManager(ContentManager internalManager)
        { _internalManager = internalManager; }


        public void Dispose() =>_internalManager.Dispose();
        public T LoadLocalized<T>(string assetName) => _internalManager.LoadLocalized<T>(assetName);
        public T Load<T>(string assetName) => _internalManager.Load<T>(assetName);
        public void Unload() => _internalManager.Unload();

        public string RootDirectory
        {
            get => _internalManager.RootDirectory;
            set => _internalManager.RootDirectory = value;
        }

        public IServiceProvider ServiceProvider => _internalManager.ServiceProvider;
    }
}