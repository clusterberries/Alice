using UnityEngine;
using System.Collections;

public class ringCtrl : MonoBehaviour {
	private SpriteRenderer sr;
	private game2Ctrl game;
	private Color[] colors = new Color[4];

	// Use this for initialization
	void Start () {
		colors [0] = Color.yellow;
		colors [1] = Color.blue;
		colors [2] = Color.green;
		colors [3] = Color.magenta;

		game = GameObject.Find ("Page4").GetComponent<game2Ctrl>();

		sr = GetComponent<SpriteRenderer> ();
		sr.color = colors[Random.Range(0, 4)];
	}

	void OnMouseDown () {
		game.SetScore ();
		Destroy (gameObject);
	}
}
