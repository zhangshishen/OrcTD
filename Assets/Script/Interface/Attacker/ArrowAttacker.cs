using UnityEngine;
using System.Collections;

public class ArrowAttacker : AttackerBase
{

	public ArrowAttacker(MonsterProperties father) : base(father)
	{
		url = "RoundTower/Arrow";
	}

}