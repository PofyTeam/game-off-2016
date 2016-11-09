using UnityEngine;
using System.Collections.Generic;

public class GameData {
    public const string TAG = "<color=green><b>GameData:</b></color> ";

    #region Level Data
    public Dictionary<string, LevelData> levelData = new Dictionary<string, LevelData> ();
    protected bool _dirty;

    /// <summary>
    /// Load data from [PlayerPrefs] and deserialize data objects from JSON
    /// </summary>
    public void LoadLevelData ()
    {
        this.levelData.Clear ();

        string[] ids = ResourceManager.GetLevelIds ();
        foreach (var id in ids)
        {
            LevelData newData = new LevelData (id);
            string levelJson = PlayerPrefs.GetString (id, "");
            if (!string.IsNullOrEmpty (levelJson))
                JsonUtility.FromJsonOverwrite (levelJson, newData);

            if (!this.levelData.ContainsKey (id))
            {
                this.levelData[id] = newData;
                Debug.Log(TAG+ "level " + id + " data loaded.");
            }
            else
                Debug.LogWarning (TAG + "Level Data already contains " + id);
        }
        Debug.Log (TAG + "Loading Level Data completed.");
    }

    /// <summary>
    /// Serialize Level Data objects to JSON and write it as a string to [PlayerPrefs]
    /// </summary>
    public void SaveLevelData ()
    {
        foreach (var level in this.levelData.Values)
        {
            string levelJson = JsonUtility.ToJson (level);
            PlayerPrefs.SetString (level.id, levelJson);
        }
        this._dirty = true;
        Debug.Log (TAG + "Saving Level Data completed.");
    }
    #endregion

    #region SettingsData
    public SettingsData settingsData = new SettingsData ();

    void LoadSettingsData ()
    {
        string settingsJson = PlayerPrefs.GetString ("settings", "");
        if (!string.IsNullOrEmpty (settingsJson))
            JsonUtility.FromJsonOverwrite (settingsJson, this.settingsData);
        else
            Debug.LogWarning (TAG + "No Settings Data. Using default values.");
        Debug.Log (TAG + "Loading Settings Data completed.");
    }

    public void SaveSettingsData ()
    {
        string settingsJson = JsonUtility.ToJson (this.settingsData);
        PlayerPrefs.SetString ("settings", settingsJson);
        this._dirty = true;
        Debug.Log (TAG + "Saving Settings Data completed.");
    }

    #endregion

    #region Progress Data
    public ProgressData progressData = new ProgressData ();
    void LoadProgressData ()
    {
        string progressJson = PlayerPrefs.GetString ("progress", "");
        if (!string.IsNullOrEmpty (progressJson))
            JsonUtility.FromJsonOverwrite (progressJson, this.progressData);
        else
            Debug.LogWarning (TAG + "No Progress Data. Using default values.");
        Debug.Log (TAG + "Loading Progress Data completed.");
    }

    public void SaveProgressData ()
    {
        string progressJson = JsonUtility.ToJson (this.progressData);
        PlayerPrefs.SetString ("progress", progressJson);
        this._dirty = true;
        Debug.Log (TAG + "Saving Progress Data completed.");
    }

    #endregion

    #region Inventory Data

    public InventoryData inventoryData = new InventoryData ();

    void LoadInventoryData ()
    {
        string inventoryJson = PlayerPrefs.GetString ("inventory", "");
        if (!string.IsNullOrEmpty (inventoryJson))
            JsonUtility.FromJsonOverwrite (inventoryJson, this.inventoryData);
        else
            Debug.LogWarning (TAG + "No Inventory Data. Using default values.");
        Debug.Log (TAG + "Loading Inventory Data completed.");
    }

    public void SaveInventoryData ()
    {
        string inventoryJson = JsonUtility.ToJson (this.inventoryData);
        PlayerPrefs.SetString ("inventory", inventoryJson);
        this._dirty = true;
        Debug.Log (TAG + "Saving Inventory Data completed.");
    }

    public void AddItem (InventoryItem item)
    {
        InventoryItem itemInInventory = this.inventoryData.items.Find (i => i.id == item.id);
        if (itemInInventory != null)
        {
            itemInInventory.quantity += item.quantity;
        }
    }


    #endregion

    /// <summary>
    /// Loads all data objects from PlayerPrefs and deserializes it.
    /// </summary>
    public void LoadAll ()
    {
        Debug.Log (TAG + "Loading all data objects...");
        LoadLevelData ();
        LoadSettingsData ();
        LoadProgressData ();
        LoadInventoryData ();
    }

    /// <summary>
    /// Saves all data objects to PlayerPrefs and then flushes it.
    /// </summary>
    public void SaveAll ()
    {
        Debug.Log (TAG + "Saving all data objects...");
        SaveLevelData ();
        SaveSettingsData ();
        SaveProgressData ();
        SaveInventoryData ();

        Flush ();
    }

    /// <summary>
    /// Flushes [PlayerPrefs] to disk
    /// </summary>
    public void Flush ()
    {
        if (this._dirty)
        {
            PlayerPrefs.Save ();
            Debug.Log (TAG + "Data Flushed!");
        }
        else
        {
            Debug.LogWarning (TAG + "No Chnages to flush!");
        }
    }
}

[System.Serializable]
public class LevelData
{
    public string id;
    public int days = 0;
    public bool completed = true;

    public LevelData () : this("")
    {

    }

    public LevelData (string id)
    {
        this.id = id;
    }
}

[System.Serializable]
public class SettingsData
{
    public bool sound;
    public bool music;

    public SettingsData():this(true,true)
    {
    }

    public SettingsData(bool sound, bool music)
    {
        this.sound = sound;
        this.music = music;
    }

}

[System.Serializable]
public class ProgressData
{
    public bool hasProgress = false;
    public string currentLevel;
}

[System.Serializable]
public class InventoryData
{
    public int gold = 0;
    public List<InventoryItem> items;

    public InventoryData() : this(0) { }
    public InventoryData(int gold)
    {
        this.gold = 0;
        this.items = new List<InventoryItem>();
    }
}

[System.Serializable]
public class InventoryItem
{
    public string id;
    public int quantity;
}

[System.Serializable]
public class LevelConfig : ScriptableObject
{
    public string[] levelIds;
}