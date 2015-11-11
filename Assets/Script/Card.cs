using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Card : MonoBehaviour {
	
	public GameObject	press;
	public bool			hasCard = false;
	public AudioClip	getCard;

	private Text		pressText;
	void Start () {
		pressText = press.GetComponent<Text> ();
	}
	
	void Update () {

	}
	
	void OnCollisionStay(Collision collision) {
		if (collision.gameObject.tag == "MainCamera") {
			pressText.text = "Press E to get card";
			if (Input.GetKeyDown(KeyCode.E))
			{
				hasCard = true;
				this.GetComponent<AudioSource>().PlayOneShot(getCard);
				StartCoroutine("tryGetCard");
			}
		}
	}

	IEnumerator tryGetCard()
	{
		yield return new WaitForSeconds (0.2f);
		this.gameObject.SetActive(false);
		pressText.text = "";
	}
}
