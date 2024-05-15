# EcsRx.Monogame Examples - Asteroids

This is just a simple clone of an asteroids style game that shows how you can use EcsRx and Monogame together.

The overall design uses most of the common types of systems with some more advanced usages of other plugins such as the `Computed` and `Transform` ones.

## High Level Overview

We have the basic `Program.cs` which acts as our entry point, then from there we instantiate our `Application`. In this case we have the `AsteroidsApplication` which can be found within the `Game` folder.

You may be thinking why do we have a `Game` folder, and the reason is that you may have multiple `Application` classes, that represent different parts of your game, like you may have a `MainMenu` application which transfers to the `Game` application.

> Which is originally what was going to happen here, but I thought it would be simpler to just do the basics and leave out 2 player modes and main menus.

The `Application` inherits from the `EcsRxMonoGameApplication` and then adds in any dependencies and setup logic, in this case setting up a single ship for the player using `Blueprints`.

> You can find out more about `Blueprints` and other bits of the core framework by reading the EcsRx docs.

This then bootstraps any `ISystem` implementations it can find in the `Systems` folder within the namespace of the application, which then will start the game logic running.

Finally the systems will spawn in randomly places asteroids, which are setup and moved by various systems, they also track the input and relay that on for other systems to use for movement and rotational logic etc.

> Its worth noting that collision detection has been implementing in the most basic way to keep things simple, as in other frameworks/engines its built into the engine layer, but here we represent it via simple rectangles that we keep updated in a `ComputedCollecion` based off the underlying group so it stays in sync.


## HALP! I DONT UNDERSTAND

No worries, we have a helpful discord group who would be happy to answer any questions.