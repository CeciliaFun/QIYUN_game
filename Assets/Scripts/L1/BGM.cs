using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public static BGM bGM;
    private void Awake()
    {
        if (bGM == null)
            bGM = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //AudioSource sound = gameObject.AddComponent<AudioSource>();
        //sound.playOnAwake = true;
        //sound.loop = true;
        //sound.clip = Resources.Load<AudioClip>("Taiji");        
        

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
