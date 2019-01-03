using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //to use ui stuff

public class PilotReader : MonoBehaviour
{
    public Text pilot; //Used to display pilot info
    private Crew c;
    public string pilotname;

    // Start is called before the first frame update
    void Start()
    {
        c = FindObjectOfType<Crew>();
        pilotname = "Select Pilot!";
        pilot = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        pilot.text = pilotname + "\n" + c.Ps + " " + c.Pj + " " + c.Pt;

    }
}
