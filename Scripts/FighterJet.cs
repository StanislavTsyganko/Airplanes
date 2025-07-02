using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterJet : Aircraft
{
    public override void Move(float speedMult)
    {
        transform.Translate(Direction * Speed * Time.deltaTime*2* speedMult);
    }

}
