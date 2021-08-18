using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] secretsPrefab;

    public GameObject SpawnRandomMinorSecret(Vector3 tilePosition)
    {
        int randomSecret = Random.Range(0, secretsPrefab.Length);
        return Instantiate(secretsPrefab[randomSecret], tilePosition, Quaternion.identity);
    }

    public GameObject SpawnRandomMajorSecret(Vector3 tilePosition)
    {
        int randomSecret = Random.Range(0, secretsPrefab.Length);
        return Instantiate(secretsPrefab[randomSecret], tilePosition, Quaternion.identity);
    }
}
