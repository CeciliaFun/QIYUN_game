using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemPickUp : MonoBehaviour
{
    public Item thisItem;
    public Inventory Bag;
    private void OnMouseDown()
    {
        AddNewItem();

        if (gameObject.transform.parent != null)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }

        else Destroy(gameObject);
    }

    void AddNewItem()
    {
        if (!Bag.itemList.Contains(thisItem))
        {
            Bag.itemList.Add(thisItem);
            InventoryManager.CreatNewItem(thisItem);
            //InventoryManager.RefreshItem();
        }
        else return;
    }
}
