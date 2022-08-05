using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    public float speed;
    public float rotation_offset;

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;
        Vector3 player_position = Camera.main.ScreenToWorldPoint(transform.position);

        mousePos.x = mousePos.x - player_position.x;
        mousePos.y = mousePos.y - player_position.y;

        float angle = Mathf.Atan2(mousePos.y , mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + rotation_offset));

        Vector3 target_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target_pos.z = 0;
        transform.position = Vector3.MoveTowards(transform.position, target_pos, speed * Time.deltaTime);



    }

}
