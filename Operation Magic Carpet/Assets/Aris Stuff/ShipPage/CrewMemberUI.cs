using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrewMemberUI : MonoBehaviour
{
    public GameObject CrewSlot;
    public Transform CrewSlotUI;
    public Crew c;
    List<GameObject> SlotList = new List<GameObject>();

    Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        CrewSlot = GameObject.Find("Crew Member");
        CrewSlotUI = GameObject.Find("Crew Members bg").GetComponent<Transform>();
        c = GameObject.Find("crew").GetComponent<Crew>();
        for (int i = 0; i < c.members; i++)
        {
            SlotList.Add(Instantiate(CrewSlot, CrewSlotUI));
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdateUI ()
    {
        
    }
}
