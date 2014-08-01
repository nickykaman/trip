using UnityEngine;
using System.Collections;

public class BackgroundTrees : MonoBehaviour {

	public GameObject tree;
	// Use this for initialization
	void Start () {
		int max = (int)(Random.value * 5) + 5;
		for (int i = 0; i < max; i++) {
			GameObject treeclone =
				Instantiate (tree, this.transform.position + new Vector3(Random.value*100-50,0,30 + Random.value*40), Quaternion.Euler(new Vector3(0,0,Random.value*60-30))) as GameObject;
			treeclone.transform.localScale*=(Random.value+1);
			print (2-(treeclone.transform.position.z-30)/40);

			treeclone.GetComponent<SpriteRenderer>().color = new Color(.3f, .5f, .5f, 1f);;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
