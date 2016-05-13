using UnityEngine;
using System.Collections;
using UnityEngine.Networking;


public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class shipController : NetworkBehaviour {
	 


	public float speed;
	public float tilt;
	public Boundary boundary;
	void Update (){
		float speed = 0.1F;

			if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
				// Get movement of the finger since last frame
				Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

				// Move object across XY plane
				transform.Translate(-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);
			}

	}

//	void FixedUpdate ()
//	{
//		float moveHorizontal = Input.GetAxis ("Horizontal");
//		float moveVertical = Input.GetAxis ("Vertical");
//
//		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
//		GetComponent<Rigidbody>().velocity = movement * speed;
//
//		GetComponent<Rigidbody>().position = new Vector3 
//			(
//				Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
//				0.0f, 
//				Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
//			);
//
//		GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
//	}
}