using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EcsRx.MonoGame.Wrappers;

public class EcsRxGraphicsDevice : IEcsRxGraphicsDevice
{
    public GraphicsDevice InternalDevice { get; }
        
    public EcsRxGraphicsDevice(GraphicsDevice internalDevice)
    {
        InternalDevice = internalDevice;
    }
        
    public void Clear(Color color)
    {
        InternalDevice.Clear(color);
    }

    public void Clear(ClearOptions options, Color color, float depth, int stencil)
    {
        InternalDevice.Clear(options, color, depth, stencil);
    }

    public void Clear(ClearOptions options, Vector4 color, float depth, int stencil)
    {
        InternalDevice.Clear(options, color, depth, stencil);
    }

    public void Dispose()
    {
        InternalDevice.Dispose();
    }

    public void Present()
    {
        InternalDevice.Present();
    }

    public void Reset()
    {
        InternalDevice.Reset();
    }

    public void Reset(PresentationParameters presentationParameters)
    {
        InternalDevice.Reset(presentationParameters);
    }

    public void SetRenderTarget(RenderTarget2D renderTarget)
    {
        InternalDevice.SetRenderTarget(renderTarget);
    }

    public void SetRenderTarget(RenderTargetCube renderTarget, CubeMapFace cubeMapFace)
    {
        InternalDevice.SetRenderTarget(renderTarget, cubeMapFace);
    }

    public void SetRenderTargets(params RenderTargetBinding[] renderTargets)
    {
        InternalDevice.SetRenderTargets(renderTargets);
    }

    public RenderTargetBinding[] GetRenderTargets()
    {
        return InternalDevice.GetRenderTargets();
    }

    public void GetRenderTargets(RenderTargetBinding[] outTargets)
    {
        InternalDevice.GetRenderTargets(outTargets);
    }

    public void SetVertexBuffer(VertexBuffer vertexBuffer)
    {
        InternalDevice.SetVertexBuffer(vertexBuffer);
    }

    public void SetVertexBuffer(VertexBuffer vertexBuffer, int vertexOffset)
    {
        InternalDevice.SetVertexBuffer(vertexBuffer, vertexOffset);
    }

    public void SetVertexBuffers(params VertexBufferBinding[] vertexBuffers)
    {
        InternalDevice.SetVertexBuffers(vertexBuffers);
    }

    public void DrawIndexedPrimitives(PrimitiveType primitiveType, int baseVertex, int minVertexIndex, int numVertices,
        int startIndex, int primitiveCount)
    {
        InternalDevice.DrawIndexedPrimitives(primitiveType, baseVertex, minVertexIndex, numVertices, startIndex, primitiveCount);
    }

    public void DrawIndexedPrimitives(PrimitiveType primitiveType, int baseVertex, int startIndex, int primitiveCount)
    {
        InternalDevice.DrawIndexedPrimitives(primitiveType, baseVertex, startIndex, primitiveCount);
    }

    public void DrawUserPrimitives<T>(PrimitiveType primitiveType, T[] vertexData, int vertexOffset, int primitiveCount) where T : struct, IVertexType
    {
        InternalDevice.DrawUserPrimitives(primitiveType, vertexData, vertexOffset, primitiveCount);
    }

    public void DrawUserPrimitives<T>(PrimitiveType primitiveType, T[] vertexData, int vertexOffset, int primitiveCount,
        VertexDeclaration vertexDeclaration) where T : struct
    {
        InternalDevice.DrawUserPrimitives(primitiveType, vertexData, vertexOffset, primitiveCount, vertexDeclaration);
    }

    public void DrawPrimitives(PrimitiveType primitiveType, int vertexStart, int primitiveCount)
    {
        InternalDevice.DrawPrimitives(primitiveType, vertexStart, primitiveCount);
    }

    public void DrawUserIndexedPrimitives<T>(PrimitiveType primitiveType, T[] vertexData, int vertexOffset, int numVertices,
        short[] indexData, int indexOffset, int primitiveCount) where T : struct, IVertexType
    {
        InternalDevice.DrawUserIndexedPrimitives(primitiveType, vertexData, vertexOffset, numVertices, indexData, indexOffset, primitiveCount);
    }

    public void DrawUserIndexedPrimitives<T>(PrimitiveType primitiveType, T[] vertexData, int vertexOffset, int numVertices,
        short[] indexData, int indexOffset, int primitiveCount, VertexDeclaration vertexDeclaration) where T : struct
    {
        InternalDevice.DrawUserIndexedPrimitives(primitiveType, vertexData, vertexOffset, numVertices, indexData, indexOffset, primitiveCount, vertexDeclaration);
    }

    public void DrawUserIndexedPrimitives<T>(PrimitiveType primitiveType, T[] vertexData, int vertexOffset, int numVertices,
        int[] indexData, int indexOffset, int primitiveCount) where T : struct, IVertexType
    {
        InternalDevice.DrawUserIndexedPrimitives(primitiveType, vertexData, vertexOffset, numVertices, indexData, indexOffset, primitiveCount);
    }

    public void DrawUserIndexedPrimitives<T>(PrimitiveType primitiveType, T[] vertexData, int vertexOffset, int numVertices,
        int[] indexData, int indexOffset, int primitiveCount, VertexDeclaration vertexDeclaration) where T : struct
    {
        InternalDevice.DrawUserIndexedPrimitives(primitiveType, vertexData, vertexOffset, numVertices, indexData, indexOffset, primitiveCount, vertexDeclaration);
    }

    public void DrawInstancedPrimitives(PrimitiveType primitiveType, int baseVertex, int minVertexIndex, int numVertices,
        int startIndex, int primitiveCount, int instanceCount)
    {
        InternalDevice.DrawInstancedPrimitives(primitiveType, baseVertex, minVertexIndex, numVertices, startIndex, primitiveCount, instanceCount);
    }

    public void DrawInstancedPrimitives(PrimitiveType primitiveType, int baseVertex, int startIndex, int primitiveCount,
        int instanceCount)
    {
        InternalDevice.DrawInstancedPrimitives(primitiveType, baseVertex, startIndex, primitiveCount, instanceCount);
    }

    public void DrawInstancedPrimitives(PrimitiveType primitiveType, int baseVertex, int startIndex, int primitiveCount,
        int baseInstance, int instanceCount)
    {
        InternalDevice.DrawInstancedPrimitives(primitiveType, baseVertex, startIndex, primitiveCount, baseInstance, instanceCount);
    }

    public void GetBackBufferData<T>(T[] data) where T : struct
    {
        InternalDevice.GetBackBufferData(data);
    }

    public void GetBackBufferData<T>(T[] data, int startIndex, int elementCount) where T : struct
    {
        InternalDevice.GetBackBufferData(data, startIndex, elementCount);
    }

    public void GetBackBufferData<T>(Rectangle? rect, T[] data, int startIndex, int elementCount) where T : struct
    {
        InternalDevice.GetBackBufferData(rect, data, startIndex, elementCount);
    }

    public bool UseHalfPixelOffset => InternalDevice.UseHalfPixelOffset;
    public TextureCollection VertexTextures => InternalDevice.VertexTextures;
    public SamplerStateCollection VertexSamplerStates => InternalDevice.VertexSamplerStates;
    public TextureCollection Textures => InternalDevice.Textures;
    public SamplerStateCollection SamplerStates => InternalDevice.SamplerStates;
    public bool IsDisposed => InternalDevice.IsDisposed;
    public bool IsContentLost => InternalDevice.IsContentLost;
    public GraphicsAdapter Adapter => InternalDevice.Adapter;

    public GraphicsMetrics Metrics
    {
        get => InternalDevice.Metrics;
        set => InternalDevice.Metrics = value;
    }

    public GraphicsDebug GraphicsDebug
    {
        get => InternalDevice.GraphicsDebug;
        set => InternalDevice.GraphicsDebug = value;
    }

    public RasterizerState RasterizerState
    {
        get => InternalDevice.RasterizerState;
        set => InternalDevice.RasterizerState = value;
    }

    public Color BlendFactor
    {
        get => InternalDevice.BlendFactor;
        set => InternalDevice.BlendFactor = value;
    }

    public BlendState BlendState
    {
        get => InternalDevice.BlendState;
        set => InternalDevice.BlendState = value;
    }

    public DepthStencilState DepthStencilState
    {
        get => InternalDevice.DepthStencilState;
        set => InternalDevice.DepthStencilState = value;
    }

    public DisplayMode DisplayMode => InternalDevice.DisplayMode;

    public GraphicsDeviceStatus GraphicsDeviceStatus => InternalDevice.GraphicsDeviceStatus;

    public PresentationParameters PresentationParameters => InternalDevice.PresentationParameters;

    public Viewport Viewport
    {
        get => InternalDevice.Viewport;
        set => InternalDevice.Viewport = value;
    }

    public GraphicsProfile GraphicsProfile => InternalDevice.GraphicsProfile;

    public Rectangle ScissorRectangle
    {
        get => InternalDevice.ScissorRectangle;
        set => InternalDevice.ScissorRectangle = value;
    }

    public int RenderTargetCount => InternalDevice.RenderTargetCount;

    public IndexBuffer Indices
    {
        get => InternalDevice.Indices;
        set => InternalDevice.Indices = value;
    }

    public bool ResourcesLost
    {
        get => InternalDevice.ResourcesLost;
        set => InternalDevice.ResourcesLost = value;
    }

    public event EventHandler<EventArgs> DeviceLost
    {
        add => InternalDevice.DeviceLost += value;
        remove => InternalDevice.DeviceLost -= value;
    }

    public event EventHandler<EventArgs> DeviceReset
    {
        add => InternalDevice.DeviceReset += value;
        remove => InternalDevice.DeviceReset -= value;
    }

    public event EventHandler<EventArgs> DeviceResetting
    {
        add => InternalDevice.DeviceResetting += value;
        remove => InternalDevice.DeviceResetting -= value;
    }

    public event EventHandler<ResourceCreatedEventArgs> ResourceCreated
    {
        add => InternalDevice.ResourceCreated += value;
        remove => InternalDevice.ResourceCreated -= value;
    }

    public event EventHandler<ResourceDestroyedEventArgs> ResourceDestroyed
    {
        add => InternalDevice.ResourceDestroyed += value;
        remove => InternalDevice.ResourceDestroyed -= value;
    }

    public event EventHandler<EventArgs> Disposing
    {
        add => InternalDevice.Disposing += value;
        remove => InternalDevice.Disposing -= value;
    }

}