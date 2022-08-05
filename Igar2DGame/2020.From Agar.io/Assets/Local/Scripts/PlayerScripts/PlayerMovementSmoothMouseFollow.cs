using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


namespace PersonalProjectsNdiphiwe
{
    public class PlayerMovementSmoothMouseFollow : MonoBehaviour
    {
        #region External Scripts
        private FoodBehavior foodBehavior;
        #endregion

        #region Public Fields
        [Header("Player And Movement")]
        public Vector3 MousePosition;
        public float PlayermoveSpeed;
        public Rigidbody2D Rigid_body;

        public Vector2 Position = new Vector2(0, 0);
        #endregion
        [Space(20)]

        #region Private Fields
        [Header("Player Scale")]
        [SerializeField] private Transform playerTransform;
        [SerializeField] private Vector3 player_local_scale;
        [SerializeField] private float increaseScale = 1f;
        #endregion

        public Text PlayerCurrentScaleX;
        public Text PlayerCurrentScaleY;
  
        

        #region MonoBehaviour CallBacks

        private void Start()
        { 
            Rigid_body      = GetComponent<Rigidbody2D>();
            playerTransform = GetComponent<Transform>();
        }

        private void Update()
        {
            if (!Input.GetKey(KeyCode.LeftAlt))
            {
                MousePosition = Input.mousePosition;
                MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);
                Position = Vector2.Lerp(transform.position, MousePosition, PlayermoveSpeed);
            }
        }

        private void FixedUpdate()
        {
            Rigid_body.MovePosition(Position);
        }
        #endregion

        #region Public methods

        public void PlayerScaleUp()
        {
            player_local_scale = playerTransform.localScale;

             Debug.LogFormat($"<color=yellow><a>Scale Increase</a></color>");

            player_local_scale.x += increaseScale;
            player_local_scale.y += increaseScale;

            playerTransform.localScale = player_local_scale;

            float player_local_scaleX = player_local_scale.x;
            float player_local_scaleY = player_local_scale.y;

            PlayerCurrentScaleX.text = $"({Math.Round(player_local_scaleX, 2).ToString()}, ";
            PlayerCurrentScaleY.text = $"{Math.Round(player_local_scaleY, 2).ToString()} )";

            PlayerSpeed();
        }


        #endregion
        #region Private methods
        private void PlayerSpeed()
        {
            PlayermoveSpeed -= 0.0001f;
            if (PlayermoveSpeed < 0.001f)
            {
                PlayermoveSpeed = 0.001f; 
            }
        }
        #endregion


    }
}
