using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Map : MonoBehaviour {

	public bool			open = false;
	public GameObject	press;

	private float		_speed = 0.01f;
	private Text		pressText;
	private Vector3		_basePosition;
	void Start () {
		_basePosition = this.transform.position;
		pressText = press.GetComponent<Text> ();
	}
	
	void Update () {
		if (open) {
			if (this.transform.position.z < _basePosition.z + 1.5f)
				this.transform.Translate(0.0f, 0.0f, _speed);
		}
	}
	
	void OnCollisionStay(Collision collision) {
		if (collision.gameObject.tag == "MainCamera") {
			if (open)
				pressText.text = "Press E to active";
			else
				pressText.text = "";
			if (Input.GetKeyDown(KeyCode.E) && !open)
			{
				open = true;
			}
		}
	}
	
	void OnCollisionExit(Collision collision) {
		pressText.text = "";
	}
}
