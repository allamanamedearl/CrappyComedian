using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	private static int health = 10;
	// Use this for initialization
	void Start () {
		Debug.Log("Health = "+health);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	static public void UpdateHealth(int amount)
	{
		health+=amount;

		Debug.Log("Health = "+health);
	}
}
