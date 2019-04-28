using System;
using System.Collections.Generic;
using EcsRx.MonoGame.Wrappers;

namespace EcsRx.MonoGame.Rendering
{
    public abstract class RenderTargetRegistry<T> : IRenderTargetRegistry<T>
        where T : class, IDisposable 
    {
        protected readonly Dictionary<int, T> _renderTargets = new Dictionary<int, T>();
        
        public IEcsRxGraphicsDevice GraphicsDevice { get; }

        protected RenderTargetRegistry(IEcsRxGraphicsDevice graphicsDevice)
        {
            GraphicsDevice = graphicsDevice;
        }

        public IEnumerable<T> GetAllRenderTargets() => _renderTargets.Values;
        public T GetRenderTarget(int id) => _renderTargets[id];
       
        public void RegisterRenderTarget(int id, T renderTarget)
        { _renderTargets.Add(id, renderTarget); }

        public void RemoveRenderTarget(int id)
        {
            var renderTarget = _renderTargets[id];
            renderTarget.Dispose();
            _renderTargets.Remove(id);
        }
    }
}