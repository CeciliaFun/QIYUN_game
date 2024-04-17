using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Soil : MonoBehaviour
{
    private RaycastHit ObjHit;
    private Ray CustomRay;
    // Update is called once per frame
    void Update()
    {
        if (Slot.seedIsPicked)
        {
            Debug.Log("seedIsPicked");
            //アンドロイドで判断方法
            //if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            //{

            //}

            //PCで判断方法
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            ////Ray ray01 = new Ray(Camera.main.transform.position, Vector3.forward);
            //RaycastHit hit;
            ////ものにぶつかったか
            //bool isCollider = Physics.Raycast(ray, out hit);
            ////bool isCollider01= Physics.Raycast(Camera.main.transform.position, Vector3.forward, 
            ////    10, LayerMask.GetMask("UI", "Enemy", "Player"));
            //if (isCollider)
            //{
            //    //print(hit.collider.gameObject.name);
            //    if (hit.collider.gameObject.name == "soil")
            //    {

            //        GameObject root = GameObject.Find("MapRoot");
            //        GameObject map = root.transform.Find("soil_seed").gameObject;
            //        map.SetActive(true);
            //    }
            //}、


            #region 種子を持ちながら土地をクリックして、ひょうたんが育つ動画を再生します
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject.name == "soil" && Input.GetMouseButtonDown(0))
            {
               //Debug.Log("Target" + hit.collider.name);
                GameObject root = GameObject.Find("MapRoot");
                GameObject map = root.transform.Find("soil_seed").gameObject;
                map.SetActive(true);

                //使った後で消されます
                for (int i = 0; i < InventoryManager.invenManager.bag.itemList.Count; i++)
                {
                    if (InventoryManager.invenManager.bag.itemList[i].name == "Seed")
                    {
                        InventoryManager.invenManager.bag.itemList.Remove(InventoryManager.invenManager.bag.itemList[i]);
                    }
                }

                InventoryManager.RefreshItem();

                gameObject.GetComponent<Soil>().enabled = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            } 
            #endregion

        }
    }
}
