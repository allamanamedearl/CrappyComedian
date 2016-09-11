using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public Vector3 LeftDodge; //public variables AaaaBbbb
	public Vector3 RightDodge;
	public Vector3 UpDodge;
	public Vector3 DownDodge;

	public float speed;

	private Vector3 _startPos;//private variables _aaaBbb
	private Vector3 _endPos;
	private Vector3 _parentPos;
	private bool _isLerping;
	private float _startTime; //local to function variables aaaBbb
	// Use this for initialization
	void Start () {
		_parentPos=GetComponentInParent<Transform>().position;
		Debug.Log(_parentPos);
		_startPos = transform.position +_parentPos;
		_endPos = transform.position;
		_isLerping = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		bool isKeyPressed = false;
		if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			_endPos = LeftDodge;
			isKeyPressed = true;
		}
		if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			_endPos = RightDodge;
			isKeyPressed = true;
		}
		if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			_endPos = DownDodge;
			isKeyPressed = true;
			Debug.Log(_endPos);
			Debug.Log("Down arrow Pressed");
		}
		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			_endPos = UpDodge;
			isKeyPressed = true;
		}
		if(isKeyPressed)
		{
			_startPos = transform.localPosition;
			_isLerping = true;
			_startTime = Time.time;
		}
		if(_isLerping)
		{
			//lerp
			float distTraveled = (Time.time-_startTime)*speed;
			float totalDistance = Vector3.Distance(_startPos,_endPos);
			float percentageComplete = distTraveled/totalDistance;

			transform.localPosition = Vector3.Lerp(_startPos,_endPos,percentageComplete);
			if(percentageComplete>=1.0f)
			{
				_isLerping = false;
			}

		}
//		if(animationName !="")
//		{
//			currAnimation= GetComponent<Animation>();
//			currAnimation[animationName].wrapMode = WrapMode.Once;
//			currAnimation.Play(animationName);
//
//		}

	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Projectile")
		{
			Score.UpdateHealth(-1);
			Destroy(other.gameObject);
		}
	}
}
