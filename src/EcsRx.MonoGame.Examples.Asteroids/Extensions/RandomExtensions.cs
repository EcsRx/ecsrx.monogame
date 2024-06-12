using System;

namespace EcsRx.MonoGame.Examples.Asteroids.Extensions;

public static class RandomExtensions
{
    public static int IntCutoff = int.MaxValue / 2;
    
    public static bool NextBool(this Random random)
    { return random.Next() > IntCutoff; }
}