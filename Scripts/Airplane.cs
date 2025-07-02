using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : Aircraft
{
    public override void Move(float speedMult)
    {
        transform.Translate(Direction * Speed * Time.deltaTime* speedMult);
    }
}
