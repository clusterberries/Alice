using UnityEngine;
using System.Collections;

public class catCtrl : MonoBehaviour {
	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown() {
		anim.Play("cat");
	}
}
