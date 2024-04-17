using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
//using UnityEditor.Timeline;

public class SoilSeed : MonoBehaviour
{
    bool waterUsed = false;

    float grownAppearTime = 1.5f;//ディスプレイ時間
    float appearTimeTrigger = 0f;
    float endingAppearTime = 8f;
    float textAppearTime = 13f;
    // Update is called once per frame
    void Update()
    {
        if (Slot.waterIsPicked)
        {
            #region 水滴を持ちながらseed_soilをクリックして
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject.name == "soil_seed" && Input.GetMouseButtonDown(0))
            {
                waterUsed = true;
                //使った後で消されます
                for (int i = 0; i < InventoryManager.invenManager.bag.itemList.Count; i++)
                {
                    if (InventoryManager.invenManager.bag.itemList[i].name == "Water")
                    {
                        InventoryManager.invenManager.bag.itemList.Remove(InventoryManager.invenManager.bag.itemList[i]);
                    }
                }

                InventoryManager.RefreshItem();
            }
            #endregion
        }

        if (waterUsed)
        {              
            appearTimeTrigger += Time.deltaTime;
            
            if (appearTimeTrigger > grownAppearTime)
            {
                Debug.Log(appearTimeTrigger);
                GameObject root = GameObject.Find("MapRoot");
                GameObject map = root.transform.Find("grown").gameObject;
                map.SetActive(true);
               
            }

            if (appearTimeTrigger > endingAppearTime)
            {
                GameObject.Find("ending").gameObject.GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 1), 5f);
            }

            if (appearTimeTrigger > textAppearTime)
            {
                GameObject.Find("ending").gameObject.GetComponent<EndingText>().enabled = true;

                GameObject root = GameObject.Find("ending");
                GameObject map = root.transform.Find("Audio1").gameObject;
                map.SetActive(true);
            }
        }

    }
}
