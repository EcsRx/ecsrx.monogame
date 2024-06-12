using EcsRx.MonoGame.Wrappers;
using Microsoft.Xna.Framework.Graphics;

namespace EcsRx.MonoGame.Rendering;

public class RenderTarget2dRegistry : RenderTargetRegistry<RenderTarget2D>, IRenderTarget2dRegistry
{
    public RenderTarget2D CreateRenderTarget(int id, int width, int height, bool mipmap, SurfaceFormat surfaceFormat, DepthFormat depthFormat)
    {
        var renderTarget = new RenderTarget2D(GraphicsDevice.InternalDevice, width, height, mipmap, surfaceFormat, depthFormat);
        _renderTargets.Add(id, renderTarget);
        return renderTarget;
    }

    public RenderTarget2dRegistry(IEcsRxGraphicsDevice graphicsDevice) : base(graphicsDevice)
    {}
}