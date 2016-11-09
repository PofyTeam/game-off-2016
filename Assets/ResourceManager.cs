using UnityEngine;
using System.Collections;

public class ResourceManager : MonoBehaviour {

    public LevelConfig levels;
    public GameData gameData = new GameData ();
        
    public static ResourceManager Resources;
    void Awake ()
    {
        if (Resources == null)
            Resources = this;
        else if (Resources != this)
        {
            Destroy (this.gameObject);
            return;
        }
        DontDestroyOnLoad (this.gameObject);
        LoadLevelConfigs ();
        this.gameData.LoadAll ();
    }
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static string[] GetLevelIds () {
        Resources.LoadLevelConfigs ();
        return Resources.levels.levelIds;

    }

    void LoadLevelConfigs () {
        if (this.levels == null) { }
        this.levels = UnityEngine.Resources.Load<LevelConfig> ("ScriptableObjects/LevelConfigs");
    }

    //void OnDestroy ()
    //{
    //    this.gameData.SaveAll ();
    //}
}
