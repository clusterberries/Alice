using UnityEngine;
using System.Collections;

public class catFadeCtrl : MonoBehaviour {
	private Animator anim;
	private bool isShown = false;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	void OnMouseDown() {
		isShown = !isShown;
		anim.Play(isShown ? "catFade" : "catShow");
	}
}
