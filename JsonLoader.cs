public class JsonLoader {
    public Data newData = new Data();
    public DataList newDataList;
    string fileName = "newFileName.json";
    string targetPath;
    
    void Start()
    {
        targetPath = Application.dataPath + "/nameOfPath/ToDirectory/" + fileName;
        print(targetPath);
        SaveData(); //when called allows you to save to your JSON schema
        ReadData();
    }

    void SaveAbility()
    {
            JsonWrapper _wrapper = new JsonWrapper(); //connects to a JSON wrapper class to keep things pretty
            _wrapper.newData = newData;
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
                newData = _wrapper.newData;
                print(targetPath + " has been loaded");
            }
            else
            {
                print("Unable to load Ability, file does not exist");
            }
        }
        catch (System.Exception ex)
        {

            print(ex.Message);
        }
    }
}
