using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateLeaderBoardUi : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI[] leaderBoardRankingsText;
    
    void Start()
    {
        UpdateLeaderBoard();
    }

    private void UpdateLeaderBoard(){
        for(int i = 0; i < LeaderboardManager.instance.leaderboardEntries.Count && i < leaderBoardRankingsText.Length; i++){
            leaderBoardRankingsText[i].text = leaderBoardRankingsText[i].text + LeaderboardManager.instance.leaderboardEntries[i].score + "  " + LeaderboardManager.instance.leaderboardEntries[i].playerName;
        }
    }
}
