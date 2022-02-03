using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject treasurePrefab;
    private int waveCount = 1;
    private float range = 48f;
    private float zBottomRange = -30f;
    
    // Start is called before the first frame update
    void Start()
    {
        CreateWave();
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    private void CreateWave()
    {
        for (int i = 0; i < waveCount; i++)
        {
            Instantiate(enemyPrefab, GenerateRandomPosition(), enemyPrefab.transform.rotation);
        }
        Instantiate(treasurePrefab, GenerateRandomPosition(), treasurePrefab.transform.rotation);
    }

    private Vector3 GenerateRandomPosition()
    {
        Vector3 randomPos = new Vector3(Random.Range(-range, range), 0.5f, Random.Range(zBottomRange, range));
        return randomPos;
    }
}
