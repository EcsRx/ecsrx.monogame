using EcsRx.MonoGame.RogueLike2d.Game;

// We do not need the underlying Game object as we wrap it with an application
var game = new DemoApplication();
game.StopApplication();
game.Dispose();