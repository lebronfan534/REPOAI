using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using MelonLoader;
using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;

namespace REPO_AI
{
    public static class MovementController
    {
        private static GameObject player;

        public static void Initialize()
        {
            var scene = SceneManager.GetActiveScene();
            if (scene.buildIndex == 0) return;        // skip main menu
            player = GameObject.FindWithTag("Player");
            if (player == null)
                MelonLogger.Msg("MovementController: Player not Found");
            else
                MelonLogger.Msg("MovementController: Player found successfully");
        }

        public static void MoveTowards(Vector3 targetPosition, float speed = 5f)
        {
            if (player == null) return;

            Vector3 Direction = (targetPosition - player.transform.position).normalized;
            player.transform.position += Direction * speed * Time.deltaTime;
        }

        public static Vector3 GetPlayerPosition()
        {
            if (player == null) return Vector3.zero;
            return player.transform.position;
        }
    }
}
