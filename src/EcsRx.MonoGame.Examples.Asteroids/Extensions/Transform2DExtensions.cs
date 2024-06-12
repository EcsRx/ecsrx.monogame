using System;
using EcsRx.MonoGame.Examples.Asteroids.Game.Components;
using Microsoft.Xna.Framework;
using SystemsRx.Plugins.Transforms.Extensions;
using SystemsRx.Plugins.Transforms.Models;
using Vector2 = System.Numerics.Vector2;

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

    public static float MGGetLookAt(this Transform2D transform, Vector2 target)
    {
        // This may look odd, but in MG apparently 0 rotation should be pointing right not up and its Y negative to move up
        // with this in mind we offset the outputted rotation by 90 degrees (in radians) to make it work correctly
        return transform.GetLookAt(target, 1.5708f);
    }
}