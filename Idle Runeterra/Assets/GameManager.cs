using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TeamManager allyTeamManager;
    public TeamManager enemyTeamManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void startGame(List<champion> allyChampions, List<champion> enemyChampions)
    {
        allyTeamManager = new TeamManager();
        enemyTeamManager = new TeamManager();
        allyTeamManager.champions = allyChampions;
        enemyTeamManager.champions = enemyChampions;
    }
    void endGame()
    {

    }
}
