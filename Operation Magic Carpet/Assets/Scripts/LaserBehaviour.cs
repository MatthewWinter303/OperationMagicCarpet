using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
    public float speed;

    void Start()
    {
        Destroy(gameObject, 2);
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        //if (col.tag == "Level")
        //{
        //    Destroy(gameObject);
        //}
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Level")
        {
            Destroy(gameObject);
        }
    }
}
