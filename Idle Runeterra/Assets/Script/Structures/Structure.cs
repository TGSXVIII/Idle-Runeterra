using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{
    public int Health;
    public ChampionStats.Team team;
    public Animator animator;
    
    public void ReciveDamage(int Damage)
    {
        Health -= Damage;
        StructureHealth();
    }

    private void StructureHealth()
    {
        if (Health <= 0)
        {
            Die();
        }

    }

    protected virtual void Die()
    {
        //destructionSoundEffect.Play();
        animator.SetTrigger("destroyed");
    }
}
