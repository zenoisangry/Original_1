using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BodyParts/Legs")]
public class SpeedPowerUp : PowerUpEffect
{
    public float amount;
    public override void Apply(GameObject target)
    {
        target.GetComponent<Player>().moveSpeed += amount;
        //target.GetComponent<Texture>();
    }
}