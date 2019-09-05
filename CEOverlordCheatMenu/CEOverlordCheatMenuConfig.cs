using System;
using UModFramework.API;
using System.Collections.Generic;

namespace CEOverlordCheatMenu
{
    public class CEOverlordCheatMenuConfig
    {
        private static readonly string configVersion = "0.1";

        //Add your config vars here.
        public static Dictionary<string, int> resourceList = new Dictionary<string, int> {{"wood", 200},{"food", 200},{"gold", 0}};
  
        internal static void Load()
        {
            CEOverlordCheatMenu.Log("Loading settings.");
            try
            {
                using (UMFConfig cfg = new UMFConfig())
                {
                    string cfgVer = cfg.Read("ConfigVersion", new UMFConfigString());
                    if (cfgVer != string.Empty && cfgVer != configVersion)
                    {
                        cfg.DeleteConfig(false);
                        CEOverlordCheatMenu.Log("The config file was outdated and has been deleted. A new config will be generated.");
                    }

                    //cfg.Write("SupportsHotLoading", new UMFConfigBool(false)); //Uncomment if your mod can't be loaded once the game has started.
                    //cfg.Write("ModDependencies", new UMFConfigStringArray(new string[] { "" })); //A comma separated list of mod names that this mod requires to function.
                    //cfg.Write("ModDependenciesVersions", new UMFConfigStringArray(new string[] { "" })); //A comma separated list of mod versions matching the ModDependencies setting.
                    cfg.Read("LoadPriority", new UMFConfigString("Normal"));
                    cfg.Write("MinVersion", new UMFConfigString("0.52.1"));
                    //cfg.Write("MaxVersion", new UMFConfigString("0.54.99999.99999")); //Uncomment if you think your mod may break with the next major UMF release.
                    cfg.Write("UpdateURL", new UMFConfigString(""));
                    cfg.Write("ConfigVersion", new UMFConfigString(configVersion));

                    CEOverlordCheatMenu.Log("Finished UMF Settings.");

                    //Add your settings here
                    resourceList["wood"] = cfg.Read("Wood", new UMFConfigInt(200, 200, 99999), "This is the amount of wood you have when starting a new game");
                    resourceList["food"] = cfg.Read("Food", new UMFConfigInt(200, 200, 99999), "This is the amount of food you have when starting a new game");
                    resourceList["gold"] = cfg.Read("Gold", new UMFConfigInt(0, 0, 99999),     "This is the amount of gold you have when starting a new game");

                    CEOverlordCheatMenu.Log("Finished loading settings.");
                }
            }
            catch (Exception e)
            {
                CEOverlordCheatMenu.Log("Error loading mod settings: " + e.Message + "(" + e.InnerException?.Message + ")");
            }
        }
    }
}