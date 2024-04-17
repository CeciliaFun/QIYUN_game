using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimChange : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("startLight", false);
        if (Flint.flint.clicks == 3)
        {
            GameObject root = GameObject.Find("MapRoot");
            GameObject map = root.transform.Find("huolian1").gameObject;
            map.SetActive(false);

            GameObject particle = root.transform.Find("SoftFireAdditiveRed").gameObject;
            particle.SetActive(true);

            for (int i = 0; i < InventoryManager.invenManager.bag.itemList.Count; i++)
            {
                if (InventoryManager.invenManager.bag.itemList[i].name=="Huolian")
                {
                    InventoryManager.invenManager.bag.itemList.Remove(InventoryManager.invenManager.bag.itemList[i]);
                }
            }

            InventoryManager.RefreshItem();
        }
    }


    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
