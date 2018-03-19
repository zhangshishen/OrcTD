using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
	                    // The initial offset from the target.
    Vector3 movement;
    Transform transform;
	void Start()
	{
        transform = GetComponent<Transform>();
		// Calculate the initial offset.
		//offset = transform.position - target.position;
	}

	void FixedUpdate()
	{
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");

		// Move the player around the scene.
		Move(h, v);
	}
	void Move(float h, float v)
	{
		// Set the movement vector based on the axis input.
		movement.Set(h, 0f, v);

		// Normalise the movement vector and make it proportional to the speed per second.
		movement = movement.normalized * 7.0f * Time.deltaTime;

		// Move the player to it's current position plus the movement.
        transform.position = (transform.position + movement);
	}
}