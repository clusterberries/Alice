using UnityEngine;
using System.Collections;

public class resizeBtn : MonoBehaviour {
	private float speed = 0.05f;
	private bool isOver = false;
	private RectTransform transform;
	// Use this for initialization

	void Start () {
		transform = GetComponent<RectTransform> ();
		transform.localScale = new Vector3(0.5f, 0.5f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		float scale = transform.localScale.x;
		if (isOver) {
			scale = Mathf.Min(scale + speed, 1.0f);
			transform.localScale = new Vector3(scale, scale, 1.0f);
		} else {
			scale = Mathf.Max(scale - speed, 0.5f);
			transform.localScale = new Vector3(scale, scale, 1.0f);
		}
	}

	void OnMouseEnter () {
		isOver = true;
	}

	void OnMouseExit () {
		isOver = false;
	}
}
