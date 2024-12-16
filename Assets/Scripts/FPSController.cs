using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Player : MonoBehavior
{
    // Set these in the inspector
    public float MaxSpeed;
    public float Acceleration;

    Vector2 currentSpeed = new Vector2();

    //code that runs every frame
    void Update()
    {
        Vector2 input = new Vector2();

        if (Input.GetKey(KeyCode.W))
        {
            input.y += 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            input.y -= 1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            input.x += 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            input.x -= 1;
        }

        //apply player accel using lerp
        currentSpeed = Vector2.Lerp(currentSpeed, new Vector2(MaxSpeed, MaxSpeed), Time.deltaTime * Acceleration * input);

        //clamp movement speed so that you can't move faster when moving at a diagnol
        currentSpeed = Vector2.ClampMagnitude(currentSpeed, MaxSpeed);

        //move the player, you will likly need to fix the vector conversion by changing the x and z direction on line 44 and 45.
        Vector3 position = transform.position;
        position.x += currentSpeed.x * Time.deltaTime;
        position.z += currentSpeed.y * Time.deltaTime;
    }
}

// Time.deltaTime time since last frame * Time.TimeScale
// Time.unscaledDeltaTime time since last frame
// Time.fixedDeltaTime time since last physics update * Time.timeScale, if the game is running at a framerate higher than the fixed time interval
// (changeable in project settings) then it will always be the fixed time interval
// Time.unscaledFixedDeltaTime time since the last physics update