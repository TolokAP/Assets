using UnityEngine;
using UdpKit;
<<<<<<< dev
<<<<<<< dev
using Photon.Bolt;
using Photon.Bolt.Utils;
using Photon.Bolt.Matchmaking;
using System.Collections.Generic;

=======
using Bolt;
using System.Collections.Generic;
using Bolt.Matchmaking;
using Bolt.Photon;
>>>>>>> Добавлен UI эллементы
=======
using Photon.Bolt;
using Photon.Bolt.Utils;
using Photon.Bolt.Matchmaking;
using System.Collections.Generic;

>>>>>>> все внесено
using UnityEngine.UI;


public class BoltInit : GlobalEventListener
{
	
	public Dictionary<string, string> PlayerInfo;


	public InputField loginIF;
	public InputField passIF;
	
	public bool createPlayer;
	public InputField CreateLogin;
	public InputField CreatePass;
	public InputField CreateName;
	public ToggleGroup toggleGroup;
	public string _Class;

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
				BoltMatchmaking.CreateSession(
					sessionID: "ID",
					sceneToLoad: "GameScene"
				);
			}
			if (BoltNetwork.IsClient)
			{
				if (createPlayer)
				{
				ProtocolTokenLogin credentials = new ProtocolTokenLogin
				{
					Username = CreateLogin.text,
					Password = CreatePass.text,
					NamePlayer = CreateName.text,
					Create = true,
					Class = _Class

					};
					BoltMatchmaking.JoinRandomSession(credentials);
				}
				else
				{
				ProtocolTokenLogin credentials = new ProtocolTokenLogin
					{
						Username = loginIF.text,
						Password = passIF.text,
						Create = false
					};
					BoltMatchmaking.JoinRandomSession(credentials);
				}



			}
          
			
			
		}

	    public void SetToggle(string value)
		{
		_Class = value;


		}
	   
		public override void BoltShutdownBegin(AddCallback registerDoneCallback, UdpConnectionDisconnectReason disconnectReason)
		{
			
		}

	
		public void StartServer()
		{
			BoltLauncher.StartServer();

		}

		public void StartClient()
		{
			BoltLauncher.StartClient();
		}

		public void CreatePlayer()
		{
		
		if (!string.IsNullOrEmpty(CreateName.text)&&!string.IsNullOrEmpty(CreatePass.text)&&!string.IsNullOrEmpty(CreateName.text)) {
			createPlayer = true;
			BoltLauncher.StartClient();
		}
        else
        {
			
			
			Debug.Log("������� ��� � ������");
        }

	    }
    
}
