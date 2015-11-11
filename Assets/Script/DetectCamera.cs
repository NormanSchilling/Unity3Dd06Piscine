using UnityEngine;
using System.Collections;

public class DetectCamera : MonoBehaviour {
	
	public float		speed = 0.4f;
	public float		rotateCam = 30.0f;
	public AudioClip	attractAttention;
	public CameraScript	player;
	public Ventilateur	ventilateur;

	private RectTransform	_rect;
	private Vector3			_baseRotation;
	void Start () {
		_baseRotation = this.transform.localEulerAngles;
	}

	void Update ()
	{
		Rotation ();
	}

	void Rotation()
	{
		if (_baseRotation.y - rotateCam > transform.rotation.eulerAngles.y || _baseRotation.y + rotateCam < transform.rotation.eulerAngles.y)
			speed *= -1;
		this.transform.Rotate (new Vector3 (0.0f, speed, 0.0f));
	}

	void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.tag == "MainCamera") {
			Debug.Log("coucou toi");
			collision.gameObject.GetComponent<AudioSource>().PlayOneShot(attractAttention);
		}
	}
	void OnTriggerStay(Collider collision)
	{
		if (collision.gameObject.tag == "MainCamera") {
			if (!ventilateur.smoke.actived)
			{
				if (player.currentDetect < player.maxDetect)
					player.currentDetect += 0.007f;
			}
			else
			{
				if (player.currentDetect < player.maxDetect)
					player.currentDetect += 0.002f;
			}
		}
	}
}
