using UnityEngine;
using System.Collections;

public class makeDB : MonoBehaviour {

	// Use this for initialization
    void Start()
    {
        SqliteDatabase sqlDB = new SqliteDatabase("test.db");
        string query = "select * from userinfo";
        DataTable db = sqlDB.ExecuteQuery(query);
        string name = "";
        int userId = 0;
        foreach (DataRow dr in db.Rows)
        {
            name = (string)dr["user_name"];
            userId = (int)dr["user_id"];
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
