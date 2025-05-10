using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;   // for Time, Vector3, GameObject

namespace REPO_AI
{
    public static class AIController
    {
        private static GameObject currentTarget = null;
        private static float scanTimer = 0f;
        private const float scanInterval = 1f;  // seconds between scans

        public static void UpdateAI()
        {
            // accumulate time each frame
            scanTimer += Time.deltaTime;

            // only re-scan if we have no target and the interval elapsed
            if (currentTarget == null && scanTimer >= scanInterval)
            {
                currentTarget = ValuableTracker.FindClosetValuable();  // logs “Found N valuables” :contentReference[oaicite:0]{index=0}:contentReference[oaicite:1]{index=1}
                scanTimer = 0f;
            }

            // if we have a target, move toward it and clear once “scanned”
            if (currentTarget != null)
            {
                MovementController.MoveTowards(currentTarget.transform.position);  // :contentReference[oaicite:2]{index=2}:contentReference[oaicite:3]{index=3}

                float dist = Vector3.Distance(
                    MovementController.GetPlayerPosition(),
                    currentTarget.transform.position
                );
                if (dist < 2f)
                    currentTarget = null;
            }
        }
    }
}


