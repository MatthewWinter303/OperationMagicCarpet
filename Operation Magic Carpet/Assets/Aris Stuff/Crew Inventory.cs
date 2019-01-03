using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Crew c;
    #region Singleton

    public static Inventory instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public void Update()
    {
        //This code is for displaying the crew member
        for (int i = 0; i < c.members+1; i++)
        {
            //member = i
            //if (bool of member == true)
            //   instantiate block
            //   write stats
            //   ascribe number to block
            //else
            //   nothing
        }
    }

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 18;  // Amount of item spaces

    // Our current list of items in the inventory
    public List<Item> items = new List<Item>();

    // Add a new item if enough room
    public void Add(Item item)
    {
        if (item.showInInventory)
        {
            if (items.Count >= space)
            {
                Debug.Log("Not enough room.");
                return;
            }

            items.Add(item);

            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }
    }

    // Remove an item
    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

}
