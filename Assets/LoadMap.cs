using UnityEngine;
using System.Collections;

public class LoadMap : MonoBehaviour {
    public TextAsset _layout;
    public GameObject[] _objs;

    // Use this for initialization
    void Start () {
        this.readMap();
    }

    void readMap()
    {
        char[] kugiri = { '\r', '\n' };
        string[] layoutInfo = _layout.text.Split(kugiri);

        string[] eachInfo;
        for (int i = 0; i < layoutInfo.Length; i++)
        {
            eachInfo = layoutInfo[i].Split(","[0]);

            int objNumber = getObj(eachInfo[0]);
            GameObject obj = _objs[objNumber];
            Vector2 pos = new Vector2(int.Parse(eachInfo[1]),
                                      int.Parse(eachInfo[2]));
            this.createObj(obj, pos);
        }
    }

    int getObj(string objType)
    {
        int resultNum = 0;
        switch (objType)
        {
            case "A":
                resultNum = 0;
                break;
            case "B":
                resultNum = 1;
                break;
            case "C":
                resultNum = 2;
                break;
            case "D":
                resultNum = 3;
                break;
            default:
                resultNum = 0;
                break;
        }
        return resultNum;
    }

    void createObj(GameObject obj, Vector2 pos)
    {
        GameObject go = Instantiate(obj,
                                    new Vector3(pos.x, pos.y, 0),
                                    obj.transform.rotation) as GameObject;
    }

    // Update is called once per frame
    void Update () {
	
	}

}
