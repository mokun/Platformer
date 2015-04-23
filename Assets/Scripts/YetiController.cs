using UnityEngine;
using System.Collections;

public class YetiController : MonoBehaviour {

	private Rigidbody2D _rigidBody;
	private bool _jump;

	private int _health;
	private Animator _animator;
	private bool _grounded;

	// Use this for initialization
	void Start () {
		// just need to ask once
		_rigidBody = GetComponent<Rigidbody2D> (); // find that component and assign // caching a reference
		_animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	//if reading key press or mouse input? do it here
	//if reading input.GetAxis? here or in FixedUpdate
		//_jump = Input.GetButtonDown ("Fire1");
		// has synch issue with FixedUpdate()
		if (!_jump)
			_jump = Input.GetButtonDown ("Fire1");

	}

	void FixedUpdate() {

		if (_jump) {
			_jump = false;
			_rigidBody.AddForce(new Vector2(0,1500)); //transform.forward * 10);
			_animator.SetTrigger("Jumping"); 
			_grounded = false;
			_animator.SetBool("Grounded", false); // after jumping, we want to stay in fall and not immediately go to land
		}

	// we need to change yeti's velocity in every frame
	// before we use navmesh

		var horizontal = Input.GetAxis ("Horizontal");

		// localScale is a Vector3, so contains an x,y,z
		var localScale = transform.localScale;

		if (horizontal < 0) {
			//transform.rotation.y = 180;
			localScale.x = -1; // flip
		} else if (horizontal > 0)
			localScale.x = 1;
		// else if = 0, do nothing


		// Set the transforms localScale
		transform.localScale = localScale ;
		
		
		
		if (horizontal != 0) { // meaning that it's running
			_animator.SetBool ("Running", true);
		} else {
			_animator.SetBool ("Running", false);
		}
		
		// or just _animator.SetBool("Running", horizontal != 0);


		// shortcut b4 Unity 5 rigidbody2D is okay 
		_rigidBody.velocity = new Vector2(horizontal * 20, _rigidBody.velocity.y); 
		// no y velocity, it's zero

	}

	
	void OnCollisionEnter2D(Collision2D collison) {
		// how we land
		if (collison.gameObject.tag == "Platform") {
			_grounded = true;
			_animator.SetBool("Grounded", true); // when we detect the collision
		}
	}
	
	void Awake() {
	}

}
