using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LeaderboardManager : MonoBehaviour
{
    public static LeaderboardManager instance;
    public List<LeaderboardEntry> leaderboardEntries = new List<LeaderboardEntry>();
    private string filePath;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        filePath = Application.persistentDataPath + "/leaderboard.json";
        LoadLeaderboard();
    }

    private void Start(){
        // ResetLeaderboard(); 
    }
    public void AddEntry(string playerName, int score)
    {
        leaderboardEntries.Add(new LeaderboardEntry(playerName, score));
        SortLeaderboard();
        SaveLeaderboard();
    }

    private void SortLeaderboard()
    {
        leaderboardEntries.Sort((x, y) => y.score.CompareTo(x.score));
    }

    private void SaveLeaderboard()
    {
        string json = JsonUtility.ToJson(new LeaderboardData(leaderboardEntries));
        File.WriteAllText(filePath, json);
    }

    private void LoadLeaderboard()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            LeaderboardData data = JsonUtility.FromJson<LeaderboardData>(json);
            leaderboardEntries = data.entries;
        }
    }

    public void ResetLeaderboard()
    {
        leaderboardEntries.Clear();
        SaveLeaderboard();
    }

    [System.Serializable]
    private class LeaderboardData
    {
        public List<LeaderboardEntry> entries;

        public LeaderboardData(List<LeaderboardEntry> entries)
        {
            this.entries = entries;
        }
    }
}
