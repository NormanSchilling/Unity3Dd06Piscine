using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public bool			open = false;
	public AudioClip	openDoor;

	private float		_speed = 0.01f;
	private Vector3		_basePosition;
	void Start () {
		_basePosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (open) {
			if (this.transform.position.y < _basePosition.y + 2.5f)
				this.transform.Translate(0.0f, _speed, 0.0f);
		}
	}

	public void Open()
	{
		this.GetComponent<AudioSource>().PlayOneShot(openDoor);
		open = true;
	}

}
