# RiskOfRain2ShareItemsMod
CSharp Assembly mods to allow players to share items in Risk of Rain 2 multiplayer.


## About
This is a collection of small mods that allow players in Risk of Rain 2 to share items when picked up.
Basically, when one player picks something up in multiplayer, it gets duplicated to all other players on the team - no more fighting over items!

There are currently two versions;
* Share All Items: All items are duplicated to other players; this includes Equipment, Artifacts, and Lunar Coins. 
* Share Only Normal Items: Only "normal" (non-equipment, non-artifact, and non-lunar-coin) items get shared between players. This version is a little better to play.

## How To Use
**Note: Only the host of a multiplayer game needs to install the mod.**  

[Download the latest release from the releases page.](https://github.com/DrMelon/RiskOfRain2ShareItemsMod/releases/tag/v1)
Open the zip file and choose which version you would like to use.  
Then, copy the `Assembly-CSharp.dll` file from the `Compiled` folder, and paste it into the following directory (or equivalent, depending on your Risk of Rain 2 install location.):  
`C:/Program Files (x86)/Steam/steamapps/common/Risk of Rain 2/Risk of Rain 2_Data/Managed`  
If you want to, make a backup of the old `Assembly-CSharp.dll` file first, before overwriting it with the mod.

## Compiling Yourself
If you would prefer to build the .dll file yourself, the process is fairly straightforward.
1. Download dnSpy - this is a CSharp decompiler that you will need to rebuild the assembly with the new code.
2. In dnSpy, go to `File -> Open`, and navigate to the `C:/Program Files (x86)/Steam/steamapps/common/Risk of Rain 2/Risk of Rain 2_Data/Managed` folder. Select all files except `System.dll` and `System.Core.dll`; dnSpy already has these assemblies loaded as it is itself a C# program, and the code will not compile with duplicate references to these assemblies.
3. In the browser pane on the left, expand the `Assembly-CSharp` folder, and expand the `RoR` namespace. Doubleclick on `GenericPickupHandler` in that subfolder to open the code view.
4. Scroll down until you find the `AttemptGrant` method. Right-click on the method name, and select `Edit Method (C#)` from the context menu to open the editor.
5. Choose the version of the mod you would like to use, and open the .cs file in the `Code` folder in a text editor of your choice. Copy all of the mod's code, and replace the entire method code in the dnSpy editor window with it by selecting it all and pasting over it.
6. Hit `Compile` in dnSpy; it should compile without any errors.
7. Once compiled, use `File -> Save Module` and overwrite the `Assembly-CSharp` file with your changes.
8. Done!
