# BetterDrops
[![Version](https://img.shields.io/github/v/release/MrAfitol/BetterDrops?sort=semver&style=flat-square&color=blue&label=Version)](https://github.com/MrAfitol/BetterDrops/releases)
[![Downloads](https://img.shields.io/github/downloads/MrAfitol/BetterDrops/total?style=flat-square&color=yellow&label=Downloads)](https://github.com/MrAfitol/BetterDrops/releases)


Plugin to summon and spawn drops.

The original plugin for Exiled https://github.com/Jesus-QC/BetterDrops
## How download ?
   - *1. Find the SCP SL server config folder*
   
   *("C:\Users\(user name)\AppData\Roaming\SCP Secret Laboratory\" for windows, "/home/(user name)/.config/SCP Secret Laboratory/" for linux)*
  
   - *2. Find the "PluginAPI" folder there, it contains the "plugins" folder.*
  
   - *3. Select either the port of your server to install the same on that server or the "global" folder to install the plugin for all servers*
  
  ***Or***
  
   - *Run the command in console `p install MrAfitol/BetterDrops`*
## View
https://user-images.githubusercontent.com/76150070/210635510-aacb7c2f-f651-4f00-abcb-7b74900faa22.mp4

## Config
```yml
# How long to wait before drops open themselves
auto_open: 15
# The configs of the MTF drop waves.
mtf_drop_wave:
# Is the drop wave enabled.
  is_enabled: true
  # Number of drops in the spawn wave.
  number_of_drops: 5
  # Items per drop, I suggest low values, if you do stupid things with this config it is your fault.
  items_per_drop: 1
  # Drop color. (It accepts Random or hex values like '#ffffff')
  color: Random
  # Cassie message on spawn drop. (Leave blank to disable)
  cassie: pitch_0.2 .g4... pitch_1 Supply jam_020_2 has been arrival
  # Will the gun have a full ammo?
  fill_max_ammo: true
  # Will the gun have a random attachments?
  random_attachments: true
  # The possible items inside the drop
  possible_items:
  - Adrenaline
  - Coin
  - Medkit
  - GrenadeFlash
  - GrenadeHE
  - Radio
  - Painkillers
  - ArmorCombat
  - ArmorHeavy
  - ArmorLight
  - GunRevolver
  - GunShotgun
  - GunAK
  - GunCOM15
  - GunFSP9
  - GunE11SR
# The configs of the Chaos drop waves.
chaos_drop_wave:
# Is the drop wave enabled.
  is_enabled: true
  # Number of drops in the spawn wave.
  number_of_drops: 5
  # Items per drop, I suggest low values, if you do stupid things with this config it is your fault.
  items_per_drop: 1
  # Drop color. (It accepts Random or hex values like '#ffffff')
  color: Random
  # Cassie message on spawn drop. (Leave blank to disable)
  cassie: pitch_0.2 .g4... pitch_1 Supply jam_020_2 has been arrival
  # Will the gun have a full ammo?
  fill_max_ammo: true
  # Will the gun have a random attachments?
  random_attachments: true
  # The possible items inside the drop
  possible_items:
  - Adrenaline
  - Coin
  - Medkit
  - GrenadeFlash
  - GrenadeHE
  - Radio
  - Painkillers
  - ArmorCombat
  - ArmorHeavy
  - ArmorLight
  - GunRevolver
  - GunShotgun
  - GunAK
  - GunCOM15
  - GunFSP9
  - GunE11SR
# The configs of random drops
random_drops:
# The minimum time that has to happen until the first random drop.
  first_random_drop_offset: 120
  # Minimum time between random drops.
  min_random_drops_interval: 120
  # Maximum time between random drops.
  max_random_drops_interval: 240
  # Random drop wave settings. (Here you can disable them)
  wave_settings:
  # Is the drop wave enabled.
    is_enabled: true
    # Number of drops in the spawn wave.
    number_of_drops: 5
    # Items per drop, I suggest low values, if you do stupid things with this config it is your fault.
    items_per_drop: 1
    # Drop color. (It accepts Random or hex values like '#ffffff')
    color: Random
    # Cassie message on spawn drop. (Leave blank to disable)
    cassie: pitch_0.2 .g4... pitch_1 Supply jam_020_2 has been arrival
    # Will the gun have a full ammo?
    fill_max_ammo: true
    # Will the gun have a random attachments?
    random_attachments: true
    # The possible items inside the drop
    possible_items:
    - Adrenaline
    - Coin
    - Medkit
    - GrenadeFlash
    - GrenadeHE
    - Radio
    - Painkillers
    - ArmorCombat
    - ArmorHeavy
    - ArmorLight
    - GunRevolver
    - GunShotgun
    - GunAK
    - GunCOM15
    - GunFSP9
    - GunE11SR
```
