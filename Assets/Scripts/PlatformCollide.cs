using UnityEngine;
using System.Collections;

public class PlatformCollide : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D other){
		this.transform.parent.SendMessage ("collided", other);
	}
}	
