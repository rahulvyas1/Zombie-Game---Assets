using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Microsoft.Win32;
using UnityEngine.UI;

public class ZombieManager : MonoBehaviour {
	public GameObject zombiePrefab;
	public GameObject zombieInstance;
	public float R = 5;
	public GameObject player;
	void Start(){
		//zombieInstance = Instantiate (zombiePrefab, new Vector3(5,5,0), Quaternion.identity) as GameObject;
		InstantiateZombie ();
		InstantiateZombie ();
		InstantiateZombie ();
	}
	void InstantiateZombie(){
		Vector2 randPos = Random.insideUnitCircle.normalized * R;
		Vector2 instPos = new Vector2( player.transform.position.x,player.transform.position.y) + randPos;
		Instantiate (zombiePrefab,new Vector3 (instPos.x,1,instPos.y),Quaternion.identity);
	}
}
