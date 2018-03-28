using UnityEngine;
using System.Collections;


public class Bullet : MonoBehaviour,tracer,Hurtable
{
    // Use this for initialization

    protected float speed;
    protected float attack;
    protected float curTime;

    protected bool isAlive = true;

    public int attackType;

    public AttackEffect ae;

    public Transform trans;
    public Transform targetTransform;
    public Vector3 dest;

    int targetID;

    protected Attackable mons;


    public virtual float getDamage(){

        return attack;
    }
    public virtual AttackType getType(){
        //print("attype=" + (AttackType)attackType);
        return (AttackType)attackType;
    }
    public AttackEffect getAE(){
        return null;
    }
    protected virtual void Effect(){
        
    }
    protected virtual void DiedEffect(){
        
    }
    public virtual void initBullet(Attackable attackable){
		mons = attackable;
		trans = GetComponent<Transform>();

		targetTransform = mons.getTransform();
		addTarget(mons.getID());
		dest = targetTransform.position;

		Transform target = targetTransform;
    }


	void Start()
	{
        attack = 5;
        //initBullet();
        //trans = GetComponent<Transform>();
	}

    public  virtual bool traceEnemy(Vector3 target) {
        
        return true;
    }

    public void addTarget(int id){
        targetID = id;

    }

    public virtual bool bulletUpdate(){
        if (GlobalRef.mainModel.getEnemyByID(targetID) != null)
            return true;
        return false;
    }

	// Update is called once per frame
	void Update()
	{
		
	}
}
