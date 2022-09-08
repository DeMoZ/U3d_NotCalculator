using UnityEngine;

public class SaveLoad
{
    private string key = "CalcSave";

    public void Save(string value)
    {
        PlayerPrefs.SetString(key, value);
        Debug.Log($"saved {value}");
    }

    public string Load()
    {
        var loaded = PlayerPrefs.GetString(key, null);
        Debug.Log($"loaded {loaded}");
        return loaded;
    }
}