using UnityEngine;
using System.Collections;

public class Walk : MonoBehaviour {
	private Animator animator; 
	public int speed;
	public int jumpheight;
	private int maxjumps = 1;
	private int jumps = 0;
	private bool grounded = true;
	private GameObject currentLedge;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		jumps = maxjumps;
	}
	
	// Update is called once per frame
	void Update () {
		if (!animator.GetBool("ledge")){

			if (Input.GetKey(KeyCode.LeftArrow)) {
				this.rigidbody2D.velocity = new Vector2(-1*speed,this.rigidbody2D.velocity.y);
				animator.SetBool ("run", true);
				this.transform.localScale = new Vector3(-1,1,1);
			}
			else if (Input.GetKey(KeyCode.RightArrow)) {
				this.rigidbody2D.velocity = new Vector2(speed,this.rigidbody2D.velocity.y);
				animator.SetBool ("run", true);
				this.transform.localScale = new Vector3(1,1,1);

			}
			else {
				this.rigidbody2D.velocity = new Vector2(0, this.rigidbody2D.velocity.y);
				animator.SetBool ("run", false);
			}

			if (this.rigidbody2D.velocity.y < 0){
				this.collider2D.isTrigger = false;
				this.transform.GetChild(0).collider2D.isTrigger = false;
			}
		}

		if (jumps > 0 && Input.GetKeyDown(KeyCode.UpArrow)){
			if (currentLedge != null){
				currentLedge.collider2D.enabled = true;
			}
			if (animator.GetBool("ledge")){
				animator.SetBool ("ledge", false);
				this.rigidbody2D.gravityScale = 3;
				this.rigidbody2D.fixedAngle = false;
			}
			this.rigidbody2D.velocity = (new Vector2(this.rigidbody2D.velocity.x,jumpheight));
			if (animator.GetBool("jump")){
				jumps--;
			}
			animator.SetBool ("jump", true);
			currentLedge = null;
		}

		if (animator.GetBool("ledge") && Input.GetKeyDown (KeyCode.DownArrow)) {
			animator.SetBool ("ledge", false);
			animator.SetBool ("jump", true);
			this.rigidbody2D.gravityScale = 3;
			this.rigidbody2D.fixedAngle = false;
			currentLedge.collider2D.enabled = false;
		}
	}
	void OnCollisionEnter2D(Collision2D other) {
		if (other.contacts [0].point.y > other.transform.position.y) {
			animator.SetBool ("jump", false);
			jumps = maxjumps;
			grounded = true;
		}
		//Collide with Ledge
		if (other.gameObject.tag.Equals ("ledge")) {
			if (currentLedge != null){
				currentLedge.collider2D.enabled = false;
			}
			currentLedge = other.gameObject;
			jumps = maxjumps;
			this.transform.position = other.gameObject.transform.position;	
			this.rigidbody2D.velocity = Vector2.zero;
			animator.SetBool ("ledge", true);
			this.collider2D.isTrigger = true;
			this.transform.GetChild(0).collider2D.isTrigger = true;
			this.rigidbody2D.gravityScale = 0;
			this.rigidbody2D.fixedAngle = true;
		}
	}

}
