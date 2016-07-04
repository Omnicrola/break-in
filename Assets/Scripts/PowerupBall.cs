using UnityEngine;
using System.Collections;

public class PowerupBall : Powerup
{
    protected override void AwardPowerup()
    {
        LevelManager.INSTANCE.AddBall(1);
    }
}
