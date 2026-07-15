# asdfighter

A 2D fighting game built in Unity, developed as a personal learning project.

*Español: [README.es.md](README.es.md)*

> **Status:** in development (v0.0.1) — local player-vs-player only.

## About

`asdfighter` is a hobby project born out of an interest in learning Unity 2D and understanding
how the fighting game genre works under the hood: frame data, hitstun, blockstun, hitboxes,
and round management. It is not a commercial product and has no release plans.

The core twist is its **block system**: instead of a traditional health bar with chip damage,
each player starts with **3 shields** and **2 health points**. Blocking an attack consumes a
shield rather than health. Once your shields are gone you become vulnerable — but you also
unlock your projectile special, so running out of defense is a risk/reward trade, not just a
punishment.

## Implemented features

- **Local versus mode (JcJ)** — two players on the same keyboard, first to 2 rounds wins.
- **Movement and blocking** — hold back to block, as in classic arcade fighters.
- **Three normal attacks** — low, mid, and heavy, selected by the direction you hold while attacking.
- **Projectile special ("kame"/hadouken)** — only usable once all shields are spent.
- **Frame-accurate stun** — hitstun and blockstun are defined in frames at 60fps, per hitbox.
- **Round system** — KO detection, winner banners, random victory poses, and rematch prompt.
- **Win streak tracking** — persisted between sessions via `PlayerPrefs`.
- **Player names** — custom names entered from the main menu, shown in the HUD.
- **Main menu** — move list, audio settings (separate SFX/Music mixer buses), video and
  post-processing options.

## Known gaps / roadmap

- The round timer (`Temp.cs`) counts down but does not yet resolve the round on timeout.
- No AI or single-player mode — versus is local only.
- `Player1.cs` and `Player2.cs` are near-identical duplicates; they should be unified into a
  shared base class with an input-mapping layer.
- Match-end flow returns to a rematch prompt; `TerminarPartida()` (return to main menu) is
  still commented out.
- No gamepad support — keyboard only.

## Controls

| Action | Player 1 | Player 2 |
| --- | --- | --- |
| Move forward | `D` | `←` |
| Move back / Block | `A` | `→` |
| Attack | `G` | `Numpad 2` |
| Projectile | `H` | `Numpad 3` |

Attack direction determines the move: holding back gives a low attack, holding forward gives
the heavy attack, and neutral gives the mid attack.

## Requirements

- **Unity 2021.3.25f1** (LTS)
- Built-in Render Pipeline with the Post Processing package (v3.2.2)
- TextMesh Pro, Unity 2D Feature set

## Getting started

```bash
git clone <repo-url>
```

Open the project folder with Unity Hub using editor version 2021.3.25f1, then open
`Assets/Scenes/MenuPrincipal.unity` and press Play.

## Project structure

```
Assets/
  Scenes/       MenuPrincipal, JcJ (the match scene)
  Scripts/
    Player1/    Player1, Attack1, Hitbox1, Kame1
    Player2/    Player2, Attack2, Hitbox2, Kame2
    Manager.cs  Rounds, KO, win streaks, rematch
    ...         menus, timer, audio, post-processing
  Animation/    Animator controllers and clips per fighter
  Images/       Sprites and UI art
  Sounds/       Chiptune music and SFX
  Prefabs/      Projectile prefabs
```

## Assets and licensing

⚠️ **The character sprites and stage art in `Assets/Images/ken/` are placeholder assets
belonging to Capcom** (Ken and the Vega stage from *Street Fighter II*). They are used here
strictly as temporary stand-ins for a personal, non-commercial learning project and are **not**
covered by this repository's license. They must be replaced with original art before this
project could ever be distributed publicly.

Sound effects and music are chiptune tracks from free asset libraries.

The **source code** in `Assets/Scripts/` is original work.
