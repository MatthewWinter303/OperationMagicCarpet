﻿using UnityEngine;

/* The base item class. All items should derive from this. */

[CreateAssetMenu(fileName = "New Crew Member", menuName = "Crew")]
public class Item : ScriptableObject
{

    new public string name = "New Crew Member";    // Name of the crew member
    public Sprite icon = null;              // Item icon
    public bool showInInventory = true;

    // Called when the item is pressed in the inventory
    public virtual void Use()
    {
        // Use the item
        // Something may happen
    }

    // Call this method to remove the item from inventory
    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }

}
