using UnityEngine;
using System.Collections.Generic;

public class GameData : MonoBehaviour {

    public Dictionary<string, LevelData> levelData;

    public SettingsData settingsData = new SettingsData();
    public ProgressData progressData = new ProgressData();
    public InventoryData inventoryData = new InventoryData();
    void Awake()
    {
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

[System.Serializable]
public class LevelData
{
    public int days = 0;
    public bool completed = true;
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
    public string itemId;
    public int quantity;
}