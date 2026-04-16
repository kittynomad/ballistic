----------------------
Overview
----------------------
The Modular Weapons system allows for simple definition and use of "Weapon Parts" in the assembly of custom, unique projectile-based weapons.

----------------------
Use (Editor)
----------------------
Weapon parts are defined in the ComponentDataService prefab. It can be found at Assets/Prefabs/Services/SaveDataServicePrefabs.

When opening this prefab, you can either edit parts directly in-editor, or export the database as a .json file to modify externally.
	To export the database, press one of two "Save Part Database" buttons on the Component Data Service component. "Internally" saves the file in the project's StreamingAssets folder, while "Externally" saves to your computer's persistent data path.
	Once edited, the file can be re-registered by using the proper "Load Part Database" button.

While modifying a weapon part in-engine, hold your cursor over a variable to display a tooltip explaining the purpose of that variable.

----------------------
Use (Gameplay/Example Scene)
----------------------
Any scene with the ApplicationStarter prefab will load test scene for trying out the modular weapons system.

To modify your weapon, open the Assembly UI with the M key. Exit this menu by pressing the "Finish" button on this screen.
There are buttons to view each category of part (Frames, Magazines, Batteries, Muzzles, Addons).
When a category is selected, every part of that type will appear on the left hand side.
When you press the "Equip" button on a listed part, it will automatically replace the part of that type already on that weapon (Except for addons, which are added to the list of addons, or ignored if the weapon has max addons).
This menu also has a "Randomize" button, which will randomize every part on your weapon. This weapon may or may not be largely ineffective.

The scene loads without any NPCs. By stepping on a button on the opposite side of the room, a "Test Dummy" will spawn. It has no AI but can be attacked and affected by statuses. The button can be reused infinitely.
