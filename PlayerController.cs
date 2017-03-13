using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private float speed = 10;
	private float rotationSpeed = 70;
	GameObject[] collectableWineBottles;
	public GameObject throwableWineBottlePrefab;
	private float thrownBottleSpeed = 2000;


	void Start(){

	}

	void FixedUpdate () {
		collectableWineBottles = GameObject.FindGameObjectsWithTag ("collectAbleBottle");


		if(Input.GetKey (KeyCode.W)){
			transform.Translate (Vector3.forward*speed*Time.deltaTime);
		}
		if(Input.GetKey (KeyCode.S)){
			transform.Translate (Vector3.back*speed*Time.deltaTime);
		}
		if(Input.GetKey (KeyCode.D)){
			
			transform.eulerAngles += new Vector3 (0,rotationSpeed*Time.deltaTime,0);
		}
		if(Input.GetKey (KeyCode.A)){
			transform.eulerAngles -= new Vector3 (0,rotationSpeed*Time.deltaTime,0);
		
		}
		if(Input.GetKeyDown(KeyCode.Space)){
			if (GameManager.bottlesInInventory > 0) {
				Vector3 thrownBottlePos = transform.position + transform.forward * 2;
				thrownBottlePos = transform.position + transform.up ;
				GameObject thrownBottle = (GameObject)Instantiate (throwableWineBottlePrefab,thrownBottlePos, transform.rotation);
				thrownBottle.GetComponent <Rigidbody> ().AddForce (transform.forward * thrownBottleSpeed*Time.deltaTime,ForceMode.Impulse);
				GameManager.bottlesInInventory--;
			}
		}
		
	} 

	void OnTriggerEnter(Collider coll){
		foreach (GameObject bottle in collectableWineBottles) {
			if (coll.gameObject == bottle) {
				//has collected bottle
				GameManager.bottlesInInventory+=1;

			}
		}
	}


}
