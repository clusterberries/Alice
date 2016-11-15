using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;
//using System.Collections.Generic;

public class DragHandler : MonoBehaviour {
	public GameObject collider;
	public game1Ctrl game;
	public float xOffset;
	public float yOffset;

	private SpriteRenderer img;
	private Animator anim;
	private Vector3 startPosition;
	private bool collided = false;
	private bool canBeGragged = true;

	void Start() {
		startPosition = gameObject.transform.position;
		anim = GetComponent<Animator> ();
		img = collider.GetComponent<SpriteRenderer> ();
		img.enabled = false;
	}

	void OnMouseDown() {
		if (canBeGragged) {
			// disable script for 100ms to prevent object jump when user clicks
			canBeGragged = false;
			Invoke ("Enable", 0.1f);
		}
	}

	void Enable() {
		canBeGragged = true;
	}

	void OnMouseDrag() {
		if (canBeGragged) {
			anim.enabled = false;
			Vector3 point = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			point.z += 1;
			point.y += yOffset; // it's a hack, don't touch
			point.x += xOffset; // it's a hack, don't touch
			gameObject.transform.position = point;
		}
	}

	void OnMouseUp() {
		if (!collided) {
			gameObject.transform.position = startPosition;
			anim.enabled = true;
		} else {
			canBeGragged = false;
			img.enabled = true;
			gameObject.SetActive (false);
			game.AddScore ();
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject == collider) {
			collided = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject == collider) {
			collided = false;
		}
	}
}
