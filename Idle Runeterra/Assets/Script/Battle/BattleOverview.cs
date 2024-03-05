using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleOverview : MonoBehaviour
{
    [SerializeField]
    private Canvas battleOverview;
    [SerializeField]
    private GameManager manager;
    [Header("Ally")]
    public List<Image> allyChampionSprite;
    public List<TextMeshProUGUI> allyChampionName;
    public List<Image> allyStructureSprite;
    public List<TextMeshProUGUI> allyStructureName;
    public List<Image> allyMinionSprite;
    public List<TextMeshProUGUI> allyMinionName;
    public TextMeshProUGUI allyStartGoldText;

    [Header("Enemy")]
    public List<Image> enemyChampionSprite;
    public List<TextMeshProUGUI> enemyChampionName;
    public List<Image> enemyStructureSprite;
    public List<TextMeshProUGUI> enemyStructureName;
    public List<Image> enemyMinionSprite;
    public List<TextMeshProUGUI> enemyMinionName;
    public TextMeshProUGUI enemyStartGoldText;

    public void OnOpen()
    {
        CreateBattleOverview(allyChampionSprite, allyChampionName, allyStructureSprite, allyStructureName, allyMinionSprite, allyMinionName, allyStartGoldText, manager.allyTeamManager);
        CreateBattleOverview(enemyChampionSprite, enemyChampionName, enemyStructureSprite, enemyStructureName, enemyMinionSprite, enemyMinionName, enemyStartGoldText, manager.enemyTeamManager);
        battleOverview.enabled = true;
    }
    private void CreateBattleOverview(List<Image> ChampionSprite,
    List<TextMeshProUGUI> ChampionName,
    List<Image> StructureSprite, 
    List<TextMeshProUGUI> StructureName, 
    List<Image> MinionSprite, 
    List<TextMeshProUGUI> MinionName, 
    TextMeshProUGUI StartGoldText,
    TeamManager Team)
    {
        string[] minions = { "Melee - ", "Caster - ", "Cannon - ", "Super - " };
        for (int i = 0; i < Team.champions.Count; i++)
        {
            ChampionSprite[i].sprite = Team.champions[i].GetIcon();
            ChampionName[i].text = Team.champions[i].ChanmpionName + " - " + Team.champions[i].level;
        }

        for (int i = 0; i < Team.towers.Count; i++)
        {
            //StructureSprite[i].sprite = Team.towers[i].GetIcon();
            //StructureName[i].text = "Tower "+ i+1 + " - " + Team.towers[i].level;
        }
        //StructureSprite[3].sprite = Team.nexus.GetIcon();
        //StructureName[3].text = "Nexus - " + Team.nexus.level;
        //StructureSprite[2].sprite = Team.inhibiter.GetIcon();
        //StructureName[2].text = "inhibiter - " + Team.inhibiter.level;

        for (int i = 0; i < Team.minions.Count; i++)
        {
            MinionSprite[i].sprite = Team.minions[i].GetIcon();
            MinionName[i].text = minions[i] + Team.minions[i].level;
        }
        StartGoldText.text = "Starting Gold - " + Team.gold;
    }
    public void Battle()
    {
        battleOverview.enabled = false;
        manager.StartGame();
    }
    public void Cancel()
    {
        //open main manu
        battleOverview.enabled = false;
    }
}
