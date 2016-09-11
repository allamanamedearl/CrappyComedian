using UnityEngine;
using System.Collections;

public class SpawnThrowables : MonoBehaviour {
	public float LeftMostRange;
	public float RightMostRange;
	public GameObject Throwable;

	public int Speed;

	private float _lastUpdate;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		_lastUpdate +=Time.deltaTime;

		if(_lastUpdate>=5.0f)//every 5 seconds
		{
			TriggerProjectile();
			_lastUpdate = 0;
		}
	}

	Vector3 RandomizeSpawnPoint()
	{
		float xPos = Random.Range(LeftMostRange,RightMostRange);
		return new Vector3(xPos,-3.68f,-2.97f);
	}
	void TriggerProjectile()
	{
		Vector3 spawnPoint = RandomizeSpawnPoint();
		Vector3 targetPos = GameObject.FindGameObjectWithTag("Target").transform.position;
		Vector3 direction = targetPos-transform.position;

		Instantiate(Throwable,spawnPoint,Quaternion.LookRotation(targetPos));
		Throwable.GetComponent<Rigidbody>().velocity = direction * Speed;
	}
}
