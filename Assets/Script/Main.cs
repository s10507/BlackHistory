using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

	// Use this for initialization
	void Start () {
        ConfigData conData = new ConfigData();
        LoadMap loadMap = new LoadMap();

        conData.Load();
        loadMap.readMap(conData.allMap[1]);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
