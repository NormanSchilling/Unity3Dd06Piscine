using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Document : MonoBehaviour {

	public bool			hasDoc = false;
	public GameObject	press;

	private Text		pressText;
	void Start () {
		pressText = press.GetComponent<Text> ();
	}
	
	void Update () {
	}
	
	void OnCollisionStay(Collision collision) {
		if (collision.gameObject.tag == "MainCamera") {
			if (!hasDoc)
				pressText.text = "Press E to take";
			else
				pressText.text = "";
			if (Input.GetKeyDown(KeyCode.E) && !hasDoc)
			{
				hasDoc = true;
				Application.LoadLevel(0);
			}
		}
	}
	
	void OnCollisionExit(Collision collision) {
		pressText.text = "";
	}
}
