using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class TowerBase : Choosable,MessageReceiver
{
    // Use this for initialization

    GameObject child;   //the tower on the base
    public static List<UIElement> temp = null;

	void Start()
	{
        if(temp!=null){
            base.UIItem = temp;
            return;
        }
		
		model = GlobalRef.getModel();
		parent = GetComponent<Transform>();

        addUIElement("UI/BaseButton0", "", callback0,highlightcallback0);
        addUIElement("UI/BaseButton1", "", callback1,highlightcallback1);
        addUIElement("UI/BanButton", "", ban,highlightcallback2);

        /*TODO init UIElement*/

        base.PreInitUIElement();
        temp = UIItem;
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
    }
    public void callback0(){
        GameObject BulletObj = Resources.Load("Canon/Tower") as GameObject;
        BulletObj = Instantiate(BulletObj,GlobalRef.mainView.curFocus.position,new Quaternion());
        child = BulletObj;
        loseFocus();
    }
	public void callback1()
	{
		GameObject BulletObj = Resources.Load("RoundTower/ArrowTower") as GameObject;
		BulletObj = Instantiate(BulletObj, GlobalRef.mainView.curFocus.position, new Quaternion());
        child = BulletObj;
        loseFocus();
	}
	
    public override void OnClick(Vector3 ScreenPoint)
    {
        base.OnClick(ScreenPoint);

    }

    public void receiveMessage(string message){
        
    }
}
