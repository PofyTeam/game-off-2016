using UnityEngine;
using System.Collections;
using UnityEditor;


public class TomHaxEditor {
    [MenuItem ("TomHax/Create Level Config")]
    public static void CreateLevelDatabaseAsset ()
    {
        LevelConfig levelDatabase = ScriptableObject.CreateInstance<LevelConfig> ();

        AssetDatabase.CreateAsset (levelDatabase, "Assets/Game/Resources/ScriptableObjects/LevelConfigs.asset");
        AssetDatabase.SaveAssets ();
    }

    [MenuItem ("TomHax/Delete Saved Data")]
    public static void DeleteSavedData ()
    {
        PlayerPrefs.DeleteAll ();
        PlayerPrefs.Save ();
    }
}
