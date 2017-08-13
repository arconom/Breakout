using UnityEngine;
using System.Collections;

public class AI_Paddle_Controller : MonoBehaviour {

	public GameObject trackingTarget;
	public float momentum;
	public bool protectBottom;
	
	void FixedUpdate () {
		DetermineMovement();
	}
	
	void DetermineMovement() {
		// horizontalMovement needs to be either 1, or a percentage of the paddle's
		//  width to slow paddle movement the closer the ball gets to its center
		float horizontalMovement = 0.0f;
		
		float paddleX = transform.position.x;
		float paddleY = transform.position.y;
		float ballX = trackingTarget.transform.position.x;
		float ballY = trackingTarget.transform.position.y;
		float traversal = Mathf.Abs(paddleX - ballX);
		
		// Determine whether we should move towards or away from the ball...
		bool moveTowards = false;
		
		if (protectBottom) {
			if (paddleY > ballY) {
				moveTowards = true;	
			}
		}
		else {
			if (paddleY < ballY) {
				moveTowards = true;
			}
		}
		
		// Now then, let's make a move.
		if (moveTowards) {
			if (traversal > (rigidbody.transform.localScale.x / 2))	{
				horizontalMovement = 1.0f;
			}
			else {
				// Damn, now we need to figure out that percentage...
				horizontalMovement = traversal / (rigidbody.transform.localScale.x / 2);
			}
			
			// Now that we've got our simulated axial movement...
			if (ballY > paddleY) {
				horizontalMovement *= -1;
			}
			
			// Freeze the paddle and move it wherever the AI's trying to move it
			rigidbody.velocity = new Vector3(0.0f, 0.0f, 0.0f);
			rigidbody.AddForce(new Vector3(horizontalMovement * momentum, 0.0f, 0.0f), ForceMode.Impulse);
		}
		else {
			
		}
	}
}