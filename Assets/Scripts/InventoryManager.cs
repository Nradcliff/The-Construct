using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<AllItems> inventoryItems = new List<AllItems>(); //Our inventory items

    private void Awake()
    {
        Instance = this;
    }

    public void AddItems(AllItems item) //Add items to inventory
    {
        if (!inventoryItems.Contains(item))
        {
            inventoryItems.Add(item);
        }
    }

    public void RemoveItems(AllItems item) //Remove items from inventory
    {
        if (inventoryItems.Contains(item))
        {
            inventoryItems.Remove(item);
        }
    }

    public enum AllItems //All availible invetory items in game
    {
        KeyRed,
        KeyBlue,
        KeyGreen
    }
}
