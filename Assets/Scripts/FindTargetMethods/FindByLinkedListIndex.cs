using System.Collections.Generic;
using UnityEngine;

public class FindByLinkedListIndex : MonoBehaviour
{
    private GameObject target;
    private LinkedList<GameObject> gameObjectIndex;

    private void Start()
    {
        gameObjectIndex = FindObjectOfType<Spawner>().GameObjectIndex;
    }

    private void Update()
    {
        float minDis = Mathf.Infinity;

        for (var it = gameObjectIndex.First; it != null; )
        {
            Vector3 directionToTarget = it.Value.transform.position - transform.position;
            float disToTarget = directionToTarget.sqrMagnitude;

            if (disToTarget < minDis && it.Value != gameObject)
            {
                minDis = disToTarget;
                target = it.Value;
            }

            it = it.Next;
        }
    }

    private void OnDrawGizmos()
    {
        if (target != null)
        {
            Debug.DrawLine(transform.position, target.transform.position);
        }
    }
}