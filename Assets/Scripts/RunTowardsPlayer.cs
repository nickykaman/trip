using UnityEngine;
using System.Collections;

public class RunTowardsPlayer : MonoBehaviour {

	GameObject player;
	public int speed;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").transform.GetChild(0).gameObject;
		StartCoroutine (DoCheck());
	}
	
	// Update is called once per frame
	void Update () {

						
	}

	void goTowards(){
			if (player.transform.position.x < this.transform.position.x) {
					rigidbody2D.velocity = new Vector2 (-1 * speed, this.rigidbody2D.velocity.y);
					if (transform.localScale.x < 0) {
							transform.localScale += new Vector3 (-transform.localScale.x * 2, 0, 0);
					}
			} else {
					rigidbody2D.velocity = new Vector2 (1 * speed, this.rigidbody2D.velocity.y);
					if (transform.localScale.x > 0) {
							transform.localScale += new Vector3 (-transform.localScale.x * 2, 0, 0);
					}
			}
	}

	IEnumerator DoCheck() {
		while (true) {
						goTowards ();
						yield return new WaitForSeconds (.5f);
				}
	}
}
