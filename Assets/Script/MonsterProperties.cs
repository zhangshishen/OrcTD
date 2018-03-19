using UnityEngine;
using System.Collections;

public class MonsterProperties
{
    // Use this for initialization
    public float speed;
    public float turnSpeed;

    public float totalSpeed;

    public float life;
	public virtual ArmorType GetArmortype()
	{
		return ArmorType.LIGHT;
	}
	public virtual float getArmorNum()
	{
		return 0;
	}
    public void setSpeedCoef(float f){
        
    }
}
public class Goblin:MonsterProperties
{
    public Goblin(){
        speed = 4.5f;
        turnSpeed = 2.0f;
        totalSpeed = speed / 7.0f;
        life = 30;
    }
    public override ArmorType GetArmortype()
	{
		return ArmorType.LIGHT;
	}
    public override float getArmorNum()
	{
		return 0;
	}
}