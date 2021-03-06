using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Events;

public class TowerBase : Choosable,MessageReceiver
{
    // Use this for initialization

    GameObject child;   //the tower on the base
    public static UIElement sharedUI = null;



	void Start()
	{
        
        if(sharedUI !=null){
            base.UIItem = sharedUI;
            return;
        }
        UIElement ui1 = new UIElement("UI/BaseButton0","",sharedUIcallback0,highlightcallback0);
        UIElement ui2 = new UIElement("UI/BaseButton1", "", sharedUIcallback1, highlightcallback1);

        List<UIElement> ls = new List<UIElement>();
        ls.Add(ui1);
        ls.Add(ui2);
        UIElement ui = new UIElement("UI/MainRect", "", null, null,null,0,ls);


        sharedUI = ui;
        base.UIItem = sharedUI;

        PreInitUIElement();

	}

    public override List<UIButton> getUI()
    {
        return null;
    }

	public static void createTower(string name) 
	{
		TowerBase cur = GlobalRef.mainView.curFocus.GetComponent<TowerBase>();
		GameObject BulletObj = Resources.Load(name) as GameObject;
		BulletObj = Instantiate(BulletObj, GlobalRef.mainView.curFocus.position, new Quaternion());

		cur.child = BulletObj;
		cur.loseFocus();

		cur.enable = false;
	}

	// Update is called once per frame
	void Update()
	{
			
	}
    public void highlightcallback0(){
        
    }
	public void highlightcallback1()
	{

	}

	public void highlightcallback2()
	{

	}




    public static void sharedUIcallback0(){    //create tower0
        createTower("Canon/Tower");

    }

	public static void sharedUIcallback1()
	{      
        createTower("RoundTower/ArrowTower");
	}
	
    public override void OnClick(Vector3 ScreenPoint)
    {
        base.OnClick(ScreenPoint);

    }

    public void receiveMessage(string message){
        
    }
}