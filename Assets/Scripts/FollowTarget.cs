using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

    #region Variables
    [Header ("Target")]
    public Transform target;
    public string targetTag;
    public bool searchProximity;

    [Header ("Moviment")]
    public float velMove = 3.0f;

    [Header ("Rotation")]
    public float velRot = 3.0f;
    public bool lookAt = false;
    #endregion
	
	void Update ()
    {
        SearchTarget();
        Move();
        Rotate();
	}

    private void SearchTarget()
    {
        // Validamos se já não temo um alvo definido e se há uma tag definida
        if (targetTag == "" || (!searchProximity && target != null))
        {
            //Nesting - alinhamento de itens
            //Encerrar o método
            return;
        }

        // Escrever minha lógica - Procurar Target
        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);
        Transform possibleTarget = null;

        foreach (GameObject checkTarget in targets)
        {
            float checkDist = Vector3.Distance(checkTarget.transform.position, transform.position);
        

            if(possibleTarget == null || checkDist < Vector3.Distance(possibleTarget.transform.position, transform.position))
            {
                possibleTarget = checkTarget.transform;
            }
        }

        if(possibleTarget != null)
        {
            target = possibleTarget;
        }
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
