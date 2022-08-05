using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    public Vector3 Offset;
    public float FollowSpeed;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Player.position + Offset, FollowSpeed);
    }
}
