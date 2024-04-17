using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TestTransition : MonoBehaviour
{
    public float AppearTime = 43f;//ディスプレイ時間
    public float AppearTimeTrigger = 0f;//
    float EnableTime = 45f;
    float DestoryTime = 51f;

    Text text1;
    Tweener twe;

    public static bool firstOpen = true;
    public static TestTransition testTransition;
    private void Awake()
    {
        if (testTransition == null)
            testTransition = this;
    }

    private void Start()
    {
        DOTween.SetTweensCapacity(200,50);
        //Text text = GetComponent<Text>();
        //Tweener twe = text.DOText("下面是有奖竞猜:", 2);
        //twe.OnComplete(() =>
        //{
        //    text.text = "";
        //    text.DOText("富奸老贼是怎么死的?", 2);
        //});

        if (firstOpen)
        {
            string t1 = "《太平寰宇记》卷一百四有载， “白岳山在县西四十里。山峰独耸，有峻崖小道凭梯而上。”\n\n" +
       "唐乾元年间，有道人龚栖霞隐居于天门岩下，始开白岳道教之先河。 \n" +
       "宋宝庆二年，全真派道人余道元云游至白岳，始建佑圣真武祠。 \n" +
       "明嘉靖年间，世宗感白岳祈嗣有验，遂敕修真武祠，“赐神宫名曰玄天太素宫”。\n" +
       "世宗亦见白岳“一石插天，直入云端，与碧云齐”，遂钦赐山额，名曰，\n\n";



            text1 = GameObject.Find("Text1").GetComponent<Text>();
            twe = text1.DOText(t1 + "“齐 云”。", 40f).SetEase(Ease.Linear);
        }

        else
        {
            GameObject.Find("transitionText").SetActive(false);
        }
   
        //twe.OnComplete(() =>
        //{
        //    //text.DOText("“齐 云”。", 2f).SetEase(Ease.Linear);
        //    //float timer = 0;
        //    //Tween t = DOTween.To(() => timer, x => timer = x, 1f, 2f)
        //    //            .OnStepComplete(() =>
        //    //            {
        //    //                text.DOText(t1+"“齐 云”。", 0f).SetEase(Ease.Linear);
        //    //            })
        //    //            .SetLoops(0);
        //});



    }

    void Update()
    {
        AppearTimeTrigger += Time.deltaTime;//ディスプレイ時間が続いて増える
        if (AppearTimeTrigger > AppearTime)
        {
            //this.gameObject.GetComponent<SpriteRenderer>().DOColor(new Color(0, 0, 0, 0), 3f);
            //DOTWEEN使う時、是非実例のcomponentを借りて使います、そうしないとthisを使ったら、errorがないだが、効果もない

            GameObject.Find("Text1").GetComponent<Text>().DOColor(new Color(0, 0, 0, 0), 2f);
            

        }
        if (AppearTimeTrigger > EnableTime)
        {
            GameObject.Find("Text2").GetComponent<TextTitle>().enabled = true;
        }
        if (AppearTimeTrigger > DestoryTime)
        {
            GameObject.Find("transitionText").GetComponent<SpriteRenderer>().DOColor(new Color(0, 0, 0, 0), 3f);
            firstOpen = false;
            //SceneManager.LoadScene("Level1");
            // DestroyImmediate(GameObject.Find("transitionText"));
        }
    }

    //问题：返回此level时计时器重新开始计时，画面会再次出现，so记得销毁
}
