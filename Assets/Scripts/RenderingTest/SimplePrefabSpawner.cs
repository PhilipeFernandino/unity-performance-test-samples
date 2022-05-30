using UnityEngine;
using System.Collections.Generic;

public class SimplePrefabSpawner : MonoBehaviour
{
    [Tooltip("Deve ser uma potência de 2")]
    [SerializeField] private int amount;
    [SerializeField] private float xDistance, yDistance;
    [SerializeField] private List<GameObject> prefabs;
    [SerializeField] private int indexSpawn;

    private int squaredAmount;

    private void Awake()
    {
        squaredAmount = (int)Mathf.Sqrt(amount);
        Spawn();
    }

    private void Spawn()
    {
        for (int i = 0; i < squaredAmount; i++)
        {
            for (int j = 0; j < squaredAmount; j++)
            {
                Vector3 pos = new Vector3(i * xDistance, 0, j * yDistance);
                Instantiate(prefabs[indexSpawn], pos, Quaternion.identity);
            }
        }
    }
}
