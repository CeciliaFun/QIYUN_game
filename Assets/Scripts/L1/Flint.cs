using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flint : MonoBehaviour
{
    //private string TAG = "Flint_";
    //Ray ray;
    //RaycastHit hit;
    //GameObject obj;

    public Animator anim;
    public int clicks = 0;

    public static bool huolianUsed = false;

    public static Flint flint;
    private void Awake()
    {
        if (flint == null)
            flint = this;
    }




        void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Debug.Log(TAG + "点击鼠标左键");
        //    ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        Debug.Log(hit.collider.gameObject.name);
        //        obj = hit.collider.gameObject;
        //        Debug.Log(TAG + "点中： name = " + obj.name + "点中： tag = " + obj.tag);
        //        //通过名字
        //        if (obj.name.Equals("suishi"))
        //        {
        //            Debug.Log("点中" + obj.name);
        //        }
        //        //通过标签
        //        if (obj.tag == "Player")
        //        {
        //            Debug.Log("点中" + obj.name);
        //        }
        //    }
        //}
        
        //Scene scene = SceneManager.GetActiveScene();//单独写一个脚本在两个场景都放，单例控制scene变量（可行，已解决）


        if (SceneTrigger.scene.name == "L1_Fire")
        {
            if (Input.GetMouseButtonDown(0) && Slot.huolianIsPicked)
            {
                if (IsClickOnFlint())
                {
                    huolianUsed = true;
                    if (clicks < 3)
                    {
                        clicks++;
                        anim.SetBool("startLight", true);
                    }
                    //else
                    //{
                    //    if (Slot.huolianIsPicked)
                    //    {
                    //        Debug.Log("Light seccessful");                           
                    //    }
                    //    else Debug.Log("Light Failure");

                    //    this.GetComponent<Flint>().enabled = false;
                    //}
                    
                }
            }
          
        }
        else clicks = 0;
       
       

    }

    public bool IsClickOnFlint()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null && hit.collider.name == "suishi")
        {
            Debug.Log("Target" + hit.collider.name);

            return true;
        }
        return false;
    }

    //public static bool PlayWasOver(this Animator animator)
    //{
    //    AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
    //    if (info.normalizedTime >= 1.0f) return true;
    //    else return false;
    //}


}
