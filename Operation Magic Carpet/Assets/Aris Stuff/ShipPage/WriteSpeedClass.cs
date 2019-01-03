using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //to use ui stuff

public class WriteSpeedClass : MonoBehaviour
{
    public Text WriteSpeed;
    private Crew c;

    // Start is called before the first frame update
    void Start()
    {
        c = FindObjectOfType<Crew>();
        WriteSpeed = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        WriteSpeed.text = c.speed.ToString();
    }
}