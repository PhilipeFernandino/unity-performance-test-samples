using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int AmountSpawned { get => amount; }
    public LinkedList<GameObject> GameObjectIndex => gameObjectLinkedListIndex;
    public GameObject[] GameObjectArrayIndex => gameObjectArrayIndex;

    [Tooltip("Deve ser uma potência de 2")]
    [SerializeField] private int amount;
    [SerializeField] private int distance;
    [SerializeField] private SpawnType spawnType;
    [SerializeField] private GameObject overlapPrefab;
    [SerializeField] private GameObject findWithTagPrefab;
    [SerializeField] private GameObject searchIndexPrefab;
    [SerializeField] private GameObject searchArrayIndexPrefab;

    private int squaredAmount;

    private LinkedList<GameObject> gameObjectLinkedListIndex;
    private GameObject[] gameObjectArrayIndex;



    private void Awake()
    {
        squaredAmount = (int) Mathf.Sqrt(amount);

        switch (spawnType)
        {
            case SpawnType.LinkedListIndex:
                gameObjectLinkedListIndex = new LinkedList<GameObject>();
                break;

            case SpawnType.ArrayIndex:
                gameObjectArrayIndex = new GameObject[squaredAmount * squaredAmount];
                break;
        }
        Spawn();
    }

    private void Spawn()
    {
        for (int i = 0; i < squaredAmount; i++)
        {
            for (int j = 0; j < squaredAmount; j++)
            {
                Vector3 pos = new Vector3(i * distance + Random.Range(-distance / 2, distance/2), 0, j * distance + Random.Range(-distance / 2, distance / 2));

                switch (spawnType)
                {
                    case SpawnType.Overlap:
                        Instantiate(overlapPrefab, pos, Quaternion.identity);
                        break;

                    case SpawnType.Tag:
                        Instantiate(findWithTagPrefab, pos, Quaternion.identity);
                        break;

                    case SpawnType.LinkedListIndex:
                        gameObjectLinkedListIndex.AddLast(Instantiate(searchIndexPrefab, pos, Quaternion.identity));
                        break;

                    case SpawnType.ArrayIndex:
                        gameObjectArrayIndex[i * squaredAmount + j] = Instantiate(searchArrayIndexPrefab, pos, Quaternion.identity);
                        break;
                }
            }
        }
    }

    [System.Serializable]
    private enum SpawnType
    {
        Overlap,
        Tag,
        LinkedListIndex,
        ArrayIndex,
    }
}
