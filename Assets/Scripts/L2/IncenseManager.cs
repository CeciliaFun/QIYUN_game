using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncenseManager : MonoBehaviour
{
    public static IncenseManager imanager;
    private void Awake()
    {
        if (imanager == null)
            imanager = this;
    
    }

    public bool isOne = false;
    public bool isTwo = false;
    public bool isThree = false;

    public bool bcorrect = false;
    // Update is called once per frame

    //単にifを使ったら順番を判断し難い。だからstackを使います
    public Stack<int> sequence = new Stack<int>();

    void Update()
    {
        if (sequence.Count == 3)
        {
            if (sequence.Pop() == 2)
            {
                if (sequence.Pop() == 1)
                {
                    if (sequence.Pop() == 3)
                    {
                        bcorrect = true;
                    }
                }
            }
        }


        if (isThree && isOne && isTwo)
        {
            if (bcorrect)
            {
                Debug.Log("successful√");

                this.GetComponent<IncenseManager>().enabled = false;
                foreach (Transform child in GameObject.Find("incense").transform)
                {
                    child.GetComponent<Incense>().enabled = false;
                    child.GetComponent<PolygonCollider2D>().enabled = false;
                }


                GameObject root = GameObject.Find("MapRoot");
                GameObject map = root.transform.Find("seed").gameObject;
                map.SetActive(true);

                for (int i = 0; i < InventoryManager.invenManager.bag.itemList.Count; i++)
                {
                    if (InventoryManager.invenManager.bag.itemList[i].name == "Fire")
                    {
                        InventoryManager.invenManager.bag.itemList.Remove(InventoryManager.invenManager.bag.itemList[i]);
                    }
                }

                InventoryManager.RefreshItem();

            }
            else
            {
                isOne = isTwo = isThree = false;
                sequence.Clear();
                GameObject.Find("CartoonFireRed-1").SetActive(false);
                GameObject.Find("CartoonFireRed-2").SetActive(false);
                GameObject.Find("CartoonFireRed-3").SetActive(false);
            }   
        }
    }

   
}
