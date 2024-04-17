using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class test1 : MonoBehaviour
{
    public void OnMouseDown()
    {
        SceneManager.LoadScene("Level1");
       // Debug.Log(Flint.flint.clicks);
    }
}
