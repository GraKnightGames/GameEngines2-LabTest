using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    public Vector3 vel;
    public Vector3 accel;
    public Vector3 force;
    public Vector3 worldPos;
    public float mass = 1.0f;
    public float maxSpeed = 5;
    public float maxForce = 10;
    public float speed = 0;
    public Vector3 target;
    public Transform[] targetTransforms;
    public Renderer targetRend;
    //public float slowingDistance = 10;
    public float bankForce = 0.1f;
    public float damping = 0.1f;
    public LightSpawner ls;
    private void Start()
    {
        ls = GameObject.Find("Origin").GetComponent<LightSpawner>();
    }

    public void OnDrawGizmos()
    {
    }

    Vector3 Seek(Vector3 targ)
    {
        Vector3 toTarget = targ - transform.position;
        Vector3 des = toTarget.normalized * maxSpeed;

        return des - vel;
    }

    public Vector3 CalculateForce()
    {
        Vector3 force = Vector3.zero;
        force += Seek(target);
        return force;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < targetTransforms.Length; i++)
        {
            targetTransforms[i] = ls.spawnLights()[i];
        }
        for (int i = 0; i < targetTransforms.Length; i++)
        {
            targetRend = targetTransforms[i].gameObject.GetComponent<Renderer>();
            if (targetTransforms[i].GetComponent<Renderer>().material.color == Color.green)
            {
                target = targetTransforms[i].position;
            }
            else
            {

            }
        }
        speed = vel.magnitude;
        force = CalculateForce();
        accel = force / mass;
        vel += accel * Time.deltaTime;

        transform.position += vel * Time.deltaTime;
        transform.LookAt(target, Vector3.up);
        vel -= (damping * vel * Time.deltaTime);


    }
}