using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TeamManager allyTeamManager;
    public TeamManager enemyTeamManager;
    public SceneAsset battleScene;
  
    public void startGame(List<Champion> allyChampions, List<Champion> enemyChampions)
    {
        allyTeamManager = new TeamManager(allyChampions);
        enemyTeamManager = new TeamManager(enemyChampions);
        SceneManager.LoadSceneAsync(battleScene.name, LoadSceneMode.Additive);
    }
    public void endGame()
    {
        SceneManager.UnloadSceneAsync(battleScene.name);
    }
    public TeamManager GetAllyTeam(ChampionStats.Team team)
    {
        return team switch
        {
            ChampionStats.Team.Player => allyTeamManager,
            ChampionStats.Team.Enemy => enemyTeamManager,
            _ => null,
        };
    }
    public TeamManager GetEnemyTeam(ChampionStats.Team team)
    {
        return team switch
        {
            ChampionStats.Team.Player => enemyTeamManager,
            ChampionStats.Team.Enemy => allyTeamManager,
            _ => null,
        };
    }
}
