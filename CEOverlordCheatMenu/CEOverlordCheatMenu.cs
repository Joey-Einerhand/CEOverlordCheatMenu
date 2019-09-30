using UnityEngine;
using UModFramework.API;
using System;
using System.Linq;
using System.Collections.Generic;

namespace CEOverlordCheatMenu
{
    [UMFHarmony(2)] //Set this to the number of harmony patches in your mod.
    [UMFScript]
    class CEOverlordCheatMenu : MonoBehaviour
    {
        internal static void Log(string text, bool clean = false)
        {
            using (UMFLog log = new UMFLog()) log.Log(text, clean);
        }

        [UMFConfig]
        public static void LoadConfig()
        {
            CEOverlordCheatMenuConfig.Load();
        }

		void Awake()
		{
			Log("CEOverlordCheatMenu v" + UMFMod.GetModVersion().ToString(), true);
		}

        void Update()
        {
        }
	}
}