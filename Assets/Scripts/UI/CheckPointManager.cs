using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
public class CheckPointManager : MonoBehaviour
{
    public Vector3 currentSpawn;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
           SavePoint();
        }
    }

    private void Start()
    {
        currentSpawn = FindFirstObjectByType<PlayerController>().transform.position;
    }

    public void ResetPlayer(Transform playerPos)
    {
        playerPos.position = currentSpawn;
    }

    public void SavePoint()
    {
        currentSpawn = FindFirstObjectByType<PlayerController>().transform.position;
    }
}

