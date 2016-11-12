using UnityEngine;
using System.Collections;

public class animOnClick : MonoBehaviour {
	private Animator anim;
	public string animationName;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}

	void OnMouseDown() {
		anim.Play(animationName);
	}
}
