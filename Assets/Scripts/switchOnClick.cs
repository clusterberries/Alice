using UnityEngine;
using System.Collections;

public class switchOnClick : MonoBehaviour {
	public GameObject light;

	// Use this for initialization
	void Start () {
		light.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		light.SetActive(!light.activeSelf);
	}
}
