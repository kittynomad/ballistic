----------------------
Use (Gameplay)
----------------------
Any scene with the ApplicationStarter prefab will load test scene for trying out the modular weapons system.

To modify your weapon, open the Assembly UI with the M key. Exit this menu by pressing the "Finish" button on this screen.
There are buttons to view each category of part (Frames, Magazines, Batteries, Muzzles, Addons).
When a category is selected, every part of that type will appear on the left hand side.
When you press the "Equip" button on a listed part, it will automatically replace the part of that type already on that weapon (Except for addons, which are added to the list of addons, or ignored if the weapon has max addons).
This menu also has a "Randomize" button, which will randomize every part on your weapon. This weapon may or may not be largely ineffective.

The scene loads without any NPCs. By stepping on a button on the opposite side of the room, a "Test Dummy" will spawn. It has no AI but can be attacked and affected by statuses. The button can be reused infinitely.

----------------------
Use (Editor)
----------------------
Weapon parts are defined in the ComponentDataService prefab. It can be found at Assets/Prefabs/Services/SaveDataServicePrefabs.

When opening this prefab, you can either edit parts directly in-editor, or export the database as a .json file to modify externally.
	To export the database, press one of two "Save Part Database" buttons on the Component Data Service component. "Internally" saves the file in the project's StreamingAssets folder, while "Externally" saves to your computer's persistent data path.
	Once edited, the file can be re-registered by using the proper "Load Part Database" button.

Fields used in part definition are explained below:

ALL PARTS
* ID - an integer used to identify a specific part. This should be a unique value. The convention I've been using is assigning factors of 10000 as the starting point for each category and iterating by 1 (i.e. frames are 00000, 00001, etc., batteries are 10000, 10001, etc.)
* itemName - the display name used by a part on UI. While this doesn't have to be unique, it probably should be to avoid confusion.
* itemDescription - a basic description of the part, used in the assembly screen.
* itemIconPath - the image used to display the part in 2D menus. Stored as a string of the directory, using Resources as the root folder.
* energyCost - the charge required from the weapon's battery to fire once with this component installed. all individual energy costs of all used parts are added for the total cost of firing an assembled weapon.
* modifiers - an array of all "mods" this part has.
* itemModelPath - The 3D model representing this part, used on the assembled weapon's combined model. Stored as a string of the directory, using Resources as the root folder.

FRAMES
* fireVelocity - The speed at which projectiles exit the weapon. 1 is considered "default".
* addonCapacity - the total amount of addons that can be attached to this frame.

BATTERIES
* capacity - the maximum "charge" that this battery can hold.
* rechargeRate - the rate at which the charge of the battery refills while not firing.

MAGAZINES
* damage - the base damage of projectiles fired by a weapon using this magazine.
* magSize - the amount of bullets which can be fired before reloading.
* reloadTime - the amount of time it takes to reload the weapon.
* timeBetweenShots - the amount of time after firing the weapon until it can be fired again-- i.e. fire rate.
* automaticFire - if true, the weapon will fire constantly while the trigger is held. if false, trigger must be pulled for each shot.

MUZZLES
* spread - the amount which a fired projectile may deviate from the target, in degrees. (this does not account for gravity).

----------------------
TO-DO
----------------------
* Allow player to be hit by projectiles and affected by status effects
* Ammunition
* Wider variety of status effects
* More legible UI
* More displayed stats for individual weapon parts
* Easier addon management (rearrange, remove specific ones)

----------------------
Known Issues
----------------------
* NPCs are not affected by gravity.
	* Currently, there's a lot of oddities with the physics/position of NPCS. This is likely due to how the ragdoll is set up. I need to learn more about how swapping to/from ragdolls is typically done to improve this behavior. This goes for many listed NPC quirks.

* NPCs may move to a slightly different position when returning from a ragdoll state.

* NPCs are immune to projectiles while in ragdoll form. Status effects applied before entering ragdoll state (i.e. damage over time) still function normally during this time.

* NPC "abdomens" are non-interactable.
	* This is largely due to the appendages being outside of the typical "bounds" of a humanoid. May remove the abdomen.

* Lighting on NPCs sometimes behaves strangely, especially in ragdoll form.

* Multiple stacks of paralysis do not stack properly.
	* This is due to status effects being applied as, essentially, isolated C# objects and working based on a passed in reference to the entity it's applying to. I need to either let them communicate with each other or find a way to "merge" them on application.

* Some weapon configs cause significant freezes when fired, specifically those with an absurd multi-shot stat (cartridge of junk magazine + trumpet muzzle + multiple duplicator addons, for example).
	*Due to many addons applying multiplicatively, focusing hard on one specific stat increases it exponentially and ludicrously. Either a rebalance or hard projectile cap (or both) may be needed.

* For automatic weapons, quickly releasing and pressing back down the fire button between shots prevents firing until releasing the button again.

* Stepping on the "spawn test dummy" button often spawns two, instead of one.

----------------------
My Current Favorite (and/or Most Broken) Loadouts
----------------------

Loadout 1- Firebomb
	Frame: Revolver
	Battery: Battery
	Magazine: Cartridge of Junk
	Muzzle: Trumpet
	Addon: Fire thing
	Addon: dampener
	Addon: dampener

Cartridge of Junk was initially meant to be sort of a joke option. I added it immediately after making the player move back from the force of fired projectiles, thinking it would be funny while also being usable as a sort of movement tech, like a rocket jump. However, with the way status effects work right now, they apply at the modifier's listed strength regardless of multishot. Multiple shots can also apply multiple stacks, if they hit. Due to this, pushing hard on multishot can result in insane damage when using a damage over time status effect. The insane spread of this setup means the range is extremely limited, so reducing the velocity via dampeners is only beneficial, keeping the bullets in a smaller overall area.
Using the Rapid Fire cartridge and replacing the dampeners with duplicators can have comparable output, but the giant explosion of projectiles is still something I'm more fond of.

Loadout 2- Shot Put
	Frame: Big Iron
	Battery: Momentum Absorber
	Magazine: Revolver Mag
	Muzzle: Silencer
	Addon: duplicator
	Addon: duplicator
	Addon: duplicator
	Addon: dampener
	Addon: dampener

I like the "Shot Put" loadout because it exposes a strange quirk of how spread currently works. Essentially, all projectiles spawn in the same position, are rotated a randomized amount (the range of this randomness determined by the spread variable), then have force applied relative to their forward direction. This works quite nicely in most instances, though obviously relies on the projectiles traveling some distance to begin to spread out. This loadout uses dampeners and the Momentum Absorber battery to reduce the velocity of the multiple projectiles significantly. In practice, this means these projectiles remain on nearly the same trajectory, arcing and falling at a very short range. I imagine this could be fun for heavily vertical maps, fulfilling the human desire to drop heavy objects onto one's enemies.

Loadout 3- Flying Machine
	Frame: Big Iron
	Battery: Momentum Absorber
	Magazine: Rapid Fire Cartridge
	Muzzle: Trumpet

This is the best mobility loadout I've managed so far without using the Super Battery, which is basically cheating. While Cartridge of junk has a huge immediate blast away, it's very difficult to control direction due to the spread and long time between shots. Rapid Fire Cartridge allows for a much more consistent flight, with the Trumpet muzzle significantly increasing the pushback due to having multiple projectiles. While losing velocity isn't ideal, the Momentum Absorber battery is essential here due to reducing the energy cost of the build. In fact, since the whole thing only drains 5 energy, this build actually takes 0 energy to fire! Infinite flight!
