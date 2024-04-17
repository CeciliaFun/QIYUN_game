using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlickerContoller : MonoBehaviour
{
    public Animator anim;
    // Update is called once per frame
    public Scene scene;

    private void FixedUpdate()
    {
        scene = SceneManager.GetActiveScene();
        if (scene.name == "L2_Incense")
        {
            if (IncenseManager.imanager.bcorrect)
            {
                anim.SetBool("startFlicker", true);
            }
        }

        if (scene.name == "L3_Puzzle")
        {
            if (SquareManager.manager.isSucceed)
            {
                anim.SetBool("startFlicker", true);
            }
        }
    }

    //update延迟过长，改fixed后稍微好些
    //void Update()
    //{
       
    //    //if (/*(SquareManager.manager.isSucceed == true)||(IncenseManager.imanager.bcorrect==true)*/)
    //    //{
    //    //    anim.SetBool("startFlicker", true);
    //    //    //SquareManager.manager.isSucceed = false;
    //    //}
    //    //else anim.SetBool("startFlicker", false);
    //}
}
