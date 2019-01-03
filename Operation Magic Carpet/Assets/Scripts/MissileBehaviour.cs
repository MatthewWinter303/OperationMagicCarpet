using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBehaviour : MonoBehaviour
{
    public Transform target;
    private Rigidbody2D rb;
    public float speed = 5f;
    public float rotateSpeed = 200f;
    public GameObject blast;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction = (Vector2)target.position - rb.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        rb.angularVelocity = -rotateAmount * rotateSpeed;
        rb.velocity = transform.up * speed;
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Laser" || col.gameObject.tag == "Level")
        {
            Destroy(gameObject);
        }
    }
}
