using UnityEngine;
using System.Collections;

public class Block_Seeder : MonoBehaviour {
	
	public int countX;
	public int countY;
	
	public int incrementX;
	public int incrementY;
	
	public GameObject block;
	
	public bool lionheadEffect;
	
	// Use this for initialization
	void Start () {
		Vector3 baseLocation = gameObject.transform.position;
		
		// Quick fix for some wonky physics stuff
		if (!lionheadEffect) {
			rigidbody.constraints = RigidbodyConstraints.FreezeAll;
			block.rigidbody.constraints = RigidbodyConstraints.FreezeAll;	
		}
		
		for (int x = 0; x < countX; x++) {
			for (int y = 0; y < countY; y++) {
				Instantiate(block, new Vector3(x * incrementX, y * incrementY, 0.0f) + baseLocation, Quaternion.identity);
			}
		}
	}
}
