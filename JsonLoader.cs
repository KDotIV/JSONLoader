using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class JsonLoader : MonoBehaviour {
    public AbilityData abilityData = new AbilityData();
    public AbilityList abilityList;
    string fileName = "powerStrike.json";
    string targetPath;
    void Start()
    {
        targetPath = Application.dataPath + "/Resources/Abilities/" + fileName;
        Debug.Log(targetPath);
        // SaveAbility();
        ReadData();
    }

    void SaveAbility()
    {
            JsonWrapper _wrapper = new JsonWrapper();
            _wrapper.abilityData = abilityData;
            string contents = JsonUtility.ToJson(_wrapper, true);
            System.IO.File.WriteAllText(targetPath, contents);
    }

    void ReadData()
    {
        try
        {
            if (System.IO.File.Exists(targetPath))
            {
                string contents = System.IO.File.ReadAllText(targetPath);
                JsonWrapper _wrapper = JsonUtility.FromJson<JsonWrapper>(contents);
                abilityData = _wrapper.abilityData;
                Debug.Log(targetPath + " has been loaded");
            }
            else
            {
                Debug.Log("Unable to load Ability, file does not exist");
            }
        }
        catch (System.Exception ex)
        {

            Debug.Log(ex.Message);
        }
    }
}