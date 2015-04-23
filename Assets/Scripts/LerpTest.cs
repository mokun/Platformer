using UnityEngine;
using System.Collections;

public class LerpTest : MonoBehaviour {

	private float _lerpValue;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		_lerpValue = Mathf.Lerp(1,10,.1f); // move from 1 to 10 at 10% each step
		Debug.Log ("_lerpValue: " + _lerpValue);
	}
}
