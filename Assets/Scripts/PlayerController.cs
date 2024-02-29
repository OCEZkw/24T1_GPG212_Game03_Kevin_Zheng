using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float slideSpeed = 5f; // Adjust this value to set the sliding speed

    void Update()
    {
        // Check if there is any touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Check if the touch is moving
            if (touch.phase == TouchPhase.Moved)
            {
                // Calculate the movement amount based on the touch delta position
                float movement = touch.deltaPosition.x * slideSpeed * Time.deltaTime;

                // Move the player horizontally
                transform.Translate(new Vector3(movement, 0f, 0f));

                // Optionally, you can limit the player's movement within a specific range
                // For example, if you want to keep the player within x = -5 to 5 range:
                float newX = Mathf.Clamp(transform.position.x, -14f, 14f);
                transform.position = new Vector3(newX, transform.position.y, transform.position.z);
            }
        }
    }
}