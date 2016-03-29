using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Movement : MonoBehaviour {

	public float mouseSpeed;
	public float catSpeed;

	public GameObject pizza;
	public GameObject rat; 

	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.R)) {
			SceneManager.LoadScene ("y");
		}

		pizza.transform.Translate (Vector3.forward * mouseSpeed * Time.deltaTime);

		rat.transform.Translate (Vector3.forward * mouseSpeed * Time.deltaTime);
	}

	void FixedUpdate(){

		GetComponent<Rigidbody> ().velocity = transform.forward * 10f + Physics.gravity;

		Ray moveRay = new Ray (transform.position, transform.forward);

		if(Physics.SphereCast(moveRay, 0.3f, 3f)){
			int randomNumber = Random.Range (0, 2);
			if (randomNumber == 0) {
				transform.Rotate (0f, -90f, 0f);
			} else {
				transform.Rotate (0f, 90f, 0f);
			}
		}

	}
}
