using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //to use ui stuff

public class CurrentWriter : MonoBehaviour
{
    private Crew c;
    public Text CurrentDude;
    private string crewname;


    // Start is called before the first frame update
    void Start()
    {
        c = GameObject.Find("crew").GetComponent<Crew>();
        CurrentDude = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        c = GameObject.Find("crew").GetComponent<Crew>();
        if (c.holdname.ToString() == "null" || c.holdname.ToString() == "")
        {
            crewname = "None Selected!";
        }
        else
        {
            crewname = c.holdname.ToString();
        }
        CurrentDude.text = "Current Crew Member: " + crewname + "\nSPD: " + c.holdspd.ToString() + " JMP: " + c.holdjmp.ToString() + " TIM: " + c.holdtmr.ToString();
    }
}