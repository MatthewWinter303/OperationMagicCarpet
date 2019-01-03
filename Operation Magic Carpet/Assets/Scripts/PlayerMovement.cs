using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Crew crewScript;
    public CharacterController2D controller;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    public GameObject thruster;
    Rigidbody2D rb;
    public int health = 3;
    public bool isThrusting = false;
    public List<GameObject> CrewList = new List<GameObject>();
    public Animator DiveAttackBar;
    public SpriteRenderer playerSprite;
    private float nextTimeToDive = 0f;
    public float diveRate;

    public int crewSaved;

    public Text healthText;
    public Text crewText;
    public float blowBackForce;
    public float diveForce;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //crewScript = GameObject.Find("crew").GetComponent<Crew>();
    }

    void Update()
    {
        healthText.text = "HEALTH: " + health + "/3";
        crewText.text = "SURVIVORS: " + crewSaved + "/3";
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Thrust") && controller.m_Grounded)
        {
            jump = true;
        }
        if (Input.GetButtonDown("Thrust") && !isThrusting && Time.time >= nextTimeToDive && !controller.m_Grounded)
        {
            StartCoroutine(ShootThruster());
            isThrusting = true;
            nextTimeToDive = Time.time + 1f / diveRate;      
        }
        if(health <= 0)
        {
            SceneManager.LoadScene("Game");
            //Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    public IEnumerator ShootThruster()
    {
        DiveAttackBar.Play("DiveAttackBarCoolDown");
        thruster.SetActive(true);
        playerSprite.flipY = true;
        //rb.gravityScale = 15f;
        rb.AddForce(new Vector2(horizontalMove * 10, -diveForce));
        yield return new WaitForSeconds(0.4f);
        playerSprite.flipY = false;
        thruster.SetActive(false);
        //rb.gravityScale = 3f;
        jump = false;
        isThrusting = false;
        //yield return new WaitForSeconds(2f);
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            health--;
        }
        if (col.gameObject.tag == "Laser")
        {
            health--;
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "Exit")
        {
            SceneManager.LoadScene("Ship");

        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            rb.velocity = Vector2.zero;
            //thruster.SetActive(false);
            rb.AddForce(new Vector2(0f, blowBackForce));
            print("Bounce");
        }

        if (col.tag == "Crew")
        {
            if(crewScript != null)
            {
                crewScript.members++;
                crewScript.CrewPeeps[col.GetComponent<CrewStats>().crewNum][4]++;
            }
            
            CrewList.Add(col.gameObject);
            crewSaved++;
            col.gameObject.SetActive(false);
        }
    }
}
