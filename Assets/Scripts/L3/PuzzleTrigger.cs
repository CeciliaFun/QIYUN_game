using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PuzzleTrigger : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("L3_Puzzle");
    }

}
