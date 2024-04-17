using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager invenManager;

    public Inventory bag;
    public GameObject slotGrid;
    public Slot slotPrefab;
    
    private void Awake()
    {
        if (invenManager == null)
            invenManager = this;
    }

    private void OnEnable()
    {
        RefreshItem();
    }

    bool gotSeed = false;
    bool gotWater = false;
    public Scene scene;
    private void Update()
    {
        for (int i = 0; i < invenManager.bag.itemList.Count; i++)
        {
            if (bag.itemList[i].itemName == "Seed")
            {
                //Debug.Log("gotSeed");
                gotSeed = true;
            }
            if (bag.itemList[i].itemName == "Water")
            {
                //Debug.Log("gotWater");
                gotWater = true;
            }
        }
        
        scene = SceneManager.GetActiveScene();
        if (scene.name == "Level1" && gotSeed && gotWater)
        {
            GameObject root = GameObject.Find("MapRoot");
            GameObject map = root.transform.Find("TreasureChestGlowRays").gameObject;
            map.SetActive(true);

            //GameObject.Find("arch").GetComponent<OnetoTwo>().enabled = false;
            //GameObject.Find("arch").SetActive(false);
            Destroy(GameObject.Find("arch"));
        }
    }
    
   

    public static void CreatNewItem(Item item)
    {
        Slot newItem = Instantiate(invenManager.slotPrefab, invenManager.slotGrid.transform.position, Quaternion.identity);//或者直接使用父节点的transform
        //Slot newItem = Instantiate(invenManager.slotPrefab,invenManager.slotGrid.gameObject.transform.parent.gameObject.transform);
        newItem.gameObject.transform.SetParent(invenManager.slotGrid.transform);
        newItem.slotItem = item;
        newItem.slotImg.sprite = item.itemImg;
    }
    public static void RefreshItem()
    {
        for (int i = 0; i < invenManager.slotGrid.transform.childCount; i++)
        {
            if (invenManager.slotGrid.transform.childCount == 0)
            {
                break;
            }
            Destroy(invenManager.slotGrid.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < invenManager.bag.itemList.Count;i++)
        {
            CreatNewItem(invenManager.bag.itemList[i]);
        }
    }

    
    //public static void DeleteItem(Item item)
    //{
    //    invenManager.bag.itemList.Remove(item);
    //}
}
