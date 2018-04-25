using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    float LifeTime = 3;
    float EndTime;

    public float Speed = 25;

    private void Start()
    {
        EndTime = Time.time + LifeTime;
    }

    // Update is called once per frame
    void Update ()
    {
        if (Time.time < EndTime)
        {
            transform.Translate(transform.up * Speed * Time.deltaTime, Space.World);
        }
        else
        {
            DestroyImmediate(gameObject);            
        }
    }
}
