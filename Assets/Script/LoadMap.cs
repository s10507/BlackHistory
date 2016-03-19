using UnityEngine;
using System.Collections;

using System.Collections.Generic;
using UnityEngine.UI;

public class LoadMap : MonoBehaviour
{
    public GameObject _maptip = GameObject.Find( "Tile" );
    public Texture texture1;
    public Material material1;

    public void readMap(MapData mapdata)
    {
		int[] max_mapsize = new int[2];
		int rooms_count = mapdata.stages_count;
        List<TextAsset> layouts = new List<TextAsset>();
        char[] kugiri = { '\r', '\n' };
        string[] layoutInfo;
        string tipname;
        string[] eachInfo;
        int eventtip;

        foreach (string stages in mapdata.stages_type)
        {
            layouts.Add(Resources.Load<TextAsset>(stages));
        }

        max_mapsize = get_max_mapsize(layouts);

        foreach(TextAsset csv in layouts)
        { 
            layoutInfo = csv.text.Split(kugiri);
            for (int i = 0; i < layoutInfo.Length; i++)
            {
                eachInfo = layoutInfo[i].Split(","[0]);
                if (eachInfo[0].Length != 0)
                {
                    eventtip = int.Parse(eachInfo[0].Substring(eachInfo[0].Length - 1));
                    tipname = eachInfo[0].Substring(0, eachInfo[0].Length - 1);
                    Vector2 pos = new Vector2(float.Parse(eachInfo[1]) * 32f,
                                              float.Parse(eachInfo[2]) * 32f);
                    this.createObj(_maptip, pos, eventtip, tipname);
                }
            }
        }
    }

    void createObj(GameObject obj, Vector2 pos, int eventtip, string name)
    {

        var sr = obj.GetComponent<SpriteRenderer>();
        sr.sprite = Resources.Load<Sprite>("maptip/" + name);
        //sr.material = material1;
        Debug.Log(sr.sprite.bounds.size.x);
        GameObject go = Instantiate(obj,
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

    int[] get_max_mapsize(List<TextAsset> csv_list)
    {
        int max_x = 0;
        int max_y = 0;
        string[] layoutInfo;
        string[] eachInfo;
        char[] kugiri = { '\r', '\n' };
        foreach (var csv in csv_list)
        {
            layoutInfo = csv.text.Split(kugiri);
            eachInfo = layoutInfo[0].Split(","[0]);
            if (eachInfo[0] == "mapSize")
            {
                max_x = int.Parse(eachInfo[1]);
                max_y = int.Parse(eachInfo[2]);
            }
        }
        return new int[] { max_x, max_y };      
    }

    // Update is called once per frame
    void Update()
    {

    }

}