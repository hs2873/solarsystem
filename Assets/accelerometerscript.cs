using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class accelerometerscript : NetworkBehaviour
{


	public GameObject earth;
	public GameObject sun;
	public GameObject mars;
	public GameObject mercury;
	public GameObject venus;
	public GameObject canvasInfo;
	public GameObject planet;
	public GameObject mapPlanet;
	public int mode;

	public float maxSpeed;

	ArrayList objects = new ArrayList();
	ArrayList reachedPlanets = new ArrayList();
	void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
	{
		var player = GameObject.Find ("space(Clone)");
		Debug.Log (player.name);
		//NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
	}

	void Start()
	{
		Debug.Log ("Script called");
		//objects.Add(earth);
		//objects.Add(mars);
		//objects.Add(mercury);
		//objects.Add(sun);
		//objects.Add(venus);
	}

	void Update()
	{
		// last 'safe' position
		Vector3 position = transform.position;

		// joystick manipulation of spaceship

		// ROTATION // 
		float y = Input.acceleration.y; // y is mapped as pitch
		float z = Input.acceleration.z; // z is mapped as yaw
		// no need for roll in our implementation
		// wlog we can keep the spaceship upright at all times

		transform.Rotate(new Vector3(0, y, z));

		// SPEED //
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
		{
			// get movement of finger since last frame
			Vector2 touchDelta = Input.GetTouch(0).deltaPosition;
			float speed = 1 - touchDelta.y; // because of the orientation of our input devices vs Unity's default orientation, the y axis encodes
			// speed and we need to subtract it from 1
			// speed * maxSpeed now defines the speed of the spaceship

			// move spaceship along its forward axis
			transform.Translate(Vector3.forward * speed * maxSpeed);
		}

		// check that the new position is in bounds
		Vector3 newPosition = transform.position;

		foreach (GameObject o in objects)
		{
			if ((o.transform.position - newPosition).magnitude < o.GetComponent<SphereCollider>().radius + 2)
			{
				transform.position = position; // too close to a planet
				// CHECK HERE IF THE PLANET IS THE GOAL PLANET
				// RELIES ON ADDING A 'GOAL' TAG TO A PLANET WHEN ITS SELECTED
				if (o == planet){
					reached ();
					reachedPlanets.Add(o); // add it to the list of planets the player has reached
					//o.tag.Remove(0); // its no longer a goal
					//o.GetComponents<text>().show; // display information text. maybe add timer?

					// check if the player has visited all the planets
					if (reachedPlanets.Count == 4) 
					{
						// display some sort of 'you won' text
					}
				}
			}
		}

		// update new position
		newPosition = transform.position;

		// change these bounds to what is appropriate for newest iteration of project
		if (newPosition.x > 0 || newPosition.x < 0 || newPosition.y > 0 || newPosition.y < 0 || newPosition.z > 0 || newPosition.z < 0)
		{
			transform.position = position; // out of bounds
		}
	}

	public void callWay(GameObject planet, GameObject mapPlanet, GameObject info){
		this.planet = planet;
		this.mapPlanet = mapPlanet;
		this.canvasInfo = info;
	}

	public void reached(){
		mapPlanet.GetComponent<maprotator> ().reached();
		canvasInfo.SetActive (true);
	}
}