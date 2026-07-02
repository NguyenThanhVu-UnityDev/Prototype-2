# Prototype 2

A polished 3D top-down survival prototype completed during the Unity Junior Programmer pathway. 

This project goes beyond the basic tutorial by introducing a decoupled, event-driven architecture to drastically reduce coupling, utilizing clean coding conventions, and organizing system states via singletons.

## What I Learned

### [Lesson 2.1 - Play Fetch](https://learn.unity.com/pathway/junior-programmer/unit/basic-gameplay/tutorial/lesson-2-1-play-fetch?version=6.0)

**New functionality**

- Project assets imported (including player, various animal models, and food projectiles).
- Player controller instantiated and positioned.
- Projectiles spawned from the player location on key inputs.

**New concepts & skills**

- **Project Setup & Asset Organization:** Importing external packages and grouping prefabs, materials, and scripts logically.
- **Prefab Management:** Editing instances of GameObjects in Prefab Edit Mode to ensure changes update globally.
- **Instantiate Method:** Using `Instantiate()` to spawn food projectiles dynamically at runtime.

### [Lesson 2.2 - Guard Dog](https://learn.unity.com/pathway/junior-programmer/unit/basic-gameplay/tutorial/2-2-prevent-screen-out-of-bounds?version=6.0)

**New functionality**

- **Boundary clamping:** Constrained player movement coordinates dynamically to prevent them from moving off-screen.
- **Clean cleanup routines:** Destroyed off-screen animals and food projectiles automatically to free up memory and prevent active GameObject leaks.

**New concepts & skills**

- **Independent Movement Scripts:** Writing generic, reusable translation components (like forward moving behaviors).
- **Out of Bounds Checkers:** Implementing threshold boundaries using absolute position metrics to clean up active objects.
- **Mathematical Clamping:** Restricting positional values to specific intervals using C# math bounds.

### [Lesson 2.3 - Spawn Manager](https://learn.unity.com/pathway/junior-programmer/unit/basic-gameplay/tutorial/2-3-randomly-spawn-animals?version=6.0)

**New functionality**

- **Spawn coordination:** Programmed a dedicated spawn manager to instantiate randomly selected animals at randomized horizontal points at the top of the scene.

**New concepts & skills**

- **Arrays & Indexing:** Storing multiple animal prefabs inside sequential array collections.
- **Random Range Generators:** Computing coordinates and prefab indexes dynamically using random number generators.
- **Timed Invocations:** Triggering spawns recursively on set intervals using methods like `InvokeRepeating`.

### [Lesson 2.4 - Collision Decisions](https://learn.unity.com/pathway/junior-programmer/unit/basic-gameplay/tutorial/2-4-collision-decisions?version=6.0)

**New functionality**

- **Physics-driven interactions:** Added Rigidbodies and Box Colliders to food projectiles and animal prefabs.
- **Collision resolution:** Animals get fed and disappear upon impact with food projectiles instead of passing through them.

**New concepts & skills**

- **Trigger Collisions:** Using `OnTriggerEnter` overrides to resolve physical overlaps without rigid rebound reactions.
- **Clean Object Deconstruction:** Understanding visual feedback and object life-cycles inside the physics pipeline.

## Extras & Enhancements

- **Decoupled Event-Driven System:** Replaced tight object coupling with clean static events (`UnityEvent` and `Action`). Components do not directly call other scripts; instead, they publish or subscribe to dedicated channel managers:
  - **`UIEvents`**: Handlers for interface updates (e.g., score modifications, life indicators).
  - **`GameEvents`**: Handlers for gameplay events (e.g., animal fed states, collision damage).
- **GameManager Singleton:** Structured core controllers (like the `GameManager`) as Singletons to supply a unified, clean global point of access without complicating scene-level script references.
- **C# Best Practices & Convention Cleanup:** Fixed standard pathway code templates by removing clutter, enforcing encapsulation, using correct access level modifiers, and splitting logic into single-responsibility classes.
