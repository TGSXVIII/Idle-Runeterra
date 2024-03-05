using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Inhibiter : Structure
{
    public int respawnTime = 60;

    protected override void Die()
    {
        base.Die();
        respawnTimer();
    }

    public void respawnTimer()
    {
            respawnTime = 60;
            //Change sprite back and add collision
    }

}
