using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : Singleto<Gamemanager>
{
    
    public int speedWalk;
    public int speedRun;
    public float jumpforce;
    public float hp;
    public int deHP;
    public int speedAI;
    public int coin;
    public float rollingspeed;
    public int increasecoin, increasecoin50, increasecoin100;
    private void Awake()
    {
        
        hp = 100;
        coin = 0;

    }
}
