using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour {

    public GameObject projPreFab;
    public Transform spawnPoint;

    public float delay = 1.0f;
	
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(projPreFab, spawnPoint.position, projPreFab.transform.rotation);
        }
	}

    /*IEnumerator Fire()
    {
        yield return new WaitForSeconds(delay);

        
    }*/
}
