using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpawner : MonoBehaviour
{
    private float angleGap;
    private float rotAngle;
    private int lightsCount;
    private float fullCircle = 360f;
    private int rad = 10;
    private Quaternion rot;
    private Vector3 pos;
    private Vector3 dir;
    private Transform origin;
    private Vector3 finalDir;
    [SerializeField] private GameObject lightPrefab;
    public GameObject instantiatedPrefab;
    private Boid car;
    private int lightsSpawned;
    // Start is called before the first frame update
    void Start()
    {
        origin = GetComponent<Transform>();
        car = GameObject.Find("Boid").GetComponent<Boid>();
        lightsCount = car.targetTransforms.Length;
        lightsSpawned = 0;
        angleGap = fullCircle / lightsCount; //Calculates the angle between each light
    }

    public GameObject spawnLights()
    {
        if (lightsSpawned < car.targetTransforms.Length)
        {
            for (int i = 0; i < lightsCount; i++)
            {
                rotAngle = i * angleGap;
                rot = Quaternion.AngleAxis(rotAngle, new Vector3(0, 5, 0));
                dir = rot * Vector3.forward;
                finalDir = dir * rad;
                pos = origin.position + finalDir;
                instantiatedPrefab = Instantiate(lightPrefab, pos, rot);
                lightsSpawned++;
            }
        }
        else
        {

        }
        return instantiatedPrefab;
    }
}
