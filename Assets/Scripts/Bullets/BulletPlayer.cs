using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : Bullet
{
    public override void Start()
    {
        goal = GameObject.Find("GoalEnemy");
    }
}
