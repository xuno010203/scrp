using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroy : MonoBehaviour
{
    private static bool active = false;
    private void Start()
    {

        if (active)
        {
            Destroy(gameObject);
            return;
        }
        active = true;
        DontDestroyOnLoad(gameObject);
    }
}
