using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtn : MonoBehaviour
{
    public void toOne()
    {
        SceneManager.LoadScene("Level1");
        //TestTransition.firstOpen = true;
    }
}
