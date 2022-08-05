using UnityEngine;
using UnityEngine.UI;
using System;
using Photon.Pun;
using UnityEngine.Events;
using Photon.Realtime;

namespace AgarMainGame
{
    public class GameLauncher : MonoBehaviourPunCallbacks
    {
        #region Private Serialized Fields
        // First launch game canvas //
        [SerializeField] private UnityEvent launcherCanvasPanel;

        // Give player feedback on Connecting //  
        [Tooltip("Connecting FeedBack")]
        [SerializeField] private Text feedBackOnLauch;


        [Tooltip("Maximum number of players per room")]
        [SerializeField] private byte maximumPlayersPerRoom = 4;

        [Header("Rooms")]
        [SerializeField] private string game_launcher;
        [SerializeField] private string room_1;
        [SerializeField] private string room_2;
        [SerializeField] private string room_3;
        [SerializeField] private string room_4;

        #endregion

        #region Private Fields
        [ReadOnly] private bool isConnecting;
        [ReadOnly] private string gameVersion = "1";
        #endregion

        #region MonoBehaviour CallBacks 
        private void Awake()
        {
            // # Critical for LoadLevel();
            PhotonNetwork.AutomaticallySyncScene = true;
        }
        public void ButtonJoin()
        {
            print("Testing joining room button...");
        }


        #endregion

        #region Public Methods
        public void ConnectPlayer()
        {
            Debug.Log("<color=green>Connecting To Server...</color>");

            feedBackOnLauch.text = "";

            isConnecting = true;

            launcherCanvasPanel.Invoke();

            if (PhotonNetwork.IsConnected)
            {
                LogMessage("Joining Room...");
                Debug.Log("<color=cyan>Player Connected</color>");
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                LogMessage("Connecting...");
                PhotonNetwork.ConnectUsingSettings();
                PhotonNetwork.GameVersion = this.gameVersion;
            }
        }

        public void LogMessage(string message)
        {
            if (feedBackOnLauch == null)
                return;

            feedBackOnLauch.text = Environment.NewLine + message;
        }
        #endregion

        #region PunCallbacks Overrides
        public override void OnConnectedToMaster()
        {
            if (isConnecting)
            {
                LogMessage("Connected, joining room...");
                PhotonNetwork.JoinRandomRoom();
            }
        }
        //  Created when joining room and none exist //
        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            LogMessage("<color=green>Creating room</color>");
            Debug.Log("OnJoinRandom room failed and now creating room with PhotonNetwork.CreateRoom");

            PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = this.maximumPlayersPerRoom });
        }

        public override void OnJoinedRoom()
        {
            Debug.Log("Player Joined Room");
            LogMessage($"<color=yellow>OnJoinedRoom() </color> with {PhotonNetwork.CurrentRoom.PlayerCount} Player(s)");


            if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
            {
                Debug.Log("<color=green>Loading room for 1</color>");

                PhotonNetwork.LoadLevel(room_1);
            }

        }
        #endregion
    }
}
