using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nexus : Structure
{
    public GameObject victoryMenu;
    public GameObject gameOverMenu;

    public AudioSource victorySoundEffect;
    public AudioSource defeatSoundEffect;

    protected override void Die()
    {
        base.Die();
        GameOver();
    }

    private void GameOver()
    {

        if (team == ChampionStats.Team.Player)
            victorySoundEffect.Play();
            animator.SetTrigger("victory");
            victoryMenu.SetActive(!victoryMenu.activeSelf);

        if (team == ChampionStats.Team.Enemy)
            defeatSoundEffect.Play();
            animator.SetTrigger("defeat");
            gameOverMenu.SetActive(!gameOverMenu.activeSelf);
    }
}
