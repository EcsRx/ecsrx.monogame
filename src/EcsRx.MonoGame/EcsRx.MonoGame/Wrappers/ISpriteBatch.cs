using System;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EcsRx.MonoGame.Wrappers
{
    public interface ISpriteBatch
    {
        void Begin(SpriteSortMode sortMode, BlendState blendState, SamplerState samplerState, DepthStencilState depthStencilState, RasterizerState rasterizerState, Effect effect, Matrix? transformMatrix);
        void End();
        void Draw(Texture2D texture, Vector2? position, Rectangle? destinationRectangle, Rectangle? sourceRectangle, Vector2? origin, float rotation, Vector2? scale, Color? color, SpriteEffects effects, float layerDepth);
        void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth);
        void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth);
        void Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, SpriteEffects effects, float layerDepth);
        void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color);
        void Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color);
        void Draw(Texture2D texture, Vector2 position, Color color);
        void Draw(Texture2D texture, Rectangle destinationRectangle, Color color);
        void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color);
        void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth);
        void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth);
        void DrawString(SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color);
        void DrawString(SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth);
        void DrawString(SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth);
        void Dispose();
        string ToString();
        GraphicsDevice GraphicsDevice { get; }
        bool IsDisposed { get; }
        string Name { get; set; }
        object Tag { get; set; }
        event EventHandler<EventArgs> Disposing;
    }
}