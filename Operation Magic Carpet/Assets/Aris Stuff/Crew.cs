using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Crew : MonoBehaviour
{
    public CrewMemberUI cmui;
    public CrewSlot cs;
    public PilotReader pr;
    public Text jmp; public Text spd; public Text tmr;
    public Text nameone;                                                    //For referencing the pilot's name
    public Text crew1;                                                      //Used to display first crew member's info
    public Text crew2;                                                      //Used to display second crew member's info
    public Button crewbutton;
    public Button crewbutton2;
    public string name1; public int Pt;  public int Ps;  public int Pj;     //references to pilot
    public string name2; public int c1s; public int c1j; public int c1t;    //references to crew 1
    public string name3; public int c2s; public int c2j; public int c2t;    //references to crew 2
    public int jump; public int speed; public int timer;                    //KEY MODFIERS. Added values for all active crew members.
    public int members;                                                     //number that tracks the total collected members.
                                                                            //  Important for all instances of adding/losing crew members!!!
    public int holdjmp; public int holdspd; public int holdtmr;             //temp hold for modifier values - displayed as the "currently selected" crew member
    public int CrewMemberNumber;
    public string holdname;
    public List<int[]> CrewPeeps = new List<int[]>();
    public List<string> CrewNames = new List<string>();

    public bool inGame;

        //Crew Members are stored in ARRAYS.
        //All crew members can be referred to simply by referencing part of their Array. They are also indexed in a list by array (CrewPeeps) and name (CrewNames).
        //Remember to add the Crew Member to the Start function as well to denote them below. Please keep them in sequential order (Bob-END).
    public int[] Bob;
    public int[] Sal;
    public int[] Max;
    public int[] Jil;
    public int[] Teo;
    public int[] Bre;

    void Start() //START!
    {
        
        members = 0;
        jump = Pj + c1j + c2j /*+ c3j*/;
        speed = Ps + c1s + c2s /*+ c3s*/;
        timer = Pt + c1t + c2t /*+ c3t*/;
        Bob = new int[6] { 0, 1, 2, 0, 0, 0 }; CrewPeeps.Add(Bob); CrewNames.Add("Bob");//1
        Sal = new int[6] { 1, 2, 0, 0, 0, 1 }; CrewPeeps.Add(Sal); CrewNames.Add("Sal");
        Max = new int[6] { 2, 0, 1, 0, 0, 2 }; CrewPeeps.Add(Max); CrewNames.Add("Max");
        Jil = new int[6] { 1, 2, 3, 1, 0, 3 }; CrewPeeps.Add(Jil); CrewNames.Add("Jil");
        Teo = new int[6] { 2, 3, 1, 1, 0, 4 }; CrewPeeps.Add(Teo); CrewNames.Add("Teo");//5
        Bre = new int[6] { 3, 1, 2, 1, 0, 5 }; CrewPeeps.Add(Bre); CrewNames.Add("Bre");
        // { SPEED, JUMP, TIMER, TIER, 0 (ACTIVITY), i (INDEX) }
        //add in a 6th variable to the crew members that identifies them base on #. Make those go into a list where you can see the name based on the #.
    }
    private static Crew instance = null;

    private static Crew Instance
    {
        get { return instance; }
    }

    // Update is called once per frame
    void Awake()
    {
        jmp = GameObject.Find("WriteJump").GetComponent<Text>();
        spd = GameObject.Find("WriteSpeed").GetComponent<Text>();
        tmr = GameObject.Find("WriteTimer").GetComponent<Text>();
        nameone = GameObject.Find("SHIPNAME").GetComponent<Text>();
        crew1 = GameObject.Find("Crew2Text").GetComponent<Text>();
        crew2 = GameObject.Find("Crew1Text").GetComponent<Text>();
        cmui = GameObject.Find("Crew Members bg").GetComponent<CrewMemberUI>();
        cs = GameObject.Find("Crew Member").GetComponent<CrewSlot>();
        pr = GameObject.Find("Pilot Reader").GetComponent<PilotReader>();
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    public void ResetHold() //FOR: resetting the holds
    {
        holdname = "null"; holdjmp = 0; holdspd = 0; holdtmr = 0;
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void CrewPaste1() //FOR: pasting hold data to PILOT slot
        //TODO: Figure out how to deactivate the pasted crew slot so you can't just spam it on all three slots.
    {
        if (holdname != "null")
        {
            name1 = holdname;
            pr.pilotname = name1;
            Pj = holdjmp;
            Ps = holdspd;
            Pt = holdtmr;
            ResetHold();
        }
        else if (name1 == "null")
        {
            //nothing get cucked
        }
        else
        {
            name1 = "null";
            pr.pilotname = name1;
            if (pr.pilotname == "null")
            {
                pr.pilotname = "Select Pilot!";
            }
            else
            {
                //nothing
            }
            Ps = 0;
            Pj = 0;
            Pt = 0;
        }
    }

    public void CrewPaste2() //FOR: Pasting holds to CREW 1 slot
    {
        if (holdname != "null")
        {
            name2 = holdname;
            c1j = holdjmp;
            c1s = holdspd;
            c1t = holdtmr;
            ResetHold();
        }
        else if (name1 == "null")
        {
            //nothing get cucked
        }
        else
        {
            name2 = "null";
            c1s = 0;
            c1j = 0;
            c1t = 0;
        }
    }
    public void CrewPaste3() // FOR: pasting second crew member's data. You know the drill by now.
    {
        if (holdname != "null")
        {
            name3 = holdname;
            c2j = holdjmp;
            c2s = holdspd;
            c2t = holdtmr;
            ResetHold();
        }
        else if (name1 == "null")
        {
            //nothing get cucked
        }
        else
        {
            name3 = "null";
            c2s = 0;
            c2j = 0;
            c2t = 0;
        }
    }

    

    void Update() //Every frame... I think we can clear this entirely up if we search enough in the code. TODO: make it empty.
    {
        cmui = GameObject.Find("Crew Members bg").GetComponent<CrewMemberUI>();
        cs = GameObject.Find("Crew Member").GetComponent<CrewSlot>();
        pr = GameObject.Find("Pilot Reader").GetComponent<PilotReader>();
        jmp = GameObject.Find("WriteJump").GetComponent<Text>();
        spd = GameObject.Find("WriteSpeed").GetComponent<Text>();
        tmr = GameObject.Find("WriteTimer").GetComponent<Text>();
        nameone = GameObject.Find("SHIPNAME").GetComponent<Text>();
        crew1 = GameObject.Find("Crew2Text").GetComponent<Text>();
        crew2 = GameObject.Find("Crew1Text").GetComponent<Text>();
        
        if (!inGame)
        {
            jmp.text = jump + "";
            spd.text = speed + "";
            tmr.text = timer + "";
            nameone.text = name1;
        }
        
        // The following text is the add. of crew members stats. The third is available if we want to expand the crew.
        jump = Pj + c1j + c2j /*+ c3j*/;
        speed = Ps + c1s + c2s /*+ c3s*/;
        timer = Pt + c1t + c2t /*+ c3t*/;
    }

    public void OnTriggerEnter2D(Collider2D col) //Idk if this is used? Could probably remove.
    {
        Destroy(this.gameObject);
    }

    public void TestBre() //Instantiates Bre to the menu. For testing purposes.
    {
        if (Bre[4] == 0)
        {
            Instantiate(cmui.CrewSlot, cmui.CrewSlotUI);
            members++;
            Bre[4] = 1;
        }
        else
        {
            //nothing
        }
    }

    public void TestBob() //Instantiates Bob to the menu. For testing purposes.
    {
        if (Bob[4]==0)
        {
            Instantiate(cmui.CrewSlot, cmui.CrewSlotUI);
            members++;
            Bob[4] = 1;
        }
        else
        {
            //nothing
        }
        }
    }