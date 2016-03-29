using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour {

	public Transform cat;
	public Rigidbody mouseRB;

	public static int catSpeed;
	public static int mouseSpeed; 

	void Start(){
	
		mouseRB = GetComponent<Rigidbody>();
	
	}

	// Update is called once per frame
	void FixedUpdate () {

		Vector3 forward = this.transform.forward;

		Vector3 distanceToCat = (this.transform.position - cat.position);

		//float angle = ;

		if (Vector3.Angle (cat.transform.position, forward) < 180){
		
			Ray mouseRay = new Ray (transform.position, distanceToCat);
			RaycastHit mouseRayHitInfo = new RaycastHit();

			if ((Physics.Raycast(mouseRay,out mouseRayHitInfo, 100f)) == true){

				if (mouseRayHitInfo.collider.tag == "cat"){

					mouseRB.AddForce (-distanceToCat.normalized * 1000f);

				}

			}
		}
	
	}
}
