using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    // reset Spawn Point
    public void ResetSpawnPoint(Vector3 vector)
    {
        gameObject.transform.position = vector;
    }
}
