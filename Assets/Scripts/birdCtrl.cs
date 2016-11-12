using UnityEngine;
using System.Collections;

public class birdCtrl : MonoBehaviour {
	private Animator birdAnimator;

	// Use this for initialization
	void Start () {
		birdAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0)) {
			// birdAnimator.Play("bird");

			// Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			// RaycastHit hit;
			
			// if(Physics.Raycast (ray, out hit))
			// {
			// 	if(hit.transform.name == "Player")
			// 	{
			// 		Debug.Log ("This is a Player");
			// 	}
			// 	else {
			// 		Debug.Log ("This isn't a Player");                
			// 	}
			// }
		}
	}

	void OnMouseDown() {
		birdAnimator.Play("bird");
	}
}
