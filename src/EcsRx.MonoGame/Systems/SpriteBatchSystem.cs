using EcsRx.Entities;
using EcsRx.Groups;
using EcsRx.MonoGame.Wrappers;
using EcsRx.Systems;

namespace EcsRx.MonoGame.Systems;

public abstract class SpriteBatchSystem : IGroupSystem
{
    public abstract IGroup Group { get; }
        
    protected IEcsRxSpriteBatch EcsRxSpriteBatch { get; }

    protected SpriteBatchSystem(IEcsRxSpriteBatch ecsRxSpriteBatch)
    {
        EcsRxSpriteBatch = ecsRxSpriteBatch;
    }

    public virtual void PreDraw() { EcsRxSpriteBatch.Begin(); }
    public abstract void Process(IEntity entity);
    public virtual void PostDraw() { EcsRxSpriteBatch.End(); }
}