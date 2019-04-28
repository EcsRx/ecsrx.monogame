using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace EcsRx.MonoGame.Rendering
{
    public interface IRenderTargetRegistry<T> where T : class, IDisposable
    {
        IEnumerable<T> GetAllRenderTargets();
        T GetRenderTarget(int id);
        void RegisterRenderTarget(int id, T renderTarget);
        void RemoveRenderTarget(int id);
    }

    public interface IRenderTarget2dRegistry : IRenderTargetRegistry<RenderTarget2D>
    {
        RenderTarget2D CreateRenderTarget(int id, int width, int height, 
            bool mipmap = false, SurfaceFormat surfaceFormat = SurfaceFormat.Color, DepthFormat depthFormat = DepthFormat.Depth24);
    }

    public interface IRenderTargetCubeRegistry : IRenderTargetRegistry<RenderTargetCube>
    {
        RenderTargetCube CreateRenderTarget(int id, int size, 
            bool mipmap = false, SurfaceFormat surfaceFormat = SurfaceFormat.Color, DepthFormat depthFormat = DepthFormat.Depth24);
    }
}