using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager
{
    public GameObject spawnPoint;
    public GameObject nexus;
    public GameObject inhibiter;
    int gold;
    public List<Tower> towers;
    public List<Champion> champions;
    public List<Minions> minions;

    public TeamManager(List<Champion> champ)
    {
        champions = champ;
    }
}
//need to be replaced with refrences to the accual classes
public class Tower
{
}

