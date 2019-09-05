using UnityEngine;
using HarmonyLib;

namespace CEOverlordCheatMenu.Patches
{
    [HarmonyPatch(typeof(General))]
    [HarmonyPatch("StartGame")]
    static class Patch_SetResources
    {
        public static void Postfix(General __instance)
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