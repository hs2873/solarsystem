using UnityEngine;
using System.Collections;

public class networkscript : MonoBehaviour {
	public Transform playerPrefab;
	// Use this for initialization
	void Start () {
	
	}
	void OnConnectedToServer() {
		Debug.Log ("Came here");
		//Network.Instantiate(playerPrefab, transform.position, transform.rotation, 0);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
