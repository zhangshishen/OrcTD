using UnityEngine;
using System.Collections;

public class Arrow: Bullet
{
    // Use this for initialization
    Vector3 tempV = new Vector3();
    Vector3 dir = new Vector3();
	void Start()
	{
		speed = 3.0f;

		attack = 7;
        attackType = (int)AttackType.AROW;
		//ae = null;
	}
    public override bool traceEnemy(Vector3 target)
	{
        
		curTime += Time.deltaTime;
		float t = curTime * speed;


        if (t >= 1.0f) t = 1.0f;

        this.transform.position = routeCalc.line(trans.position,targetTransform.position,t,out dir);

        this.transform.LookAt(targetTransform.position);

        tempV.Set(targetTransform.position.x,targetTransform.position.y,targetTransform.position.z);
		return t >= 1.0f;
		
	}
	// Update is called once per frame
	void Update()
	{
		
		if (bulletUpdate() == false)
		{
            
            isAlive = false;
			curTime += Time.deltaTime;
			float t = curTime * speed;
            this.transform.position = routeCalc.line(trans.position, tempV, t, out dir);
            this.transform.LookAt(targetTransform.position);

		}else
		traceEnemy(dest);
		if ((tempV - transform.position).magnitude < 0.7f)
		{
            if(isAlive ==true)
			mons.beHurt(this);

			DiedEffect();
			Destroy(gameObject);

		}
	}
	public override void initBullet(Attackable attackable)
	{
		base.initBullet(attackable);

		
	}
}
