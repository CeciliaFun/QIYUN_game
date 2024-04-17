using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class EndingText : MonoBehaviour
{
    Text text;
    Tweener twe;
    // Start is called before the first frame update
    void Start()
    {
        string t1 = "小壶天\n\n" +
            "“壶天”一词源自《后汉书·方术传下·费长房》。传说东汉费长房为市掾时，市中有老翁卖药，悬一壶于肆头，市罢，跳入壶中。" +
            "长房于楼上见之，知为非常人。次日复诣翁，翁与俱入壶中，唯见玉堂严丽，旨酒甘肴盈衍其中，共饮毕而出。后即以“壶天”谓仙境。" +
            "                      ";

        string t2 = "齐云山小壶天位于月华街长生楼下，为一明代石坊，上有“小壶天”三字。" +
            "石坊门洞呈葫芦形，进门后，便是一个长20米、宽3.3米，高2.5米的石窟，" +
            "石窟的一侧为万丈深渊，站在窟侧，有“无限风光在险峰”之感。" +
            "崖壁上存有“思退崖”、“石上流泉”、“一线泉”、“飞升所”等石刻，据传这是道士飞升成仙的地方。" +
            "小壶天内为洞穴类丹崖地貌景观，因岩层差异风化作用加之流水作用、风蚀作用而形成。洞穴地层中有众多白垩系恐龙化石，为齐云山重要的地质景观。" ;


        text = GameObject.Find("Text").GetComponent<Text>();
        twe = text.DOText(t1, 28f).SetEase(Ease.Linear);

        twe.OnComplete(() =>
        {
            text.text = "";
            text.DOText(t2, 42f).SetEase(Ease.Linear);
            GameObject root = GameObject.Find("ending");
            GameObject map = root.transform.Find("Audio2").gameObject;
            map.SetActive(true);
        });



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
