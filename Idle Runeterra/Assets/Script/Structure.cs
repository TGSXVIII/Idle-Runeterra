using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{
    public float Health;
    public ChampionStats.Team team;
    
    public void ReciveDamage(float Damage)
    {
        Health -= Damage;
    }
}
