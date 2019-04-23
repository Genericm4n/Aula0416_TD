using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

    #region Variables
    [Header ("Target")]
    public Transform target;
    public string targetTag;

    [Header ("Moviment")]
    public float velMove = 1f;

    [Header ("Rotation")]
    public float velRot = 1f;
    public bool lookAt = false;
    #endregion
	
	void Update ()
    {
        Move();
        Rotate();
	}

    private void Move()
    {
        //Se a variável ''lookAt'' estiver marcada ou se não possuímos uma informação de target, movimentamos em linha reta
        if (lookAt || target == null)
        {
            //Movimentando-se em linha reta
            transform.Translate(Vector3.forward * velMove * Time.deltaTime);
        }
        //Caso contrário, se tivermos um target
        else if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.Translate(direction * velMove * Time.deltaTime, Space.World);
        }
    }

    private void Rotate()
    {
        if (lookAt && target != null)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), Time.deltaTime*velRot);
        }
    }
}
