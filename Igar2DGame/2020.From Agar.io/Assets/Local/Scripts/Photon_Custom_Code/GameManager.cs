using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using Photon.Pun;
using Random = UnityEngine.Random;

namespace AgarMainGame
{
    public class GameManager : MonoBehaviourPunCallbacks
    {
        #region Global Variables

#region Static GameManager Instance Singleton
        public static GameManager _instance;
#endregion
#region Public Property
        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                    Debug.LogFormat("<color>_instance of GameManager is null!</color>");
                return _instance;
            }
        }
#endregion
#region Public Fields
        [SerializeField]private GameObject PlayerPrefab;
        [SerializeField]private string     Game_Launcher_Scene;
        #endregion

        #region Private Fields
        private float rand_x_pos;
        private float rand_y_pos;
        #endregion

        #endregion
        #region MonoBehavior CallBacks
        private void Awake()
        {
            _instance = this;
        }
        private void Start()
        {
            rand_x_pos = Random.Range(-5, 5);
            rand_y_pos = Random.Range(-5, 5f);
            if (!PhotonNetwork.IsConnected)
            {
                SceneManager.LoadScene("GameLaucher");
                return;
            }

            if (PlayerPrefab == null)
            {
                Debug.LogError("<color>Player prefab is null insert in the inspector</color>");
            }
            else
            {
                if (Player_Manager.LocalPlayerInstance == null)
                {
                    Debug.LogFormat("Instantiating LocalPlayer from {0} ", SceneManagerHelper.ActiveSceneName);

                    PhotonNetwork.Instantiate(this.PlayerPrefab.name, new Vector2(rand_x_pos, rand_y_pos), Quaternion.identity, 0);
                }
                else
                {
                    Debug.Log("Ignoring scene load for {0}"+ SceneManagerHelper.ActiveSceneName);
                }
            }
        }
        private void Update()
        {
            if (Input.GetButtonDown("Jump"))
            {
                Application.Quit();
            }
            //DateTime date = DateTime.Now;
            //// Debug.Log("Current date: " + date);
            //Debug.Log(date.ToString("dddd, dd MMMM yyyy  HH:mm:ss"));
        }
        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            Debug.Log("On PlayerEnteredRoom()" + newPlayer.NickName); // not visible if you are the player connecting
            if (PhotonNetwork.IsMasterClient)
            {
                Debug.LogFormat("OnPlayerEnteredRoom {0}", PhotonNetwork.IsMasterClient);
                LoadArena();
            }
        }
        public override void OnPlayerLeftRoom(Player newPlayer)
        {
            Debug.Log("OnPlayerLeftRoom() " + newPlayer.NickName);
            if (PhotonNetwork.IsMasterClient)
            {
                Debug.LogFormat("OnPlayerLeftdRoom IsMasterClient {0} " + PhotonNetwork.IsMasterClient);
                LoadArena();
            }
        }
        public override void OnLeftRoom()
        {
            SceneManager.LoadScene(Game_Launcher_Scene);
        }
        #endregion
        #region Public Methods

        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }
        #endregion
        #region Private Methods
        private void LoadArena()
        {
            if (!PhotonNetwork.IsMasterClient)
                Debug.LogError("Tried to load level but not master client");
            Debug.LogFormat("PhotonNetwork : Loading level {0}" + PhotonNetwork.CurrentRoom.PlayerCount);

            PhotonNetwork.LoadLevel("Photon-Room for" + PhotonNetwork.CurrentRoom.PlayerCount);
        }
        #endregion
    }
}
