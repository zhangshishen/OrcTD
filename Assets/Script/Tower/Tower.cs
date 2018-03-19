using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


//public interface Attacker{      //everything can attack
//    void attack (Attackable trans);
//}

public class Tower : Choosable, MessageReceiver
{

    // Use this for initialization

    public float frequency;
    public float attackRange;

    public float curInterval = 0.0f;
    public int type;

    public int targetID = -1;
    protected towerState state = 0;
    protected GameObject BulletObj;

    protected string url = "Canon/CanonShell";

	void Awake()
	{
        

       frequency = 1.0f;
       attackRange = 8.0f;
		model = GlobalRef.getModel();
		parent = GlobalRef.canvas.GetComponent<Transform>();
        //monster = GameObject.FindGameObjectsWithTag("Monster");

        //addUIElement("","",uicallback0,0);
        base.PreInitUIElement();
	}



    public void uicallback0(){
        
    }

    public virtual Bullet GetBullet(){
        /*TODO override*/
        print(url);
        GameObject BulletObj = Resources.Load(url) as GameObject;
        BulletObj = Instantiate(BulletObj);
        Vector3 vec = new Vector3(transform.position.x,transform.position.y+3,transform.position.z);
        BulletObj.GetComponent<Transform>().position = vec;

        return BulletObj.GetComponent<Bullet>();
        //return null;
    }
    //Transform transform;


    public override void loseFocus(){
        hideUI();
        isFocus = false;
    }



    public virtual void receiveMessage(string message)
	{
        
    }
    public override void OnClick(Vector3 ScreenPoint){
        base.OnClick(ScreenPoint);
        //print("x=" + ScreenPoint.x + " y=" + ScreenPoint.y + " Z=" + ScreenPoint.z);
  //      if (isFocus == true) return;
  //      isFocus = true;
  //      if (UIObject == null)
  //      {
  //          //print("uionull");
  //          UIObject = Resources.Load("UI/Button") as GameObject;
  //          UIObject = Instantiate(UIObject,parent);
  //          UIObject.GetComponent<Transform>().position = ScreenPoint;
  //      }else{
  //          /*
  //          TODO display UI 
  //          */
  //          //print("settrue");
  //          UIObject.SetActive(true);
  //          UIObject.GetComponent<Transform>().position = ScreenPoint;

  //      }
		////Instantiate(UICanvas);
		////button.transform.position = ScreenPoint;
	}

    void chooseTarget(){
        
    }
	public virtual void attack(Attackable trans)
	{
        //print("attack");
        Bullet bullet = GetBullet();
        if (trans == null) print("attnull");
        if (bullet == null) print("butnull");
        bullet.initBullet(trans);
        //trans.beHurt(GetBullet());
	}
	// Update is called once per frame
    public virtual void setRotate(Transform tar){
        //print("setrotate");
        rotate.setRotate(transform.Find("Tower_Top"),tar);
    }

	protected void Update() {       
        curInterval += Time.deltaTime;

        if (targetID != -1)     // Dont change target
        {
            Monster curm = model.getEnemyByID(targetID);
            if (curm!=null)
            {
                if((curm.transform.position-transform.position).magnitude<=attackRange){
                    setRotate(curm.transform);
                    if (curInterval < frequency)
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
        List<Monster> l= model.MonsterList;
        foreach (var mons in l){
            Vector3 v = mons.transform.position - transform.position;

            if(v.magnitude<=attackRange){
                targetID = mons.ID;
				/*TODO hit monster*/

                setRotate(mons.transform);
				if (curInterval < frequency)
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
