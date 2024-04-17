using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaterTrigger : MonoBehaviour
{
    public static bool waterRunning = false;
    // Update is called once per frame
    void Update()
    {
        if (SquareManager.manager.puzzleCorrect)
        {
            //GameObject root = GameObject.Find("MapRoot");
            //GameObject map = root.transform.Find("WaterDripping2D").gameObject;
            //map.SetActive(true);
            waterRunning = true;
        }
        else return;
    }
}
