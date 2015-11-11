using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MachineSwift : MonoBehaviour {
	
	public GameObject	press;
	public Card			card;
	public Door			door;
	public AudioClip	switchDesactivation;

	private Text		pressText;
	void Start () {
		pressText = press.GetComponent<Text> ();
	}
	
	void Update () {
		
	}
	
	void OnCollisionStay(Collision collision) {
		if (collision.gameObject.tag == "MainCamera") {
			if (card.hasCard && !door.open)
				pressText.text = "Press E to active";
			else if (!card.hasCard && !door.open)
				pressText.text = "You need keyCard to active";
			if (Input.GetKeyDown(KeyCode.E) && card.hasCard)
			{
				Transform screen = this.transform.FindChild("screen");
				Transform screen_unlocked = this.transform.FindChild("screen_unlocked");
				this.transform.gameObject.GetComponent<AudioSource>().PlayOneShot(switchDesactivation);
				screen_unlocked.gameObject.SetActive(true);
				screen.gameObject.SetActive(false);
				door.Open();
			}
		}
	}
	
	void OnCollisionExit(Collision collision) {
		pressText.text = "";
	}
}
