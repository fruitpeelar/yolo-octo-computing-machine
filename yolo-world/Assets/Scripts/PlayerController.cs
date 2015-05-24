using UnityEngine;
using System.Collections;


[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}


public class PlayerController : MonoBehaviour {
	// Update is called once per frame
	public float speed;
	public float tilt;
	public Boundary boundary;

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		Rigidbody rb3d = GetComponent<Rigidbody> ();
		rb3d.velocity = movement * speed;
		rb3d.position = new Vector3 
			(
				Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
				0.0f, 
				Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
				);
		
		rb3d.rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}
}
