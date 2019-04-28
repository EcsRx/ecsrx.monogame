using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EcsRx.MonoGame.Wrappers
{
    public interface IEcsRxGraphicsDevice
    {
        GraphicsDevice InternalDevice { get; }
        
        void Clear(Color color);
        void Clear(ClearOptions options, Color color, float depth, int stencil);
        void Clear(ClearOptions options, Vector4 color, float depth, int stencil);
        void Dispose();
        void Present();
        void Reset();
        void Reset(PresentationParameters presentationParameters);
        void SetRenderTarget(RenderTarget2D renderTarget);
        void SetRenderTarget(RenderTargetCube renderTarget, CubeMapFace cubeMapFace);
        void SetRenderTargets(params RenderTargetBinding[] renderTargets);
        RenderTargetBinding[] GetRenderTargets();
        void GetRenderTargets(RenderTargetBinding[] outTargets);
        void SetVertexBuffer(VertexBuffer vertexBuffer);
        void SetVertexBuffer(VertexBuffer vertexBuffer, int vertexOffset);
        void SetVertexBuffers(params VertexBufferBinding[] vertexBuffers);
        void DrawIndexedPrimitives(PrimitiveType primitiveType, int baseVertex, int minVertexIndex, int numVertices, int startIndex, int primitiveCount);
        void DrawIndexedPrimitives(PrimitiveType primitiveType, int baseVertex, int startIndex, int primitiveCount);
        void DrawUserPrimitives<T>(PrimitiveType primitiveType, T[] vertexData, int vertexOffset, int primitiveCount) where T : struct, IVertexType;
        void DrawUserPrimitives<T>(PrimitiveType primitiveType, T[] vertexData, int vertexOffset, int primitiveCount, VertexDeclaration vertexDeclaration) where T : struct;
        void DrawPrimitives(PrimitiveType primitiveType, int vertexStart, int primitiveCount);
        void DrawUserIndexedPrimitives<T>(PrimitiveType primitiveType, T[] vertexData, int vertexOffset, int numVertices, short[] indexData, int indexOffset, int primitiveCount) where T : struct, IVertexType;
        void DrawUserIndexedPrimitives<T>(PrimitiveType primitiveType, T[] vertexData, int vertexOffset, int numVertices, short[] indexData, int indexOffset, int primitiveCount, VertexDeclaration vertexDeclaration) where T : struct;
        void DrawUserIndexedPrimitives<T>(PrimitiveType primitiveType, T[] vertexData, int vertexOffset, int numVertices, int[] indexData, int indexOffset, int primitiveCount) where T : struct, IVertexType;
        void DrawUserIndexedPrimitives<T>(PrimitiveType primitiveType, T[] vertexData, int vertexOffset, int numVertices, int[] indexData, int indexOffset, int primitiveCount, VertexDeclaration vertexDeclaration) where T : struct;
        void DrawInstancedPrimitives(PrimitiveType primitiveType, int baseVertex, int minVertexIndex, int numVertices, int startIndex, int primitiveCount, int instanceCount);
        void DrawInstancedPrimitives(PrimitiveType primitiveType, int baseVertex, int startIndex, int primitiveCount, int instanceCount);
        void GetBackBufferData<T>(T[] data) where T : struct;
        void GetBackBufferData<T>(T[] data, int startIndex, int elementCount) where T : struct;
        void GetBackBufferData<T>(Rectangle? rect, T[] data, int startIndex, int elementCount) where T : struct;
        void PlatformClear(ClearOptions options, Vector4 color, float depth, int stencil);
        void PlatformPresent();
        TextureCollection VertexTextures { get; }
        SamplerStateCollection VertexSamplerStates { get; }
        TextureCollection Textures { get; }
        SamplerStateCollection SamplerStates { get; }
        bool IsDisposed { get; }
        bool IsContentLost { get; }
        GraphicsAdapter Adapter { get; }
        GraphicsMetrics Metrics { get; }
        GraphicsDebug GraphicsDebug { get; }
        RasterizerState RasterizerState { get; }
        Color BlendFactor { get; set; }
        BlendState BlendState { get; set; }
        DepthStencilState DepthStencilState { get; set; }
        DisplayMode DisplayMode { get; }
        GraphicsDeviceStatus GraphicsDeviceStatus { get; }
        PresentationParameters PresentationParameters { get; }
        Viewport Viewport { get; set; }
        GraphicsProfile GraphicsProfile { get; }
        Rectangle ScissorRectangle { get; set; }
        int RenderTargetCount { get; }
        IndexBuffer Indices { get; set; }
        bool ResourcesLost { get; }
    }
}