using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrewSlot : MonoBehaviour
{
    public Image avatar;
    Item item;
    public Crew c;
    //private Text CrewMemberName;
    public GameObject CrewSelectBackground;
    CrewMemberUI cmui;

    private string crewmembername;
    private int crewmemberspeed;
    private int crewmemberjump;
    private int crewmembertimer;
    public Text namedude;
    private string crewdesc;
    public GameObject Slot;

    public void AddItem(Item newItem)
    {
        item = newItem;
        avatar.sprite = item.icon;
        avatar.enabled = true;
    }

    public void holdvars()
    {
        c.holdjmp = crewmemberjump;
        c.holdname = crewmembername;
        c.holdspd = crewmemberspeed;
        c.holdtmr = crewmembertimer;
        Debug.Log("HOLDVAR"+ c.holdname + c.holdspd + c.holdjmp + c.holdtmr);
    }

    public void ClearSlot()
    {
        item = null;
        avatar.sprite = null;
        avatar.enabled = false;

    }
    public void CrewManager()
    {
        int a = -1;
            //the a int can be used in case some fuckery causes the code to be offset by 1 by setting a=0;
        if (a < 1)
        {
            crewdesc = "nubll";
            //Destroy(this.gameObject);
            a++;
        }
        else
        {
            for (int i = 0; i < c.CrewPeeps.Count; i++)
            {
                int check = (c.CrewPeeps[i])[4];
                {
                    if ((check > 0) && (check <2))
                    {
                        c.CrewPeeps[i][4]++; // ONDESTROY: need to have a if > 1 reset to 1 so that next time the menu loads it doesn't glitch out
                        crewmembername  = c.CrewNames[i];
                        crewmemberspeed = c.CrewPeeps[i][0];
                        crewmemberjump  = c.CrewPeeps[i][1];
                        crewmembertimer = c.CrewPeeps[i][2];
                        crewdesc = crewmembername + "\n" + crewmemberspeed + " " + crewmemberjump + " " + crewmembertimer;
                    }
                    else
                    {
                        //nothing!
                    }
                }
            } 
        }
        /*else if (c.Bob[4] > 0) && (c.Bob[4] < 2))
        {
            c.Bob[4]++;
            crewmembername = c.CrewNames[0];
            crewmemberspeed = c.Bob[0];
            crewmemberjump = c.Bob[1];
            crewmembertimer = c.Bob[2];
            crewdesc = crewmembername + "\n" + crewmemberspeed + " " + crewmemberjump + " " + crewmembertimer;
        }
        else if ((c.Sal[4] > 0) && (c.Sal[4] < 2))
        {
            c.Sal[4]++;
            crewmembername = c.CrewNames[1];
            crewmemberspeed = c.Sal[0];
            crewmemberjump = c.Sal[1];
            crewmembertimer = c.Sal[2];
            crewdesc = crewmembername + "\n" + crewmemberspeed + " " + crewmemberjump + " " + crewmembertimer;
        }
        else if ((c.Max[4] > 0) && (c.Max[4] < 2))
        {
            c.Max[4]++;
            crewmembername = c.CrewNames[2];
            crewmemberspeed = c.Max[0];
            crewmemberjump = c.Max[1];
            crewmembertimer = c.Max[2];
            crewdesc = crewmembername + "\n" + crewmemberspeed + " " + crewmemberjump + " " + crewmembertimer;
        }
        else if ((c.Jil[4] > 0) && (c.Jil[4] < 2))
        {
            c.Jil[4]++;
            crewmembername = c.CrewNames[3];
            crewmemberspeed = c.Jil[0];
            crewmemberjump = c.Jil[1];
            crewmembertimer = c.Jil[2];
            crewdesc = crewmembername + "\n" + crewmemberspeed + " " + crewmemberjump + " " + crewmembertimer;
        }
        else if ((c.Teo[4] > 0) && (c.Teo[4] < 2))
        {
            c.Teo[4]++;
            crewmembername = c.CrewNames[4];
            crewmemberspeed = c.Teo[0];
            crewmemberjump = c.Teo[1];
            crewmembertimer = c.Teo[2];
            crewdesc = crewmembername + "\n" + crewmemberspeed + " " + crewmemberjump + " " + crewmembertimer;
        }
        else if ((c.Bre[4] > 0) && (c.Bre[4] < 2))
        {
            c.Bre[4]++;
            crewmembername = c.CrewNames[5];
            crewmemberspeed = c.Bre[0];
            crewmemberjump = c.Bre[1];
            crewmembertimer = c.Bre[2];
            crewdesc = crewmembername + "\n" + crewmemberspeed + " " + crewmemberjump + " " + crewmembertimer;
        };*/
    }


    // Start is called before the first frame update
    void Start()
    {
        cmui = GameObject.Find("Crew Members bg").GetComponent<CrewMemberUI>();
        c = GameObject.Find("crew").GetComponent<Crew>();
        Slot = this.gameObject;
        CrewManager();
        namedude.text = crewdesc;// GetComponent<Text>();
        Debug.Log(crewdesc);
       // namedude.text = crewdesc;
    }
    // Update is called once per frame
    void Update()
    {
        //      if (Input.GetMouseButtonDown(0))
        {

            //          c.holdname = crewmembername;
            //          c.holdjmp = crewmemberjump;
            //          c.holdspd = crewmemberspeed;
            //            c.holdtmr = crewmembertimer;
        }
    }
}
