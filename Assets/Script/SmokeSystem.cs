using UnityEngine;
using System.Collections;

public class SmokeSystem : MonoBehaviour {


	public bool		actived = false;

	void Start () {
		this.gameObject.SetActive(actived);
	}

	void Update () {
	}

	public void Activate(bool active)
	{
		actived = active;
		this.gameObject.SetActive (actived);
	}
}
