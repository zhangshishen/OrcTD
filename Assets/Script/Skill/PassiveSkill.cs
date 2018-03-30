using UnityEngine;
using System.Collections;

public class PassiveSkill:Skill
{
    // Use this for initialization
    Effect effect;
    public override Effect getEffect()
	{
		return effect;
	}
}
