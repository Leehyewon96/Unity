using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using LitJson;

public class PlayerInfo
{
    public int ID;
    public string Name;
    public double Gold;
    public PlayerInfo(int id, string name, double gold)
    {
        ID = id;
        Name = name;
        Gold = gold;
    }
}

public class Json_Test : MonoBehaviour
{
    public List<PlayerInfo> playerInfoList = new List<PlayerInfo>();

    // Start is called before the first frame update
    void Start()
    {
        //SavePlayerInfo();
        LoadPlayerInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SavePlayerInfo()
    {
        Debug.Log("SavePlayerInfo()");

        playerInfoList.Add(new PlayerInfo(1, "이름1", 1001));
        playerInfoList.Add(new PlayerInfo(2, "이름2", 2002));
        playerInfoList.Add(new PlayerInfo(3, "이름3", 3003));
        playerInfoList.Add(new PlayerInfo(4, "이름4", 4004));
        playerInfoList.Add(new PlayerInfo(5, "이름5", 5005));

        JsonData infoJson = JsonMapper.ToJson(playerInfoList);
        File.WriteAllText(Application.dataPath + "/Resources/JsonData/PlayerInfoData.json",
            infoJson.ToString());
    }

    public void LoadPlayerInfo()
    {
        Debug.Log("LoadPlayerInfo()");
        if (File.Exists(Application.dataPath + "/Resources/JsonData/PlayerInfoData.json"))
        {
            string jsonString = File.ReadAllText(Application.dataPath + "/Resources/JsonData/PlayerInfoData.json");

            Debug.Log(jsonString);
            JsonData playerData = JsonMapper.ToObject(jsonString);
            ParsingJsonPlayerInfo(playerData);
        }
    }    

    private void ParsingJsonPlayerInfo(JsonData data)
    {
        Debug.Log("ParsingJsonPlayerInfo()");
        for(int i=0; i < data.Count; i++)
        {
            Debug.Log(data[i]["ID"].ToString());
            Debug.Log(data[i]["Name"].ToString());
            Debug.Log(data[i]["Gold"].ToString());

            int ii = (int)data[i]["ID"];
            Debug.Log(ii.ToString());
        }
    }
}
