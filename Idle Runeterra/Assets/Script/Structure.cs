using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{
    public int Health;
    public ChampionStats.Team team;
    
    public void ReciveDamage(int Damage)
    {
        Health -= Damage;
    }
}
