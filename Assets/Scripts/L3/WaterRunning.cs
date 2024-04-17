using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRunning : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (WaterTrigger.waterRunning)
        {
            GameObject root = GameObject.Find("MapRoot");
            GameObject map = root.transform.Find("WaterDripping2D").gameObject;
            map.SetActive(true);
            this.gameObject.GetComponent<WaterRunning>().enabled = false;
        }
    }
}
