using UnityEngine;
using System.Collections;

public class SpawnPlatform : MonoBehaviour {
	bool complete = false;
	public int height = 0;
	// Use this for initialization
	void Start () {
		GameObject plat = this.transform.GetChild (2).gameObject;
		Vector3 tempLeft = this.transform.GetChild (0).transform.localPosition;
		tempLeft.x = -(plat.renderer.bounds.max.x - plat.renderer.bounds.min.x)/2;
		tempLeft.y -= .2f;
		this.transform.GetChild (0).transform.localPosition = tempLeft;
		Vector3 tempRight = this.transform.GetChild (1).transform.localPosition;
		tempRight.x = (plat.renderer.bounds.max.x - plat.renderer.bounds.min.x)/2;
		tempRight.y -= .2f;
		this.transform.GetChild (1).transform.localPosition = tempRight;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void collided(Collision2D other) {
		if (!complete && other.transform.tag.Equals("Player")) {
			complete = true;

			if (this.name.Contains("Middle")){
				spawnPlatform (-1, "LeftPlatform_");
				spawnPlatform (1, "RightPlatform_");
			}
			else if (this.name.Contains ("Left") && GameObject.Find ("MiddlePlatform_"+(height+1)) == null){
				spawnPlatform (1, "MiddlePlatform_");
			}
			else if (this.name.Contains ("Right") && GameObject.Find ("MiddlePlatform_"+(height+1)) == null){
				spawnPlatform (-1, "MiddlePlatform_");
			}

		}
	}

	void spawnPlatform(int side, string name){
		GameObject newPlatform1 = 
			Instantiate (GameObject.Find ("MiddlePlatform_0"), this.transform.position, Quaternion.identity) as GameObject;
		newPlatform1.GetComponent<SpawnPlatform>().height = height+1;
		setNewPlatform (newPlatform1, side);
		newPlatform1.name = name + newPlatform1.GetComponent<SpawnPlatform>().height;
	}

	void setNewPlatform(GameObject platform, int side){
		platform.transform.GetChild(2).transform.localScale = new Vector3(Random.value*1.5f+2,1,1);
		platform.transform.position += new Vector3 ((10+10*platform.transform.localScale.x)*side, 5, 0);

	}
}
