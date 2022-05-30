using System.Collections;
using UnityEngine;

public class FindTargetWithTag : MonoBehaviour
{
    private GameObject target;
    private GameObject[] gameObjects;

    private void Update()
    {
        float minDis = Mathf.Infinity;

        gameObjects = GameObject.FindGameObjectsWithTag("Find");
        for (int i = 0; i < gameObjects.Length; i++)
        {
            Vector3 directionToTarget = gameObjects[i].transform.position - transform.position;
            float disToTarget = directionToTarget.sqrMagnitude;

            if (disToTarget < minDis && gameObjects[i] != gameObject)
            {
                minDis = disToTarget;
                target = gameObjects[i];
            }
        } 
    }

    private void OnDrawGizmos()
    {
        Debug.DrawLine(transform.position, target.transform.position);
    }
}
