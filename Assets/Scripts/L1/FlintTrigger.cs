using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlintTrigger : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("L1_Fire");
    }
}
