using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using MelonLoader;
using System.Runtime.InteropServices;

namespace REPO_AI
{
    public static class MovementController
    {
        private static GameObject player;

        public static void Initialize()
        {
            player = GameObject.FindWithTag("Player");
            if (player == null)
                MelonLogger.Msg("[Init] Player not Found");
            else
                MelonLogger.Msg($"[Init] Player found: {player.name}");
        }


        public static void MoveTowards(Vector3 targetPosition, float speed = 5f)
        {
            if (player == null) { Initialize(); if (player == null) return; }
            MelonLogger.Msg("[Movement] stepping—current pos: "
                            + player.transform.position);  // ← see this every frame
            Vector3 dir = (targetPosition - player.transform.position).normalized;
            player.transform.position += dir * speed * Time.deltaTime;
        }


        public static Vector3 GetPlayerPosition()
        {
            if (player == null) return Vector3.zero;
            return player.transform.position;
        }
    }
}
