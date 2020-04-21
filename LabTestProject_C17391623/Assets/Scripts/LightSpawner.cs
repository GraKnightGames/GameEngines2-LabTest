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
    public Transform instantiatedPrefab;
    private Boid car;
    private int lightsSpawned;
    public Transform[] lights = new Transform[10];
    // Start is called before the first frame update
    void Start()
    {
        origin = GetComponent<Transform>();
        car = GameObject.Find("Boid").GetComponent<Boid>();
        lightsCount = car.targetTransforms.Length;
        lightsSpawned = 0;
        angleGap = fullCircle / lightsCount; //Calculates the angle between each light
    }

    public Transform[] spawnLights()
    {
        if (lightsSpawned < car.targetTransforms.Length)
        {
            for (int i = 0; i < lightsCount; i++)
            {
                rotAngle = i * angleGap;
                rot = Quaternion.AngleAxis(rotAngle, Vector3.up);
                dir = rot * Vector3.forward;
                finalDir = dir * rad;
                pos = origin.position + finalDir;
                instantiatedPrefab = Instantiate(lightPrefab, pos, rot).GetComponent<Transform>();
                instantiatedPrefab.GetComponent<LightController>().myRend = instantiatedPrefab.GetComponent<Renderer>();
                lights[i] = instantiatedPrefab;
                lightsSpawned++;
            }
        }
        else
        {

        }
        return lights;
    }
}
