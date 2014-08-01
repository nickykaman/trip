using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	private Animator animator; 
	// Use this for initialization
	public GameObject bullet;
	public int speed;
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			animator.SetTrigger("shoot");
			GameObject clone;
			clone = Instantiate (bullet, this.transform.position, this.transform.rotation) as GameObject;
			clone.rigidbody2D.AddForce(this.transform.right*speed*transform.parent.transform.localScale.x);
		}

	}
}
