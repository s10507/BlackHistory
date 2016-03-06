using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class LoadMap : MonoBehaviour {
    public TextAsset _layout;
    public GameObject[] _objs;
    public Texture texture1;
    //public Material material1;
    // Use this for initialization
    void Start () {
        //texture1 = (Texture)Resources.Load("18");
        //readMap();
    }

    void OnRenderObject()
    {
        char[] kugiri = { '\r', '\n' };
        string[] layoutInfo = _layout.text.Split(kugiri);
        string tip_name;
        string[] eachInfo;
        int eventtip;
        for (int i = 0; i < layoutInfo.Length; i++)
        {
            eachInfo = layoutInfo[i].Split(","[0]);
            eventtip = int.Parse(eachInfo[0].Substring(eachInfo[0].Length - 1));
            tip_name = eachInfo[0].Substring(0, eachInfo[0].Length - 1);
            GameObject obj = _objs[0];
            Vector2 pos = new Vector2(int.Parse(eachInfo[1]),
                                      int.Parse(eachInfo[2]));
            //this.createObj(obj, pos, eventtip, tip_name);
            Graphics.DrawTexture(new Rect(10, 10, 100, 100), texture1);
        }
        
    }

    void readMap()
    {
        char[] kugiri = { '\r', '\n' };
        string[] layoutInfo = _layout.text.Split(kugiri);
        string tip_name;
        string[] eachInfo;
        int eventtip;
        for (int i = 0; i < layoutInfo.Length; i++)
        {
            eachInfo = layoutInfo[i].Split(","[0]);
            eventtip = int.Parse(eachInfo[0].Substring(eachInfo[0].Length - 1));
            tip_name = eachInfo[0].Substring(0, eachInfo[0].Length - 1);
            GameObject obj = _objs[0];
            Vector2 pos = new Vector2(int.Parse(eachInfo[1]),
                                      int.Parse(eachInfo[2]));
            this.createObj(obj, pos, eventtip, tip_name);

        }
    }


    void createObj(GameObject obj, Vector2 pos, int eventtip, string name)
    {
        Texture2D texture = Resources.Load(name) as Texture2D;
        Image img = GameObject.Find("Cube").GetComponent<Image>();
        //img.sprite = Sprite.Create(texture, new Rect(pos.x, pos.y, texture.width, texture.height), Vector2.zero);


        GameObject go = Instantiate(obj,
                                    pos,
                                    obj.transform.rotation) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //material1.mainTexture = texture1;
    }

}