# EcsRx.Monogame

This is the Monogame flavour of EcsRx!

[![License][license-image]][license-url]
[![Nuget Version][nuget-image]][nuget-url]
[![Join Discord Chat][discord-image]][discord-url]
[![Documentation][gitbook-image]][gitbook-url]

[nuget-image]: https://img.shields.io/nuget/v/ecsrx.monogame.svg
[nuget-url]: https://www.nuget.org/packages/EcsRx/
[discord-image]: https://img.shields.io/discord/488609938399297536.svg
[discord-url]: https://discord.gg/bS2rnGz
[license-image]: https://img.shields.io/github/license/ecsrx/ecsrx.monogame.svg
[license-url]: https://github.com/EcsRx/ecsrx.monogame/blob/master/LICENSE
[gitbook-image]: https://img.shields.io/static/v1.svg?label=Documentation&message=Read%20Now&color=Green&style=flat
[gitbook-url]: https://ecsrx.gitbook.io/project/

## What is it?

It is an ECS style framework which puts architecture, design and flexibility above most other concerns.

It builds on top of the existing [EcsRx](https://github.com/EcsRx/ecsrx) framework and adds conventions and bootstrappers for Monogame specific scenarios.

## Getting started

As with all EcsRx engine integrations you will need to create your own application instance (`EcsRxMonoGameApplication`), and then you just use that instead of your normal `Game` instance, like so:

```c#
static void Main()
{
	// No longer need this, as we use applications with EcsRx
	//using (var game = new Game1()) { game.Run(); }

	using(new DemoApplication()){}
}
```

### WHAT HAVE YOU DONE WITH MY `Game`

There is still a `Game` instance under the hood, but we abstract it away, so in almost all scenarios you wont need to touch the game as you will treat the `Application` as your entry point.

## Docs

There is a book available which covers the main parts for the core EcsRx framework which can be found here:

[![Documentation][gitbook-image]][gitbook-url]

Will add monogame specific documentation within this repo as time goes on, but for the moment hop on discord to know more.

There is also a demo application within the `Roguelike2d` folder (its not a roguelike2d example, it is just a placeholder).
