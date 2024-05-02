using System;
using System.Numerics;

namespace EcsRx.MonoGame.Examples.Asteroids.Extensions;

public static class VectorExtensions
{
    public static float ToAngle(this Vector2 vector)
    { return MathF.Atan2(vector.Y, vector.X) * (180.0f / MathF.PI); }
}