using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //to use ui stuff

public class WriteJumpClass : MonoBehaviour
{
    private Crew c;
    public Text WriteJump;

    // Start is called before the first frame update
    void Start()
    {
        c = FindObjectOfType<Crew>();
        WriteJump = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        WriteJump.text = c.jump.ToString();
    }
}