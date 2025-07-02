using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Aircraft : MonoBehaviour
{
    public float Speed { get; set; }
    public Vector3 Position { get; set; }
    public Vector3 Direction { get; set; }
    Explosion expl;


    public abstract void Move(float speedMult);


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Aircraft>() != null)
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            expl = new Explosion();
            expl.Explode(transform.position);
        }
    }
}
