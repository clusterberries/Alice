using UnityEngine;
using System.Collections;

public class roseCtrl : MonoBehaviour {
	private Animator anim;
	private game3Ctrl game;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		game = GameObject.Find ("Page6").GetComponent<game3Ctrl>();
	}

	void OnMouseDown() {
		anim.Play("rose");
		game.AddScore ();
	}
}
