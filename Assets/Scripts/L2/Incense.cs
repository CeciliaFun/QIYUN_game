using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Incense : MonoBehaviour
{
    public static bool allowLight = false;
    private void OnMouseDown()
    {
        if (allowLight)
        {
            GameObject root = GameObject.Find("MapRoot");
            GameObject map;
            if (this.name == "incense-1")
            {
                IncenseManager.imanager.isOne = true;
                IncenseManager.imanager.sequence.Push(1);
                map = root.transform.Find("CartoonFireRed-1").gameObject;
                map.SetActive(true);

            }
            else if (this.name == "incense-2")
            {
                IncenseManager.imanager.isTwo = true;
                IncenseManager.imanager.sequence.Push(2);
                map = root.transform.Find("CartoonFireRed-2").gameObject;
                map.SetActive(true);
            }
            else if (this.name == "incense-3")
            {
                IncenseManager.imanager.isThree = true;
                IncenseManager.imanager.sequence.Push(3);
                map = root.transform.Find("CartoonFireRed-3").gameObject;
                map.SetActive(true);
            }
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
