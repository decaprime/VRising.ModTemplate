using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;
#if(UseVCF)
using VampireCommandFramework;
#endif

namespace MOUTHWASH;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
#if(UseVCF)
[BepInDependency("gg.deca.VampireCommandFramework")]
#endif
#if(UseWetstone)
[BepInDependency("xyz.molenzwiebel.wetstone")]
[Wetstone.API.Reloadable]
#endif
public class Plugin : BasePlugin
{
    Harmony _harmony;

    public override void Load()
    {
        // Plugin startup logic
        Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} version {MyPluginInfo.PLUGIN_VERSION} is loaded!");

        // Harmony patching
        _harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
        _harmony.PatchAll(System.Reflection.Assembly.GetExecutingAssembly());

#if (UseVCF)
        // Register all commands in the assembly with VCF
        CommandRegistry.RegisterAll();
#endif
    }

    public override bool Unload()
    {
        _harmony?.UnpatchSelf();
        return true;
    }
}
