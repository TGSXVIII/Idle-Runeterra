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
    // Start is called before the first frame update
    void Start()
    {
        startGame(new List<Champion>(), new List<Champion>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void startGame(List<Champion> allyChampions, List<Champion> enemyChampions)
    {
        allyTeamManager = new TeamManager(allyChampions);
        enemyTeamManager = new TeamManager(enemyChampions);
        SceneManager.LoadSceneAsync(battleScene.name, LoadSceneMode.Additive);
    }
    void endGame()
    {
        SceneManager.UnloadSceneAsync(battleScene.name);
    }
}
