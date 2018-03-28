using System.Collections;

using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.Events;

public class Choosable : MonoBehaviour 
{


    protected bool enable = true;
    public Transform parent = null;    //father canvas
    public GameObject UIObject; //UI to show
    public Model model;         //main model

    //Canvas UICanvas;            //main UI canvas
    public Canvas parentCanvas = GlobalRef.canvas;
    // Use this for initialization
    public bool isFocus;
    public Transform trans;

    public static Hashtable UIRegister = new Hashtable();

    public UIElement UIItem;

    //private bool enable = true;
    protected virtual void SetEnable(bool enable){
        this.enable = enable;
    }

	protected virtual void PreInitUIElement()   //init UI element in main UI rectangle
	{
        if(parent==null){
            //print("error no parent canvas");
            parent = GlobalRef.canvas.GetComponent<Transform>();
        }else{
            return;
        }

        if(UIItem!=null){
            
            //UIItem.obj.GetComponent<Transform>().SetParent(parent, false);

            //RectTransform rt = UIItem.obj.GetComponent<RectTransform>();
			//rt.position.Set(600, 0, 0);
			//UIItem.Background.anchoredPosition.Set(0.5f, 0.0f);
            //print(UIItem.Background.localPosition);
            //UIItem.Background.localPosition.Set(100, 100, 100);
            //print(UIItem.Background.localPosition);  
			//set position to bottom middle
			
			//print("set data");
			UIItem.Background.pivot.Set(0.5f, 0.0f);
			UIItem.Background.anchorMax.Set(0.5f, 0.0f);
			UIItem.Background.anchorMin.Set(0.5f, 0.0f);
			UIItem.Background.position.Set(0, 0, 0);

            UIItem.Background.pivot=new Vector2(0.5f, 0.0f);
			UIItem.Background.anchorMax= new Vector2(0.5f, 0.0f);
			UIItem.Background.anchorMin= new Vector2(0.5f, 0.0f);
			UIItem.Background.position= new Vector3(0, 0, 0);

            UIItem.obj.GetComponent<Transform>().SetParent(parent, false);
			
			//UIItem.Background.

		}
            //print(ele.resourceURL);
            //Transform rect = canvas.transform.Find("MainRect");
           // ele.initUI(rect,null);

            //adjust position of UI 
           // ele.setPosition(new Vector3(initlen + 80.0f * i++, 0));

           //GlobalRef.mainModel.callBackHashTable.Add(ele.obj, ele.highlightCallback);

            //TODO
         UIItem.setActive(false);
			/*TODO set position and size*/
		
	}


    /*
    public void addUIElement(string url, string instruction, UnityAction callback, callback highlightCallback, int flag = 1)
	{
        UIElement uie = new UIElement(url, instruction, callback, highlightCallback, flag);

		UIItem.Add(uie);

        //print("add success!");

	}*/
	// Update is called once per frame
	

    public void hideUI(){
        UIItem.setActive(false);

    }


    public virtual void displayUI(Canvas canvas){
        //Transform rect = canvas.transform.Find("MainRect");
        //print("click on obj");

            
            UIItem.setActive(true);

			/*TODO set position and size*/
		
		
    }

    public virtual void loseFocus(){
        isFocus = false;
        hideUI();
    }
    public virtual void OnClick(Vector3 ScreenPoint){
        print(name + " been click, enable = "+enable);
        if(enable != true){
            return;
        }
        displayUI(GlobalRef.canvas);
    }

}