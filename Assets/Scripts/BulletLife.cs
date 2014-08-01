using UnityEngine;
using System.Collections;

public class BulletLife : MonoBehaviour {

	// Use this for initialization
	void Start(){
		Destroy(gameObject, .5f);
	}
}
