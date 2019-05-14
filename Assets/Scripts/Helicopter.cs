using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour {

    FollowTarget followTarget;

    public GameObject explosionPreFab;
    public Rigidbody rb;
    public float forceTorque = 200.0f;


    void Start ()
    {
        followTarget = GetComponent<FollowTarget>();
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

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Projétil"))
        {
            Destroy(other.gameObject);

            rb.isKinematic = false;
            rb.useGravity = true;

            Instantiate(explosionPreFab, transform.position, explosionPreFab.transform.rotation);

            rb.AddTorque(Vector3.up * forceTorque * Random.Range(0, 5));
            rb.AddTorque(Vector3.right * forceTorque);
        }
        else if (other.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject);

            Instantiate(explosionPreFab, transform.position, explosionPreFab.transform.rotation);
        }
    }
}
