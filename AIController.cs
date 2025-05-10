using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace REPO_AI
{
    public static class AIController
    {
        private static GameObject currentTarget = null;

        public static void UpdateAI()
        {

            if (currentTarget == null)
            {
                currentTarget = ValuableTracker.FindClosetValuable();
            }


            if (currentTarget != null)
            {
                MovementController.MoveTowards(currentTarget.transform.position);

                float distance = Vector3.Distance(MovementController.GetPlayerPosition(), currentTarget.transform.position);
                if (distance < 2f)
                {
                    currentTarget = null;
                }
            }
        }
    }
}