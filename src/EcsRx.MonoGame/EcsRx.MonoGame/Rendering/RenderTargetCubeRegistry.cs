using System.Collections.Generic;
using EcsRx.MonoGame.Wrappers;
using Microsoft.Xna.Framework.Graphics;

namespace EcsRx.MonoGame.Rendering
{
    public class RenderTargetCubeRegistry : RenderTargetRegistry<RenderTargetCube>, IRenderTargetCubeRegistry
    {
        public RenderTargetCubeRegistry(IEcsRxGraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
        }
        
        public RenderTargetCube CreateRenderTarget(int id, int size, bool mipmap, SurfaceFormat surfaceFormat, DepthFormat depthFormat)
        {
            var renderTarget = new RenderTargetCube(GraphicsDevice.InternalDevice, size, mipmap, surfaceFormat, depthFormat);
            _renderTargets.Add(id, renderTarget);
            return renderTarget;
        }
    }
}