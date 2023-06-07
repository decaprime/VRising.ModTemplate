using BepInEx;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
#if(UseVCF)
using VampireCommandFramework;
#endif

namespace MOUTHWASH;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
#if(UseVCF)
[BepInDependency("gg.deca.VampireCommandFramework")]
#endif
#if(UseBloodstone)
[BepInDependency("gg.deca.Bloodstone")]
[Bloodstone.API.Reloadable]
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
        #if(UseVCF)
        CommandRegistry.UnregisterAssembly();
        #endif
        _harmony?.UnpatchSelf();
        return true;
    }

    #if (UseVCF)
    // // Uncomment for example commmand or delete

    // /// <summary> 
    // /// Example VCF command that demonstrated default values and primitive types
    // /// Visit https://github.com/decaprime/VampireCommandFramework for more info 
    // /// </summary>
    // /// <remarks>
    // /// How you could call this command from chat:
    // ///
    // /// .mouthwash-example "some quoted string" 1 1.5
    // /// .mouthwash-example boop 21232
    // /// .mouthwash-example boop-boop
    // ///</remarks>
    // [Command("mouthwash-example", description: "Example command from mouthwash", adminOnly: true)]
    // public void ExampleCommand(ICommandContext ctx, string someString, int num = 5, float num2 = 1.5f)
    // { 
    //     ctx.Reply($"You passed in {someString} and {num} and {num2}");
    // }
    #endif
}
