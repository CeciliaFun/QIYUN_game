using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    public static Scene scene;
    private void Update()
    {
        scene = SceneManager.GetActiveScene();
    }
    public void toLevel1()
    {
        //Debug.Log("toL1");
        SceneManager.LoadScene("Level1");
        TestTransition.firstOpen = false;
    }

    public void toLevel3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void toLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
}
