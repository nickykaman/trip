using UnityEngine;
using System.Collections;

public class SpawnTree : MonoBehaviour {
	public bool first = true;
	public GameObject type;
	// Use this for initialization
	void Start () {

		if (first) {
			for (int i = 0; i < Mathf.RoundToInt(Random.value*3); i++){
				GameObject clone;
				clone = Instantiate (type, this.transform.position + new Vector3((Random.value*5-2.5f),(Random.value/2 +1),0), Random.rotation) as GameObject;
				if (Random.value < .3){
					clone.GetComponent<SpawnTree>().first = false;
				}
			}

		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
