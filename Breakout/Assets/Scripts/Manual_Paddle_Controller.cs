using UnityEngine;
using System.Collections;

public class Manual_Paddle_Controller : MonoBehaviour {
	
	public float momentum;
	
	// Update is called once per frame
	void Update () {
		float horizontalMovement = Input.GetAxis("Horizontal");
		
		rigidbody.velocity = new Vector3(0.0f, 0.0f, 0.0f);
		rigidbody.AddForce(new Vector3(horizontalMovement * momentum, 0.0f, 0.0f), ForceMode.Impulse);
	}
}
