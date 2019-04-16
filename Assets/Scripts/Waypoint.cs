using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Waypoint : MonoBehaviour {

    [Header("Waypoints")]
    [Tooltip("List with all waypoints.")]

    private Waypoint[] waypoints;

    private int indexActual = -1;

    private Waypoint waypointA;
    private Waypoint waypointP;

	private void Start ()
    {
        LoadWaypointSystem();
	}

    private void Update()
    {
    }

    private void LoadWaypointSystem()
    {
        FreshWaypointActual();

        FreshWaypoints();

        LinkWaypoint();
    }

    private void FreshWaypointActual()
    {
        indexActual = GetIdWaypoint(gameObject.name);
    }

    private int GetIdWaypoint(string name)
    {
        name = name.Replace("waypoint (","");
        name = name.Replace(")", "");

        int id = -1;

        try
        {
            id = int.Parse(name) -1;
        }
        catch (Exception)
        {

            Debug.LogError("Ouch! An error occurred. Make sure Waypoint has a correct default name, 'waypoint (number)'.");
        }

        return id;
    }

    private void FreshWaypoints()
    {
        waypoints = FindObjectsOfType<Waypoint>();
        waypoints = waypoints.OrderBy(object0 => GetIdWaypoint(object0.name)).ToArray();
    }

    private void LinkWaypoint()
    {
        int indexA = indexActual -1;
        int indexP = indexActual + 1;

        DefineWaypoint(ref waypointA, indexA);
        DefineWaypoint(ref waypointP, indexP);
    }

    private void DefineWaypoint(ref Waypoint waypoint, int index)
    {
        if(index < 0)
        {
            index = waypoints.Length - 1;
        }
        else if(index == waypoints.Length)
        {
            index = 0;
        }

        waypoint = waypoints[index];
    }

    private void OnDrawGizmos()
    {
        LoadWaypointSystem();

        if(waypointP != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, waypointP.transform.position);
        }
    }
}
