using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class MonsterProperties
{
    // Use this for initialization
    public float speed;
    public float turnSpeed;

    public float totalSpeed;
    public float range;

    public float life;

    protected float frequency;
	protected float attackRange;

    public float attack;
    public float armor;

    public List<Effect> effectList;
    public Vector3 pos;

	public virtual void SetFrequency(float f)
	{

        frequency = f;
	}
	public virtual void SetAttackRange(float f)
	{
        attackRange = f;
	}
    public virtual float GetFrequency(){
        
        return frequency;
    }
	public virtual float GetAttackRange()
	{
		return attackRange;
	}
	public virtual ArmorType GetArmortype()
	{
		return ArmorType.LIGHT;
	}
    public virtual float getLife(){
        return life;
    }
	public virtual float getArmorNum()
	{
        float arm = armor;
        if (effectList == null) return armor;
        foreach (Effect eff in effectList){
            arm *= eff.GetArmorInfluence();
        }

		return arm;
	}
    public void setSpeedCoef(float f){
        
    }
}
public class Goblin:MonsterProperties
{
    public Goblin(Vector3 pos){
        speed = 4.5f;
        turnSpeed = 2.0f;
        totalSpeed = speed / 7.0f;
        life = 30;

        armor = 1;
        attack = 5;
        this.pos = pos;
    }
    /*
    public override ArmorType GetArmortype()
	{
		return ArmorType.LIGHT;
	}
    public override float getArmorNum()
	{
		return armor;
	}*/
    
}
public class TowerProperties:MonsterProperties{
    public TowerProperties(Vector3 pos)
    {
        frequency = 1.0f;
        attackRange = 8.0f;
        this.pos = pos;
    }
}