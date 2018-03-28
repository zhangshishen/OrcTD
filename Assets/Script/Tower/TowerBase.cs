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

        print("init success");
        UIElement ui2 = new UIElement("UI/BaseButton1", "", sharedUIcallback1, highlightcallback1);
        print("init success");
        List<UIElement> ls = new List<UIElement>();
        ls.Add(ui1);
        ls.Add(ui2);
        UIElement ui = new UIElement("UI/MainRect", "", null, null,null,0,ls);


        //model = GlobalRef.getModel();
        //parent = GetComponent<Transform>();
        //print(name + "bing delegate,direction = " + parent.position);
        //addUIElement("UI/BaseButton0", "", new UnityAction(sharedUIcallback0),highlightcallback0);
        //addUIElement("UI/BaseButton1", "", new UnityAction(sharedUIcallback1),highlightcallback1);
        //addUIElement("UI/BanButton", "", ban,highlightcallback2);

        /*TODO init UIElement*/

        //base.PreInitUIElement();

        sharedUI = ui;
        base.UIItem = sharedUI;

        PreInitUIElement();
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
    public void ban(){
        Destroy(child);
        loseFocus();
        this.enable = true;
    }
    public void sharedUIcallback0(){    //create tower0
        TowerBase cur = GlobalRef.mainView.curFocus.GetComponent<TowerBase>();

        GameObject BulletObj = Resources.Load("Canon/Tower") as GameObject;
        BulletObj = Instantiate(BulletObj,GlobalRef.mainView.curFocus.position,new Quaternion());

        cur.child = BulletObj;
        cur.loseFocus();
        //print(name+"change enable to false");
        cur.enable = false;
    }
	public void sharedUIcallback1()
	{                           //create tower1
        TowerBase cur = GlobalRef.mainView.curFocus.GetComponent<TowerBase>();
		GameObject BulletObj = Resources.Load("RoundTower/ArrowTower") as GameObject;
		BulletObj = Instantiate(BulletObj, GlobalRef.mainView.curFocus.position, new Quaternion());

		cur.child = BulletObj;
		cur.loseFocus();
		//print(name+"change enable to false");
		cur.enable = false;
	}
	
    public override void OnClick(Vector3 ScreenPoint)
    {
        base.OnClick(ScreenPoint);

    }

    public void receiveMessage(string message){
        
    }
}