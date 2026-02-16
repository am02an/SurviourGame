# Survivor Style Game – README

## 📌 Project Overview

This project is a Survivor-style action game built in Unity. The player fights continuously spawning enemies, collects gems to level up, collects coins and health pickups, and unlocks skill upgrades.

The architecture is fully event-driven to keep gameplay systems modular and scalable.

---

# 🎮 Core Gameplay Flow

## ▶️ Game Start

1. Player spawns with default stats.
2. Enemy spawners start generating enemies.
3. Player automatically attacks enemies.
4. Gems, coins, and health pickups drop from enemies.

---

## 💎 Gem Collection & Level Up Flow

### Gem Collection

* Player collects gems dropped from enemies.
* Each gem increases the current gem counter.
* UI is updated through event notification.

### Level Up Trigger

When:

```
Current Gems >= Gems Required
```

Then:

* Level progression is triggered.

---

## 💰 Coin Collection Flow

* Coins are dropped during gameplay.
* Coins increase player currency.
* Currency is intended for meta progression (future feature).

---

## ❤️ Health Pickup Flow

* Health pickup restores player health by percentage.
* Health change is communicated through events.

---

## 💀 Player Death Flow

### When Player Health Reaches Zero

1. Death event is triggered.
2. Death panel is displayed.
3. Gameplay pauses.
4. After 3 seconds:

   * Death panel closes
   * Game restart event triggers

---

## 🔄 Game Restart Flow

When restart event triggers:

### Reset Systems

* Player health
* Gem progress
* Coin counter
* Enemy pools
* Gem pools
* UI panels
* Game timers
* Time scale reset

The restart system uses global events to notify all systems.

---

# 🏗️ Architecture Overview

## Event Driven System

The game uses a centralized event system.

### Benefits

* Loose coupling between systems
* Easy feature expansion
* Cleaner restart logic
* Better scalability

---

# 📦 Object Pooling

## Enemy Pool

* Prevents frequent instantiation
* Improves performance
* Automatically expands if required

## Gem Pool

* Reuses gem objects
* Resets during game restart

---

# 🧩 Major Systems

## Player Systems

* Player Health
* Gem Collector
* Player Stats Handler

## Enemy Systems

* Enemy Spawner
* Enemy Movement
* Enemy Health

## UI Systems

* Kill Counter
* Coin Counter
* Death Panel

---

# 🔔 Game Event System

The game uses a static event dispatcher.

### Key Events

#### Player Events

* Health Changed
* Player Died
* Player Level Up
* Player Collected Gems
* Player Collected Coins
* Player Collected Health

#### Enemy Events

* Enemy Killed

#### Game State Events

* Game Restart

---

# 📊 UI Flow

## HUD

Displays:

* Health
* Kill Count
* Coin Count
* Gem Progress

## Skill Panel

Shows available upgrades.

(Currently under development)

## Death Panel

* Displays when player dies
* Automatically closes after delay

---

# ⚙️ Systems Currently Disabled / Under Development

## Meta Progression

Permanent player upgrades using coins not implemented.

## Revive System

Planned but not active.

---

# 🚀 Planned Future Features

* Meta progression shop
* Revive mechanic
* Stage progression
* Boss fights

---

# 🛠️ Developer Notes

### Restart Logic

All systems must subscribe to the restart event instead of directly resetting themselves.

### Pooling Rule

Objects must always return to pools instead of being destroyed.

### UI Rule

Gameplay systems should trigger events instead of directly modifying UI.

---

# 📁 Suggested Folder Structure

```
Scripts
 ┣ Core
 ┣ Player
 ┣ Enemy
 ┣ UI
 ┣ Pooling
 ┣ Events
 ┣ Systems
```

---

# 🧪 Testing Notes

Ensure testing of:

* Restart flow
* Pool reset behavior
* Death panel delay logic
* Gem level-up trigger

---

# 👨‍💻 Author Notes

This project focuses on scalable architecture and performance-friendly gameplay suitable for mobile and mid-core action games.

---

# 📄 License

Internal development use only.

---

# ✅ Current Game Status Summary

| System             | Status   |
| ------------------ | -------- |
| Combat             | Complete |
| Enemy Spawning     | Complete |
| Object Pooling     | Complete |
| Event Architecture | Complete |
| UI HUD             | Complete |
| Death System       | Complete |
| Restart System     | Complete |
| Meta Progression   | Planned  |

---

END OF DOCUMENT
