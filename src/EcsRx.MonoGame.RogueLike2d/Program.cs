using EcsRx.MonoGame.RogueLike2d.Game;

// We do not need the underlying Game object as we wrap it with an application
using var game = new DemoApplication();
game.StartApplication();
