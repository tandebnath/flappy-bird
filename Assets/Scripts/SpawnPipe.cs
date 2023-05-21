using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPipe : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;
    public float minVariance = 0.5f;
    private Vector3 previousPosition;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);

        if (previousPosition.y > 0f)
        {
            pipes.transform.position += Vector3.up * Random.Range(minHeight, -minVariance);
        }
        else
        {
            pipes.transform.position += Vector3.up * Random.Range(minVariance, maxHeight);
        }

        previousPosition = pipes.transform.position;
    }
}
