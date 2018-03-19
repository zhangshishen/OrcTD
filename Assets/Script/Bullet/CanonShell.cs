using UnityEngine;
using System.Collections;

public class CanonShell : Bullet
{
	Vector3[] pos = new Vector3[3];
    ParticleSystem dieParticle;


	public CanonShell()
	{
        speed = 3.0f;

		attack = 13;
        //attackType = (int)AttackType.COMMON;

		ae = null;
	}

    void Awake()
    {
        attackType = (int)AttackType.COMMON;

    }

    public override void initBullet(Attackable attackable)
	{
        base.initBullet(attackable);


        pos[0] = trans.position;

        targetPositionRevise();
	}



    private void targetPositionRevise()
    {
        if (isAlive == false) return;
		pos[2] = targetTransform.position;
		pos[2].y += 2.0f;
		pos[1].x = pos[2].x;
		pos[1].z = pos[2].z;
		pos[1].y = pos[0].y;
    }


    protected override void DiedEffect()
    {
		GameObject go = Resources.Load("Canon/CanonSmoke") as GameObject;
        go = Instantiate(go,trans.position,trans.rotation);
        //print("diedeff");
        //transform.position
	}


	public override bool traceEnemy(Vector3 target)
	{
        curTime += Time.deltaTime;
		float t = curTime * speed;


        targetPositionRevise();

		this.transform.position = routeCalc.bezier(pos, t);

        return t >= 1.0f;
	}


	void Update()
	{
		//if (mons == null) print("mons =="+mons);
		if (bulletUpdate() == false)
		{
            isAlive = false;
		}
		traceEnemy(dest);
        //print("x="+targetTransform.position.x+" y="+targetTransform.position.y+" z="+targetTransform.position.z);
        //print("x=" + transform.position.x + " y=" + transform.position.y + " z=" + transform.position.z);
		if ((pos[2] - transform.position).magnitude < 0.7f)
		{
            if (isAlive != false)
			    mons.beHurt(this);

			DiedEffect();
			Destroy(gameObject);

		}
	}
}
