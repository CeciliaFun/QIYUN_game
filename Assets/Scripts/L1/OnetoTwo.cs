using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OnetoTwo : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Level2");
    }
}
