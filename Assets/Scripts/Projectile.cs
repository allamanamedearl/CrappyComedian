using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	//we spawn the projectile in SpawnThrowables giving it a certain velocity
	//this code just makes sure that it gets destroyed in case it misses
	//the player
	public int LifetimeSec = 5;
	// Use this for initialization
	void Start () {
		Destroy(gameObject,LifetimeSec);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
