using System.Collections;
using UnityEngine;

public class FindTargetWithOverlap : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] LayerMask layerMask;
    private int maxColliders = 10;
    Collider[] overlapColliders;
    Collider target;

    private void Start()
    {
        maxColliders = FindObjectOfType<Spawner>().AmountSpawned;
        overlapColliders = new Collider[maxColliders];
    }

    private void Update()
    {
        int collidersFind = Physics.OverlapSphereNonAlloc(transform.position, radius, overlapColliders, layerMask);
        float minDis = Mathf.Infinity;

        for (int i = 0; i < collidersFind; i++)
        {
            Vector3 directionToTarget = overlapColliders[i].gameObject.transform.position - transform.position;
            float disToTarget = directionToTarget.sqrMagnitude;

            if (disToTarget < minDis && overlapColliders[i].gameObject != gameObject)
            {
                minDis = disToTarget;
                target = overlapColliders[i];
            }
        }
    }

    private void OnDrawGizmos()
    {
        Debug.DrawLine(transform.position, target.transform.position);
    }
}
