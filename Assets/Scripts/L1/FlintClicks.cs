using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlintClicks : MonoBehaviour
{
    public static FlintClicks fclicks;
    private void Awake()
    {
        if (fclicks == null)
            fclicks = this;
    }

    private void Start()
    {
        if (Flint.huolianUsed)
        {
            GameObject.Find("huolian").gameObject.SetActive(false);
        }
        for (int i = 0; i < InventoryManager.invenManager.bag.itemList.Count; i++)
        {
            if (InventoryManager.invenManager.bag.itemList[i].name == "Huolian")
            {
                GameObject.Find("huolian").gameObject.SetActive(false);
            }
        }
    }

}
