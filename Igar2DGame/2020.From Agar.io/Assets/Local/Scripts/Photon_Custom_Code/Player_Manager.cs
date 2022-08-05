using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace AgarMainGame
{
    public class Player_Manager : MonoBehaviourPunCallbacks, IPunObservable
    {
        #region Public Static Fields
        public static GameObject LocalPlayerInstance;
        #endregion

        #region Public Fields
        public Collider2D PlayerCollider;
        [Tooltip("Current Health of this player")]
        public float PlayerHealth = 1f;
        [Space(10)]
        public PhotonView PhotonView;
        #endregion
        #region Private Serialized Fields
        [SerializeField] private GameObject Player_UI_Prefab;
        [SerializeField] private bool isBigPlayer;
        #endregion
        #region MonoBehavior Callbacks
        private void Start()
        {
            PlayerCollider = GetComponent<Collider2D>();
            PhotonView = GetComponent<PhotonView>();
        } 
        private void Update()
        {
            if (PlayerHealth < 0)
            {
                GameManager.Instance.LeaveRoom();
            }
            Debug.Log($"Player Collision: {PlayerHealth}");
        }  

        #endregion



        #region Public Methods
        public void OnPlayerCollision()
        {
        }
        #endregion

        #region Public (Photon) Methods
        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {

        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!PhotonView.IsMine)
            {
                return;
            }
            if (!collision.name.Contains("Player"))
            {
                return;
            }
            else
            {
                if (!isBigPlayer)
                {
                    print("<color=red>Hit...</color>");
                    PlayerHealth -= .1f * Time.deltaTime;
                }
                else
                    print("<color=red>Big Color...</color>");
            }
        }
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (!PhotonView.IsMine)
            {
                Debug.Log("...................");
                return;
            }
            if (!collision.name.Contains("Player"))
            {
                return;
            }
            else
            {
                if (!isBigPlayer)
                {
                    print("<color=red>Hit...</color>");
                    PlayerHealth -= .1f * Time.deltaTime;
                }
                else
                    print("<color=red>Big Color...</color>");
            }
        }
        #endregion
    }
}

