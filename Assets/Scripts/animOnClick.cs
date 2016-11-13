using UnityEngine;
using System.Collections;

public class animOnClick : MonoBehaviour {
	private Animator anim;
	public string animationName;
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();
	}

	void OnMouseDown() {
		if (anim != null) {
			anim.Play(animationName);
		}
		if (audioSource != null) {
			audioSource.Play();
		}
	}
}
