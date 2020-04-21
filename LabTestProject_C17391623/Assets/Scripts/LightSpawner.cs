using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpawner : MonoBehaviour
{
    private float angle;
    private int lightsCount;
    private float fullCircle = 360f;
    // Start is called before the first frame update
    void Start()
    {
        angle = 360f / lightsCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
