using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] minorSecretsPrefab;
    public GameObject[] majorSecretsPrefab;

    public GameObject SpawnRandomMinorSecret(Vector3 tilePosition)
    {
        int randomSecret = Random.Range(0, minorSecretsPrefab.Length);
        return Instantiate(minorSecretsPrefab[randomSecret], tilePosition, Quaternion.identity);
    }

    public GameObject SpawnRandomMajorSecret(Vector3 tilePosition)
    {
        int randomSecret = Random.Range(0, majorSecretsPrefab.Length);
        return Instantiate(majorSecretsPrefab[randomSecret], tilePosition, Quaternion.identity);
    }
}
