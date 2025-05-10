using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using UnityEngine;
using UnityEngine.SceneManagement;


[assembly: MelonInfo(typeof(REPO_AI.Main), "REPOAI", "1.0.0", "YourNameHere")]
[assembly: MelonGame("semiwork", "REPO")]


namespace REPO_AI
{
    public class Main : MelonMod
    {
        public override void OnApplicationStart()
        {
            MelonLogger.Msg("REPO AI Loaded Successfully");
        }
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            MovementController.Initialize();
        }


        public override void OnUpdate()
        {
            AIController.UpdateAI();
        }
    }
}
