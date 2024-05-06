using System;
using EcsRx.MonoGame.Examples.Asteroids.Game.Components;
using Microsoft.Xna.Framework;
using SystemsRx.Plugins.Transforms.Models;

namespace EcsRx.MonoGame.Examples.Asteroids.Extensions;

public static class Transform2DExtensions
{
    public static Rectangle GetCollisionArea(this Transform2D transform, ColliderComponent collider)
    {
        return new Rectangle(
        (int)transform.Position.X, 
        (int)transform.Position.Y,
        (int)collider.Width, (int)collider.Height); 
    }
}