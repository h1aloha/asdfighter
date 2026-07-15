# asdfighter

Un juego de lucha 2D hecho en Unity, desarrollado como proyecto personal de aprendizaje.

*English: [README.md](README.md)*

> **Estado:** en desarrollo (v0.0.1) — solo modo jugador contra jugador local.

## Sobre el proyecto

`asdfighter` es un proyecto hobby nacido del interés por aprender Unity 2D y entender cómo
funciona por dentro el género de lucha: frame data, hitstun, blockstun, hitboxes y gestión de
rondas. No es un producto comercial ni tiene planes de publicación.

Su mecánica diferencial es el **sistema de bloqueo**: en lugar de una barra de vida clásica con
chip damage, cada jugador empieza con **3 escudos** y **2 puntos de vida**. Bloquear un ataque
consume un escudo en vez de vida. Cuando te quedas sin escudos pasas a ser vulnerable — pero
también desbloqueas tu proyectil especial, así que quedarse sin defensa es un intercambio de
riesgo/recompensa, no solo un castigo.

## Funcionalidades implementadas

- **Modo versus local (JcJ)** — dos jugadores en el mismo teclado, gana el primero en llevarse 2 rondas.
- **Movimiento y bloqueo** — se bloquea manteniendo atrás, como en los arcade clásicos.
- **Tres ataques normales** — bajo, medio y fuerte, según la dirección que mantengas al atacar.
- **Proyectil especial ("kame"/hadouken)** — solo utilizable cuando has gastado todos los escudos.
- **Stun por frames** — el hitstun y el blockstun se definen en frames a 60fps, por hitbox.
- **Sistema de rondas** — detección de KO, carteles de ganador, poses de victoria aleatorias y revancha.
- **Racha de victorias** — se conserva entre sesiones mediante `PlayerPrefs`.
- **Nombres de jugador** — personalizables desde el menú principal y mostrados en el HUD.
- **Menú principal** — lista de movimientos, ajustes de audio (buses separados de SE/Música),
  opciones de vídeo y post-procesado.

## Pendiente / hoja de ruta

- El temporizador de ronda (`Temp.cs`) cuenta atrás pero todavía no resuelve la ronda al llegar a cero.
- No hay IA ni modo un jugador — el versus es solo local.
- `Player1.cs` y `Player2.cs` son duplicados casi idénticos; deberían unificarse en una clase base
  común con una capa de mapeo de controles.
- El final de partida lleva a la revancha; `TerminarPartida()` (volver al menú principal) sigue comentado.
- Sin soporte de mando — solo teclado.

## Controles

| Acción | Jugador 1 | Jugador 2 |
| --- | --- | --- |
| Avanzar | `D` | `←` |
| Retroceder / Bloquear | `A` | `→` |
| Ataque | `G` | `Numpad 2` |
| Proyectil | `H` | `Numpad 3` |

La dirección que mantengas determina el ataque: atrás da el ataque bajo, adelante da el ataque
fuerte, y neutral da el ataque medio.

## Requisitos

- **Unity 2021.3.25f1** (LTS)
- Built-in Render Pipeline con el paquete Post Processing (v3.2.2)
- TextMesh Pro, paquete 2D Feature de Unity

## Cómo empezar

```bash
git clone <url-del-repo>
```

Abre la carpeta del proyecto desde Unity Hub con la versión de editor 2021.3.25f1, abre
`Assets/Scenes/MenuPrincipal.unity` y dale a Play.

## Estructura del proyecto

```
Assets/
  Scenes/       MenuPrincipal, JcJ (la escena de combate)
  Scripts/
    Player1/    Player1, Attack1, Hitbox1, Kame1
    Player2/    Player2, Attack2, Hitbox2, Kame2
    Manager.cs  Rondas, KO, rachas de victorias, revancha
    ...         menús, temporizador, audio, post-procesado
  Animation/    Controladores de animación y clips por luchador
  Images/       Sprites y arte de UI
  Sounds/       Música chiptune y efectos de sonido
  Prefabs/      Prefabs de proyectiles
```

## Assets y licencias

⚠️ **Los sprites de personaje y el arte del escenario en `Assets/Images/ken/` son assets
placeholder propiedad de Capcom** (Ken y el escenario de Vega de *Street Fighter II*). Se usan
aquí estrictamente como sustitutos temporales dentro de un proyecto personal, educativo y sin
ánimo de lucro, y **no** están cubiertos por la licencia de este repositorio. Deberían
sustituirse por arte original antes de que este proyecto pudiera distribuirse públicamente.

Los efectos de sonido y la música son pistas chiptune de bibliotecas de assets gratuitas.

El **código fuente** de `Assets/Scripts/` es trabajo original.
