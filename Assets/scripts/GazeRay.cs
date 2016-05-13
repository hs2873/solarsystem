/*============================================================================== 
 * Copyright (c) 2015 Qualcomm Connected Experiences, Inc. All Rights Reserved. 
 * ==============================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GazeRay : MonoBehaviour
{
    #region PUBLIC_MEMBER_VARIABLES
    public ViewTrigger[] viewTriggers;
    #endregion // PUBLIC_MEMBER_VARIABLES
	GameObject target;
	GameObject temp;
	public GameObject confirmCube;


    #region MONOBEHAVIOUR_METHODS
    void Update()
    {
        // Check if the Head gaze direction is intersecting any of the ViewTriggers
        RaycastHit hit;
        Ray cameraGaze = new Ray(this.transform.position, this.transform.forward);
        Physics.Raycast(cameraGaze, out hit, Mathf.Infinity);
		if (hit.collider != null) {
        	foreach (var trigger in viewTriggers)
        	{
            	trigger.Focused = hit.collider && (hit.collider.gameObject == trigger.gameObject);
        	}
			
			
				if (confirmCube.GetComponent<confirm> ().x == 1) {
					return;
				}
				//Debug.Log ("Something was hit");
				Debug.Log("raycast");
				//
				if(hit.collider.tag == "mapPlanet"){
					target = hit.collider.gameObject;
					if((temp != null) && (temp != target)){
						temp.GetComponent<maprotator> ().deselection();
					}
					Debug.Log("raycast hit");

					target = hit.collider.gameObject;
					if (target.GetComponent<maprotator> ().x == 0) {
						target.GetComponent<maprotator> ().selection();
						temp = target;
					}
					//if (iTarget.GetComponent<Event Target Behavior> ()) {

					//}
				}
				if(hit.collider.tag == "confirm"){
					Debug.Log("confirm hit");

					target = hit.collider.gameObject;
					if (target.GetComponent<confirm> ().x == 0) {
						target.GetComponent<confirm> ().confirming(temp);
					}

				}
			}
    }
    #endregion // MONOBEHAVIOUR_METHODS
}

