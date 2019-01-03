using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private Vector3 pos;
    public Transform player;
    public Transform gun;
    public int health;
    public float speed;
    private float nextTimeToFire = 0f;
    public float fireRate;
    public Transform firePoint;

    public float lookRadius;
    public GameObject laser;
    public bool isRoamer;
    public bool isShooter;
    private float moveRate = 0.1f;


    void Start()
    {

    }

    void Update()
    {
        if(isRoamer)
        {
            pos = transform.position;
            pos = Vector3.MoveTowards(pos, new Vector3(pos.x - moveRate, pos.y, 0), speed * Time.deltaTime);
            transform.position = pos;
        }
        if(isShooter)
        {
            pos = transform.position;
            pos = Vector3.MoveTowards(pos, new Vector3(pos.x - moveRate, pos.y, 0), speed * Time.deltaTime);
            transform.position = pos;
            if (player != null)
            {
                float distance = Vector3.Distance(player.position, transform.position);
                RotateGun();
                if (distance <= lookRadius)
                {
                    if (Time.time >= nextTimeToFire)
                    {
                        Instantiate(laser, firePoint.transform.position, firePoint.transform.rotation);
                        nextTimeToFire = Time.time + 1f / fireRate;
                    }
                }
            }
        }

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
        
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Thruster")
        {
            health--;
        }
        if (col.tag == "FlipTrigger")
        {
            moveRate *= -1;
        }
    }

    public void RotateGun()
    {
        Vector3 diff = player.position - gun.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        gun.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }
}
