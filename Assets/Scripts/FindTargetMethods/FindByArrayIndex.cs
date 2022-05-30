using System.Collections.Generic;
using UnityEngine;

public class FindByArrayIndex : MonoBehaviour
{
    private GameObject target;
    private GameObject[] gameObjectIndex;

    private void Start()
    {
        gameObjectIndex = FindObjectOfType<Spawner>().GameObjectArrayIndex;
    }

    private void Update()
    {
        float minDis = Mathf.Infinity;

        for (int i = 0; i < gameObjectIndex.Length; i++)
        {
            Vector3 directionToTarget = gameObjectIndex[i].transform.position - transform.position;
            float disToTarget = directionToTarget.sqrMagnitude;

            if (disToTarget < minDis && gameObjectIndex[i] != gameObject)
            {
                minDis = disToTarget;
                target = gameObjectIndex[i];
            }
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