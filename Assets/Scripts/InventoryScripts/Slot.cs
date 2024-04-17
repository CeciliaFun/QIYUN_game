using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    public Item slotItem;
    public Image slotImg;

    public static bool huolianIsPicked = false;
    public static bool seedIsPicked = false;
    public static bool waterIsPicked = false;


    

    Color c = new Color(200f / 255f, 200f / 255f, 200f / 255f);
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            useItem();
            chooseItem();
            //else if(InventoryManager.invenManager.bag.itemList.Count == 1)
            //{
            //    InventoryManager.invenManager.slotGrid.transform.GetChild(0).gameObject.GetComponent<Image>().color = c;
            //}
            
        }

    }
   
     //ある道具を選択する効果
    public void chooseItem()
    {
        Debug.Log("choose");
        if (InventoryManager.invenManager.bag.itemList.Count > 0)
        {
            //for (int i = 0; i < InventoryManager.invenManager.slotGrid.transform.childCount; i++)
            //{
            //    InventoryManager.invenManager.slotGrid.transform.GetChild(i).gameObject.GetComponent<Image>().color = Color.white;
            //}

            for (int i = 0; i < InventoryManager.invenManager.slotGrid.transform.childCount; i++)
            {
                Debug.Log(InventoryManager.invenManager.slotGrid.transform.GetChild(i).GetComponent<Slot>().slotItem.name);
                if (InventoryManager.invenManager.slotGrid.transform.GetChild(i).GetComponent<Slot>().slotItem.name == slotItem.name)
                {
                    InventoryManager.invenManager.slotGrid.transform.GetChild(i).gameObject.GetComponent<Image>().color = c;
                }
                else InventoryManager.invenManager.slotGrid.transform.GetChild(i).gameObject.GetComponent<Image>().color = Color.white;
            }
        }
    }

    //道具の使い
    public void useItem()
    {
        //isPicked = true;
        
        //this.GetComponent<Image>().color = c;

        if(SceneTrigger.scene.name == "L1_Fire")
        {
            if(slotItem.name == "Huolian")
            {
                //Debug.Log("huolianIsPicked = true");
                huolianIsPicked = true;
                //GameObject.Find("huolian1").SetActive(true);//注意点：Gameobject方法と見えるものを検索するだけ
                //this.transform.Find("suishi/huolian1").gameObject.SetActive(true);
                //注意点：見えないものを検索ことができるですが、root node必ず見えることを前提にする。

                GameObject root = GameObject.Find("MapRoot");
                GameObject map = root.transform.Find("huolian1").gameObject;
                map.SetActive(true);
            }
            else
            {
                huolianIsPicked = false;
                if (GameObject.Find("MapRoot"))
                {
                    GameObject root = GameObject.Find("MapRoot");
                    GameObject map = root.transform.Find("huolian1").gameObject;
                    map.SetActive(false);
                }             
            }
        }
       


        if (SceneTrigger.scene.name == "L2_Incense")
        {
            if(slotItem.name == "Fire")
                Incense.allowLight = true;
            else
            {
                Incense.allowLight = false;
            }
        }

        //bug：seed使った後、list先頭のslotがクリックできない　
        //原因：soilのcollider範囲広すぎて、
        if (SceneTrigger.scene.name == "L1_Soil")
        {
            if (slotItem.name == "Seed")
            {
                Debug.Log("seedIsPicked = true");
                seedIsPicked = true;
            }
            else seedIsPicked = false;

            if (slotItem.name == "Water")
            {
                Debug.Log("waterIsPicked = true");
                waterIsPicked = true;
            }
            else waterIsPicked = false;

        }

    }

}
