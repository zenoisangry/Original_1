using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : LivingEntity
{
    NavMeshAgent pathFinder;
    Transform target;

    public override void Start()
    {
        base.Start();
        StartCoroutine(UpdatePath());
    }
    IEnumerator UpdatePath()
    {
        pathFinder = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        float refreshRate = 0.3f;
        while (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, 0, target.position.z);
            if(!dead)
            {
                pathFinder.SetDestination(targetPosition);
            }
            yield return new WaitForSeconds(refreshRate);
        }
    }
}