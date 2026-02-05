using System.IO;
using UnityEngine;

public static class SaveSystem
{
    private static string SavePath => Application.persistentDataPath + "/save.json";
    
    public static void Save(SaveData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(SavePath, json);
        Debug.Log($"Saved to: {SavePath}");
    }
    
    public static SaveData Load()
    {
        if (File.Exists(SavePath))
        {
            string json = File.ReadAllText(SavePath);
            return JsonUtility.FromJson<SaveData>(json);
        }
        return new SaveData();
    }
    
    public static bool HasSave() => File.Exists(SavePath);
    public static void DeleteSave() { if (HasSave()) File.Delete(SavePath); }
}

[System.Serializable]
public class SaveData
{
    public string currentScene = "Prologoue";
    public int timeShards = 0;
    public int gearPieces = 0;
    public float agingGauge = 0f;
    
    // Stats
    public int playerHP = 100;
    public int playerTP = 100; // Time Points
    
    // Story Flags (Bitwise or Array)
    public bool[] storyFlags = new bool[100];
    
    // Skill Upgrades
    public int shiftLevel = 0;
    public int anchorLevel = 0;
    public int rewindLevel = 0;
    public int echoLevel = 0;
}
