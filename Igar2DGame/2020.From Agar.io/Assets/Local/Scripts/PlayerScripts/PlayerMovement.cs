//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerMovement : MonoBehaviour
//{
//    #region Public Fields
//    public Transform PlayerSprite;
//    public Transform MousePosition;

//    public Vector3 direction;
//    #endregion

//    #region Private Fields
//    private float player_speed = 0.001f;
//    #endregion

//    #region MonoBehaviour Callbacks
//    private void Start()
//    {
//        Debug.Log($"Direction is {direction.magnitude}");
//    }
//    private void Update()
//    {
//        if (!Input.GetKeyDown(KeyCode.LeftAlt))
//        {
//            Debug.Log($"Direction is {direction.magnitude}");
//            direction = Input.mousePosition - PlayerSprite.position;
//            direction.Normalize();
//            Debug.Log($"Distance betweeen is {direction.magnitude}");
//            Debug.DrawRay(PlayerSprite.transform.position, direction, Color.green);

//            PlayerSprite.transform.Translate(direction * player_speed * Time.deltaTime);
//        }
//    }
//    #endregion

//    #region Public Methods
//    #endregion

//    #region Private Methods
//    #endregion

//}
