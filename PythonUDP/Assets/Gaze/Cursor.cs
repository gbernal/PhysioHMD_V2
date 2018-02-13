using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Cursor : MonoBehaviour {
	GameGaze gaze;
	public GameObject cursor, lighter;
	float x, y;
    void Start()
    {
		gaze = GameObject.Find ("Gaze").GetComponent<GameGaze>();
    }

	void Update () {
		gaze.GetPos (lighter.gameObject, ref x, ref y);
		cursor.transform.localPosition = new Vector2 ((x - 0.5f) * 1512, (0.5f - y) * 1680);
	}
}
