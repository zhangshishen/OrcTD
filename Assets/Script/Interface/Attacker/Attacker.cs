using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class AttackerBase 
{
	MonsterProperties prop;
    public int targetID = -1;
    public float curInterval = 0.0f;

    public int type;         

    public string url = "Canon/CanonShell";  //bullet url

	public AttackerBase(MonsterProperties father)
	{
		prop = father;
	}
    public int getTarget(){
        return targetID;
    }
	public virtual Bullet GetBullet()
	{
		GameObject BulletObj = Resources.Load(url) as GameObject;
		BulletObj = GameObject.Instantiate(BulletObj);
		Vector3 vec = new Vector3(prop.pos.x, prop.pos.y + 3, prop.pos.z);
		BulletObj.GetComponent<Transform>().position = vec;
		return BulletObj.GetComponent<Bullet>();
	}

	public virtual void attack(Attackable trans)
	{
		Bullet bullet = GetBullet();
		bullet.initBullet(trans);
        //return null;
    }
		
	public objectType getType()
	{
        return objectType.TypeMonster;
	}
	public bool isEnemy(objectType obj)
	{
        return obj==objectType.TypeMonster;
	}
	

	public void Update()
	{
        
		curInterval += Time.deltaTime;
        Model model = GlobalRef.getModel();

		if (targetID != -1)     // Dont change target
		{
			Attackable curm = model.getEnemyByID(targetID);

            if ((curm != null)&&(isEnemy(curm.getType())))
			{
                if ((curm.getTransform().position - prop.pos).magnitude <= prop.GetAttackRange())
				{
					//setRotate(curm.transform);
                    if (curInterval < prop.GetFrequency())
					{
						return;
					}
					curInterval = 0;
					attack(curm);

					return;
				}
			}

		}

		//change target
		List<Attackable> l = model.AttackableList;
		foreach (var mons in l)
		{
            
            Vector3 v = mons.getTransform().position - prop.pos;
            if ((isEnemy(mons.getType()))&&v.magnitude <= prop.GetAttackRange())
			{
                targetID = mons.getID();
                if (curInterval < prop.GetFrequency())
				{
					return;
				}

				curInterval = 0;
				attack(mons);

				return;

			}
		}
		targetID = -1;
	}
}