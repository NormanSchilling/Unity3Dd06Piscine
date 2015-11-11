using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ventilateur : MonoBehaviour {

	public SmokeSystem 	smoke;
	public GameObject	press;

	private Text		pressText;
	void Start () {
		pressText = press.GetComponent<Text> ();
	}

	void Update () {

	}

	void OnCollisionStay(Collision collision) {
		if (collision.gameObject.tag == "MainCamera") {
			if (smoke.actived)
				pressText.text = "Press E to desactive";
			else
				pressText.text = "Press E to active";
			if (Input.GetKeyDown(KeyCode.E) && !smoke.actived)
				smoke.Activate(true);
			else if (Input.GetKeyDown(KeyCode.E) && smoke.actived)
				smoke.Activate(false);
		}
	}

	void OnCollisionExit(Collision collision) {
		pressText.text = "";
	}
}
