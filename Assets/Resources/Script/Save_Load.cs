using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

[System.Serializable]
public class SaveInformation
{
    public string name;
    public float posX;
    public float posY;
    public float posZ;
}

public class Save_Load : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CSV_Load();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            if(PlayerPrefs.HasKey("ID"))
            {
                string getID = PlayerPrefs.GetString("ID");
                Debug.Log(string.Format("ID:{0}", getID));
                Debug.Log("Load ID : " + getID);
                //Debug.Log("ID:{0}" + getID);
            }
            else
            {
                Debug.Log("저장된 ID 없음");
            }
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            string setID = "PlayerID";
            PlayerPrefs.SetString("ID", setID);
            Debug.Log("Save ID : " + setID);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            /*PlayerPrefs.SetInt("Score", 33);
            PlayerPrefs.SetFloat("Exp", 44.4f);*/

            int getScore = PlayerPrefs.GetInt("Score", 100);
            float getExp = PlayerPrefs.GetFloat("Exp", 100);
            string getName = PlayerPrefs.GetString("Name", "NONE");

            Debug.Log(getScore.ToString());
            Debug.Log(getExp.ToString());
            Debug.Log(getName);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            PlayerPrefs.DeleteKey("ID");
            PlayerPrefs.DeleteKey("Score");
            PlayerPrefs.DeleteKey("Exp");
            PlayerPrefs.DeleteAll();
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            saveBinary();
        }
    }

    void saveBinary()
    {
        // >> : Save data
        SaveInformation setInfo = new SaveInformation();
        setInfo.name = "Inha";
        setInfo.posX = 0.0f;
        setInfo.posY = 4.5f;
        setInfo.posZ = 5.5f;

        Debug.Log(setInfo);

        BinaryFormatter formatter = new BinaryFormatter();
        MemoryStream memStream = new MemoryStream();
        formatter.Serialize(memStream, setInfo);
        byte[] bytes = memStream.GetBuffer();
        string memStr = Convert.ToBase64String(bytes);

        Debug.Log("Save : " + memStr);

        PlayerPrefs.SetString("SaveInformation", memStr);
        // << :Save data

        // >> : Load data
        string getInfos = PlayerPrefs.GetString("SaveInformation", "NONE");
        Debug.Log("Load : " + getInfos);
        byte[] getBytes = Convert.FromBase64String(getInfos);

        MemoryStream getMemStream = new MemoryStream(getBytes);
        BinaryFormatter formatter2 = new BinaryFormatter();
        SaveInformation getInformation = (SaveInformation)formatter2.Deserialize(getMemStream);

        Debug.Log(getInformation.name);
        Debug.Log(getInformation.posX.ToString());
        Debug.Log(getInformation.posY.ToString());
        Debug.Log(getInformation.posZ.ToString());

        // << : Load data


    }

    void CSV_Load()
    {
        List<Dictionary<string, object>> data = CSVReader.Read("ItemInfo");
        for(var i = 0; i < data.Count; i++)
        {
            print("ID : " + data[i]["no"] + " ");
            print("name : " + data[i]["name"] + " ");
            print("Description : " + data[i]["Description"] + " ");
            print("attack power : " + data[i]["attack power"] + " ");
            print("defense power : " + data[i]["difense power"] + " ");
            print("durabillity : " + data[i]["durabillity"] + " ");
        }
    }
}
