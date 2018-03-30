using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;




public class Tower : Choosable, MessageReceiver
{

    // Use this for initialization

    protected MonsterProperties prop;


    public int type;


    protected towerState state = 0;
    protected GameObject BulletObj;

    //protected string url = "Canon/CanonShell";

    public AttackerBase attackerbase = null;

	void Awake()
	{

		
       
		model = GlobalRef.getModel();
		parent = GlobalRef.canvas.GetComponent<Transform>();
        //monster = GameObject.FindGameObjectsWithTag("Monster");

        //addUIElement("","",uicallback0,0);
        //base.PreInitUIElement();
	}

    void Start()
    {
        prop = new TowerProperties(GetComponent<Transform>().position);
		prop.SetFrequency(1.0f);
		prop.SetAttackRange(8.0f);
        attackerbase = new AttackerBase(prop);
        //Debug.Log(GetComponent<Transform>().position);
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
        base.OnClick(ScreenPoint);  // choosable.onclick,Display UI
 
	}

    void chooseTarget(){
        
    }

	
	// Update is called once per frame
    public virtual void setRotate(Transform tar){
        //print("setrotate");
        rotate.setRotate(transform.Find("Tower_Top"),tar);
    }

	protected void Update() {
        
        if(attackerbase!=null){
            attackerbase.Update();
        }

		// set tower rotation
		if(attackerbase.targetID!=-1){
            setRotate(model.getEnemyByID(attackerbase.targetID).getTransform());
        }

	}
}