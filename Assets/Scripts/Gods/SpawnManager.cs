using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] minorSecretsPrefab;
    public GameObject[] majorSecretsPrefab;
    private float offset = 0.5f;

    public GameObject SpawnRandomMinorSecret(Vector3 tilePosition)
    {
        int randomSecret = Random.Range(0, minorSecretsPrefab.Length);
        return Instantiate(minorSecretsPrefab[randomSecret], tilePosition + new Vector3(0, offset,0), Quaternion.identity);
    }

    public GameObject SpawnRandomMajorSecret(Vector3 tilePosition)
    {
        int randomSecret = Random.Range(0, majorSecretsPrefab.Length);
        return Instantiate(majorSecretsPrefab[randomSecret], tilePosition + new Vector3(0, offset, 0), Quaternion.identity);
    }
}
