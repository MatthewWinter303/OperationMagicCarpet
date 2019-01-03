using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //to use ui stuff

public class WriteTimerClass : MonoBehaviour
{
    public Text WriteTimer;
    private Crew c;

    // Start is called before the first frame update
    void Start()
    {
        c = FindObjectOfType<Crew>();
        WriteTimer = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        WriteTimer.text = c.timer.ToString();
    }
}