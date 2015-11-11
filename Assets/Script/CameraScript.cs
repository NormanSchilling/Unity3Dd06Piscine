using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public float 			cameraSensitivity = 90;
	public float			normalMoveSpeed = 10.0f;
	public float 			slowMoveFactor = 1.0f;
	public float 			fastMoveFactor = 3.0f;
	public AudioClip		footStep;
	public RectTransform	detectBar;
	public Ventilateur		ventilteur;
	public GameObject		megaphone;

	private float rotationX = 0.0f;
	private float rotationY = 0.0f;
	
	private Vector3 position;
	private Vector3 _basePosition;
	private float	_walk;
		
	public float		minDetect;
	public float		maxDetect;
	public float		currentDetect;
	private	bool		changeMusic = false;
	private AudioClip	musicCurrent;
	private float		speedDetect = 0.0f;
	private bool		alarmed = false;		
	void Start ()
	{
		minDetect = detectBar.anchorMin.x;
		maxDetect = detectBar.anchorMax.x;
		currentDetect = minDetect;
		detectBar.anchorMax = new Vector2(currentDetect, detectBar.anchorMax.y);
		_basePosition = this.transform.position;
		this.GetComponent<AudioSource> ().Play();
	
		Screen.lockCursor = true;
	}
	
	void Update ()
	{
		changeMusic = false;
		rotationX += Input.GetAxis ("Mouse X") * cameraSensitivity * Time.deltaTime;
		rotationY += Input.GetAxis ("Mouse Y") * cameraSensitivity * Time.deltaTime;
		rotationY = Mathf.Clamp (rotationY, -90, 90);
		
		transform.localRotation = Quaternion.AngleAxis (rotationX, Vector3.up);
		transform.localRotation *= Quaternion.AngleAxis (rotationY, Vector3.left);
		
		position = transform.position;

		if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift)) {
			position += transform.forward * normalMoveSpeed * Input.GetAxis ("Vertical") * Time.deltaTime;
			position += transform.right * normalMoveSpeed * Input.GetAxis ("Horizontal") * Time.deltaTime;
			speedDetect = 0.001f;
		} else {
			position += transform.forward * (normalMoveSpeed * slowMoveFactor) * Input.GetAxis ("Vertical") * Time.deltaTime;
			position += transform.right * (normalMoveSpeed * slowMoveFactor) * Input.GetAxis ("Horizontal") * Time.deltaTime;
			speedDetect = 0.0f;
		}

		if (Input.GetAxis ("Vertical") != 0 || Input.GetAxis ("Horizontal") != 0) {
			if (currentDetect < maxDetect)
				currentDetect += speedDetect;
			else if (currentDetect >= maxDetect)
				Application.LoadLevel(0);
			if (Time.timeSinceLevelLoad >= _walk + 0.5f) {
				this.GetComponent<AudioSource> ().PlayOneShot (footStep);
				_walk = Time.timeSinceLevelLoad;
			}
		} else {
			speedDetect = 0.003f;
			if (currentDetect >= minDetect)
				currentDetect -= speedDetect;
		}
		if (currentDetect >= 0.35f && !alarmed) {
			alarmed = true;
			megaphone.GetComponent<AudioSource> ().Play ();
		} else if (currentDetect <= minDetect && alarmed){
			alarmed = false;
			megaphone.GetComponent<AudioSource> ().Stop ();
		}
		detectBar.anchorMax = new Vector2(currentDetect, detectBar.anchorMax.y);
		position.y = 1.79f;
		transform.position = position;

		if (Input.GetKeyDown (KeyCode.End))
		{
			Screen.lockCursor = (Screen.lockCursor == false) ? true : false;
		}
	}
	
}
