using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //to use ui stuff

public class WriteNameTop : MonoBehaviour
{
    private Crew c;
    public Text WriteName;
    private string pilotname;

    // Start is called before the first frame update
    void Start()
    {
        pilotname = "nob'deh";
        c = FindObjectOfType<Crew>();
        WriteName = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (c.name1.ToString() == "null" || c.name1.ToString() == "")
        {
            pilotname = "nob'deh";
        }
        else
        {
            pilotname = c.name1.ToString();
        }
        WriteName.text = pilotname + "'s crew";
    }
}