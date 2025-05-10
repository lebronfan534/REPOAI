using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


namespace REPO_AI
{
    public static class ValuableTracker
    {
        public static GameObject FindClosetValuable()
        {
            var valuables = GameObject.FindObjectsOfType<ValuableObject>();
            MelonLoader.MelonLogger.Msg("Found " + valuables.Length + " valuables");

            if (valuables == null || valuables.Length == 0) return null;

            GameObject closet = null;
            float closetDistance =  Mathf.Infinity;
            Vector3 playerPos = MovementController.GetPlayerPosition();

            foreach (var valuable in valuables)
            {
                float distance = Vector3.Distance(playerPos, valuable.transform.position);

                if (distance < closetDistance)
                {
                    closetDistance = distance;
                    closet = valuable.gameObject;
                }
            }
            return closet;
        }
    }
}

