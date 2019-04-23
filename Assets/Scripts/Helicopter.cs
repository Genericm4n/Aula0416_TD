using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour {

    FollowTarget followTarget;

	void Start ()
    {
        followTarget = GetComponent<FollowTarget>();
	}
	
	void Update ()
    {		
	}

    private void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("Waypoint"))
        {
            Waypoint waypoint =  c.GetComponent<Waypoint>();
            Waypoint waypointP = waypoint.waypointP;
            followTarget.target = waypointP.transform;
        }
    }
}
