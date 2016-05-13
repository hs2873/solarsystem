using UnityEngine;
using System.Collections;

public class maprotator : MonoBehaviour {
	public GameObject confirm;
	public GameObject text;
	public GameObject info;
	float sDistance;
	float pDistance;
	public float ratio;
	public int x;
	float r;
	public Color blu = Color.blue;
	public Renderer rend;

	// Use this for initialization
	void Start () {
		sDistance = Vector3.Magnitude (this.transform.localPosition);
		//pDistance = Vector3.Magnitude (planet.transform.localPosition);
		//ratio = sDistance / pDistance;
		x = 0;
		r = 0.0f;
		rend = GetComponent<Renderer>();
	}

	// Update is called once per frame
	void Update () {
		if (x == 2) {
			transform.rotation = Quaternion.Euler(transform.rotation.x, r*10f, transform.rotation.z);
			r += .2f;
		}
	}

	public void selection(){
		x = 1;
		confirm.SetActive(true);
		//confirm.reset ();
		text.SetActive(true);
	}

	public void confirmed(){
		//
		x = 2;
		confirm.SetActive (false);
		text.SetActive (false);
	}

	public void reached(){
		x = 3;
		confirm.GetComponent<confirm> ().x = 0;
		rend.material.color = blu;
		info.SetActive (true);
	}

	public void deselection(){
		x = 0;
		text.SetActive (false);
	}

}
