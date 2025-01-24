using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 movement = Vector3.zero;
    private float speed = 5f;
    void Update()
    {
        //Movement
        movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movement += Vector3.up;
        }

        if (Input.GetKey(KeyCode.A))
        {
            movement += Vector3.left;

        }

        if (Input.GetKey(KeyCode.S))
        {
            movement += Vector3.down;

        }

        if (Input.GetKey(KeyCode.D))
        {
            movement += Vector3.right;

        }

        this.transform.position += movement * (speed * Time.deltaTime);

    }
}