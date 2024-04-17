using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item",menuName ="Inventory/New Item")]

//作用は、Assetsフォルダーの中でメニューバーにmenuNameという選択肢を加えって、そしてfileNameというScriptを生成しつつ実行する。
//ScriptableObjectを通して、Assetsフォルダーにデータをセーブする
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemImg;
}
