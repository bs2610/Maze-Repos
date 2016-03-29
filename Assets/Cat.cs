using UnityEngine;
using System.Collections;

public class Cat : MonoBehaviour {

	public GameObject mouseBod;
	public Transform mouse;
	public Rigidbody catRB;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		Vector3 forward = this.transform.forward;

		Vector3 distanceToMouse = (this.transform.position - mouse.position);

	
		if (mouse == null) {
			return;
		}

		if (Vector3.Angle (mouse.transform.position, forward) < 90) {

			Ray catRay = new Ray (transform.position, distanceToMouse);
			RaycastHit catRayHitInfo = new RaycastHit ();

			if ((Physics.Raycast (catRay, out catRayHitInfo, 100f)) == true) {

				if (catRayHitInfo.collider.tag == "mouse") {

					if (catRayHitInfo.distance < 5f) {

						Destroy (mouseBod);
					} else {
						catRB.AddForce (distanceToMouse.normalized * 1000f);
					}

				}
			}
		}
	}
}
