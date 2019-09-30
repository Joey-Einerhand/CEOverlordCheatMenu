using UnityEngine;
using HarmonyLib;
using System.Collections.Generic;

namespace CEOverlordCheatMenu.Patches
{

    [HarmonyPatch(typeof(General))]
    [HarmonyPatch("RemoveResourcesForBuying")]
    static class Patch_SetResources
    {
        public static void Prefix(Player tplayer, ThingType tthingType)
        {
            if (CEOverlordCheatMenuConfig.enableUnlimitedResources == true)
            {
                for (int i = 0; i < tthingType.prices.Count; i++)
                {
                    List<int> resources;
                    int index;
                    (resources = tplayer.resources)[index = i] = resources[index] + tthingType.prices[i];
                }
            }
        }
    }

    [HarmonyPatch(typeof(General))]
    [HarmonyPatch("StartGame")]
    static class Patch_SetResources2
    {
        public static void Postfix(General __instance)
        {
            if (CEOverlordCheatMenuConfig.enableUnlimitedResources == true)
            {
                foreach (Player player in __instance.players)
                {
                    if (player.isHumanPlayer == 1)
                    {
                        // Wood
                        player.resources[0] = CEOverlordCheatMenuConfig.resourceList["wood"];
                        // Food
                        player.resources[1] = CEOverlordCheatMenuConfig.resourceList["food"];
                        // Gold
                        player.resources[2] = CEOverlordCheatMenuConfig.resourceList["gold"];
                    }
                }
            }
        }
    }
    /// Legacy code for future improvement purposes
    //[HarmonyPatch(typeof(Player))]
    //[HarmonyPatch("GainResource")]
    //static class Patch_SetResources2
    //{
    //    public static void Prefix(Player __instance)
    //    {
    //        if (CEOverlordCheatMenuConfig.enableResourceEditMidgame == true)
    //        {
    //            // wood
    //            __instance.resources[0] = CEOverlordCheatMenuConfig.resourceList["wood"];
    //            // food
    //            __instance.resources[1] = CEOverlordCheatMenuConfig.resourceList["food"];
    //            // gold
    //            __instance.resources[3] = CEOverlordCheatMenuConfig.resourceList["gold"];
    //        }
    //    }
    //} 
    // Next one gives you emones when you click
    //[HarmonyPatch(typeof(Thing))]
    //[HarmonyPatch("CustomUpdate")]
    //static class Patch_SetResources2
    //{
    //    public static void Postfix(Thing __instance)
    //    {
    //        if (CEOverlordCheatMenuConfig.enableResourceEditMidgame == true)
    //        {
    //            if (__instance.player == __instance.general.locallyControlledPlayer && Input.GetMouseButtonDown(0))
    //            {
    //                __instance.player.resources[0] = CEOverlordCheatMenuConfig.resourceList["wood"];
    //                // food
    //                __instance.player.resources[1] = CEOverlordCheatMenuConfig.resourceList["food"];
    //                // gold
    //                __instance.player.resources[3] = CEOverlordCheatMenuConfig.resourceList["gold"];
    //            }
    //        }
    //    }
    //}

    // Updates resources whilst mouse is held down too (intended behaviour) but also laggs units
    //[HarmonyPatch(typeof(Thing))]
    //[HarmonyPatch("CustomUpdate")]
    //static class Patch_SetResources2
    //{
    //    public static void Postfix(Thing __instance)
    //    {
    //        if (CEOverlordCheatMenuConfig.enableResourceEditMidgame == true)
    //        {
    //            if (__instance.player == __instance.general.locallyControlledPlayer && Input.GetMouseButton(0))
    //            {
    //                __instance.player.resources[0] = CEOverlordCheatMenuConfig.resourceList["wood"];
    //                // food
    //                __instance.player.resources[1] = CEOverlordCheatMenuConfig.resourceList["food"];
    //                // gold
    //                __instance.player.resources[3] = CEOverlordCheatMenuConfig.resourceList["gold"];
    //            }
    //        }
    //    }
    //}
}