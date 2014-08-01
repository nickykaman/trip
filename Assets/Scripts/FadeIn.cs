using UnityEngine;
using System.Collections;

public class FadeIn : MonoBehaviour {
	
	float Fade = 0;
	public bool fadeIn = true;
	private SpriteRenderer sr;
	void Start(){
		sr = this.GetComponent<SpriteRenderer> ();
	}
	// Update is called once per frame
	void Update () {
		if (Fade < 1) {
			Fade += .02f;
		}
		if (fadeIn) {
			sr.color = new Color(1f,1f,1f,Fade);
		}
	}
}

