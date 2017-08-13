using UnityEngine;
using System.Collections;

public class Ball_Movement : MonoBehaviour {
	
	public float momentum;
	public bool useWideAngleMinimum;
	public int wideAngleMinimum;
	private Vector3 velocity;
	
	// Use this for initialization
	void Start () {
		// Here's the pitch...
		float motionX = momentum;
		float motionY = momentum;
		
		// And... WHEE!
		if (Random.value > .5f)	motionX *= -1;
		if (Random.value > .5f)	motionY *= -1;
		velocity = new Vector3(motionX, motionY, 0.0f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		velocity.z = 0;
		if (useWideAngleMinimum && wideAngleMinimum > 0) {
			if (Mathf.Abs(velocity.y) < wideAngleMinimum) {
				if (velocity.y < 0) {
					velocity.y = -wideAngleMinimum;
				}
				else if (velocity.y > 0) {
					velocity.y = wideAngleMinimum;
				}
			}
		}
		transform.Translate(velocity * Time.deltaTime, Space.World);
	}
	
	void OnCollisionEnter (Collision collision) { 
		// This will only handle collisions w/ other "green" objects; the borders will handle edge collision
		// ... Nix that, we'll handle the edges first.
		if (collision.collider.tag == "edge" || collision.collider.tag == "paddle") {
			ContactPoint target = collision.contacts[0];
			velocity = Vector3.Reflect(velocity, target.normal);
		}
		if (collision.collider.tag == "block") {
			ContactPoint target = collision.contacts[0];
			velocity = Vector3.Reflect(velocity, target.normal);
			Destroy(collision.gameObject);
		}
	}
	// 2013-09-22:
	// This collision code shows signs of the movement we want, but behaves too erratically to be considered
	// an option.
//	void OnCollisionEnter(Collision collision) {
//		// For now, just bounce around.
//		
//		// ... I mean, note our position.
//		Vector3 contactPosition = collision.contacts[0].point;
//		Vector3 ourPosition = rigidbody.position;
//		float gapX = Mathf.Abs(contactPosition.x - ourPosition.x);
//		float gapY = Mathf.Abs(contactPosition.y - ourPosition.y);
//		
//		// And... I guess, do stuff w/ it.
//		Vector3 newMovement = rigidbody.velocity;
//		if (gapX < gapY) {
//			// Reverse our x movement
//			newMovement.x *= -1;
//		}
//		else {
//			newMovement.y *= -1;
//		}
//		rigidbody.velocity = newMovement;
//	}
}
