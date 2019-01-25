using System;
using EcsRx.MonoGame.RogueLike2d.Game;

namespace EcsRx.MonoGame.RogueLike2d
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            // No longer need this, as we use applications with EcsRx
            //using (var game = new Game1()) { game.Run(); }

            using(new DemoApplication()){}
        }
    }
}
