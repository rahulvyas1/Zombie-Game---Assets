using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour {
	public GameObject player;
	private float zombieSpeed = 0.5f;
	GameObject[] Bottles;
	// Use this for initialization
	void Start () {
		
	}
	void FixedUpdate () {
		player = GameObject.Find ("Player");
		Bottles = GameObject.FindGameObjectsWithTag ("collectAbleBottle");
		if ((player.transform.position - transform.position).magnitude <= 3) {
		}
		else if ((player.transform.position - transform.position).magnitude > 3)
		transform.Translate ((player.transform.position-transform.position)*zombieSpeed*Time.deltaTime);
	}

	void OnTriggerEnter(Collider coll){
		foreach (GameObject bottle in Bottles) {
			if (coll.gameObject == bottle) {
				Destroy (this.gameObject);
				Destroy (bottle);
			}

		}
	}
}
