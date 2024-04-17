using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TextTitle : MonoBehaviour
{
    public float AppearTime = 4f;
    public float AppearTimeTrigger = 0f;

    Text text;
    Tweener twe;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        twe = text.DOText("卷壹  小壶天", 3f).SetEase(Ease.Linear);
    }

    // Update is called once per frame
    void Update()
    {
        AppearTimeTrigger += Time.deltaTime;
        if (AppearTimeTrigger > AppearTime)
        {
            
            GameObject.Find("Text2").GetComponent<Text>().DOColor(new Color(0, 0, 0, 0), 2f);
        }
    }
}
