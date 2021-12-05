
using System;
<<<<<<< dev
<<<<<<< dev
using Photon.Bolt;
using Photon.Bolt.Utils;
using Photon.Bolt.Matchmaking;
=======
using Bolt.Matchmaking;
using Bolt.Photon;
>>>>>>> Добавлен UI эллементы
=======
using Photon.Bolt;
using Photon.Bolt.Utils;
using Photon.Bolt.Matchmaking;
>>>>>>> все внесено
using UdpKit;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Bolt.Samples.HeadlessServer
{
<<<<<<< dev
<<<<<<< dev
    public class HeadlessServer : GlobalEventListener
=======
    public class HeadlessServer : Bolt.GlobalEventListener
>>>>>>> Добавлен UI эллементы
=======
    public class HeadlessServer : GlobalEventListener
>>>>>>> все внесено
    {
        public string Map = "";
        public string GameType = "";
        public string RoomID = "";

        public override void BoltStartBegin()
        {
            // Register any Protocol Token that are you using
            BoltNetwork.RegisterTokenClass<PhotonRoomProperties>();
            BoltNetwork.RegisterTokenClass<ProtocolTokenLogin>();
            BoltNetwork.RegisterTokenClass<AuthResultToken>();
        }

       
        public override void BoltStartDone()
        {
            if (BoltNetwork.IsServer)
            {
               

                // Create the Photon Room
                BoltMatchmaking.CreateSession(
                    sessionID: "RoomID",
                    sceneToLoad: "GameScene"
                );
            }
        }

        // Use this for initialization
        void Start()
        {
            if (IsHeadlessMode())
            {
                // Get custom arguments from command line
                Map = GetArg("-m", "-map") ?? Map;
                GameType = GetArg("-t", "-gameType") ?? GameType; // ex: get game type from command line
                RoomID = GetArg("-r", "-room") ?? RoomID;

                // Validate the requested Level
                var validMap = false;

                foreach (string value in BoltScenes.AllScenes)
                {
                    if (SceneManager.GetActiveScene().name != value)
                    {
                        if (Map == value)
                        {
                            validMap = true;
                            break;
                        }
                    }
                }

                if (!validMap)
                {
                    BoltLog.Error("Invalid configuration: please verify level name");
                    Application.Quit();
                }

                // Start the Server
                BoltLauncher.StartServer();
                DontDestroyOnLoad(this);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                Debug.Log("����� �������: ��������");
            }
        }

        /// <summary>
        /// Utility function to detect if the game instance was started in headless mode.
        /// </summary>
        /// <returns><c>true</c>, if headless mode was ised, <c>false</c> otherwise.</returns>
        public static bool IsHeadlessMode()
        {
            return Environment.CommandLine.Contains("-batchmode") && Environment.CommandLine.Contains("-nographics");
        }

        static string GetArg(params string[] names)
        {
            var args = Environment.GetCommandLineArgs();
            for (int i = 0; i < args.Length; i++)
            {
                foreach (var name in names)
                {
                    if (args[i] == name && args.Length > i + 1)
                    {
                        return args[i + 1];
                    }
                }
            }

            return null;
        }
    }
}
