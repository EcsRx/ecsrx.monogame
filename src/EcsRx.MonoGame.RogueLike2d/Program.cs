using System;

namespace EcsRx.MonoGame.RogueLike2d
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            //using (var game = new Game1())
            //    game.Run();

            using(new DemoApplication()){}
        }
    }
}
