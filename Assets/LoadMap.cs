using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class LoadMap : MonoBehaviour {
    public TextAsset _layout;
    public GameObject _cube;
    public Texture texture1;
    public Material material1;
    // Use this for initialization
    void Start () {
        
        readMap();
    }

    void readMap()
    {
        char[] kugiri = { '\r', '\n' };
        string[] layoutInfo = _layout.text.Split(kugiri);
        string tipname;
        string[] eachInfo;
        int eventtip;
        for (int i = 0; i < layoutInfo.Length; i++)
        {
            eachInfo = layoutInfo[i].Split(","[0]);
            if (eachInfo[0].Length != 0)
            {
                eventtip = int.Parse(eachInfo[0].Substring(eachInfo[0].Length - 1));
                tipname = eachInfo[0].Substring(0, eachInfo[0].Length - 1);
                Vector2 pos = new Vector2(float.Parse(eachInfo[1]) * 32f,
                                          float.Parse(eachInfo[2]) * 32f);
                this.createObj(_cube, pos, eventtip, tipname);
            }
        }
    }


    void createObj(GameObject obj, Vector2 pos, int eventtip, string name)
    {

        var sr = _cube.GetComponent<SpriteRenderer>();
        sr.sprite = Resources.Load<Sprite>(name);
        //sr.material = material1;
        Debug.Log(sr.sprite.bounds.size.x);
        GameObject go = Instantiate(_cube,
                                    pos,
                                    obj.transform.rotation) as GameObject;
        switch (eventtip)
        {
            //背景用チップ
            case 0:
                go.tag = "background";
                break;
            //ぶつかる壁用チップ
            case 1:
                go.tag = "collider";
                break;
            //ダメージトラップ用チップ
            case 2:
                go.tag = "damage";
                break;
            //ストーリーイベント発生用チップ
            case 3:
                go.tag = "moving";
                break;
            //画面遷移用チップ
            case 4:
                go.tag = "transition";
                break;
            //通路用チップ
            case 5:
                go.tag = "way";
                break;
        }    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}