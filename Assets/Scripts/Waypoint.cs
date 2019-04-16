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
            id = int.Parse(name);
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
    }
}
