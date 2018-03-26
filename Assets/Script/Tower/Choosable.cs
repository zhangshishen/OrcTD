using System.Collections;

using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.Events;

public class Choosable : MonoBehaviour , UIDisplay
{
    protected bool enable = true;
    public Transform parent;    //father canvas
    public GameObject UIObject; //UI to show
    public Model model;         //main model

    //Canvas UICanvas;            //main UI canvas

    // Use this for initialization
    public bool isFocus;
    public Transform trans;

    public List<UIElement> UIItem = new List<UIElement>();

    //private bool enable = true;
    protected virtual void SetEnable(bool enable){
        this.enable = enable;
    }

	protected virtual void PreInitUIElement()
	{
		int i = 0;
		float initlen = 100.0f;
        Canvas canvas = GlobalRef.canvas;
        Transform rect = canvas.transform.Find("MainRect");
        print(UIItem.Count);
		foreach (var ele in UIItem)
		{

            //print(ele.resourceURL);
            //Transform rect = canvas.transform.Find("MainRect");
            ele.initUI(rect);

            //adjust position of UI 
            ele.setPosition(new Vector3(initlen + 80.0f * i++, 0));

            GlobalRef.mainModel.callBackHashTable.Add(ele.obj, ele.highlightCallback);

            //TODO
            ele.obj.SetActive(false);
			/*TODO set position and size*/
		}
	}

    public List<UIElement> getElement(){
        return null;
    }
    public void addUIElement(string url, string instruction, UnityAction callback, callback highlightCallback, int flag = 1)
	{
        UIElement uie = new UIElement(url, instruction, callback, highlightCallback, flag);

		UIItem.Add(uie);

        //print("add success!");

	}
	// Update is called once per frame
	

    public void hideUI(){
        foreach (var ele in UIItem)
        {
            ele.obj.SetActive(false);
        }
    }
    public virtual void displayUI(Canvas canvas){
        //Transform rect = canvas.transform.Find("MainRect");

        foreach(var ele in UIItem){
            
            ele.obj.SetActive(true);

			/*TODO set position and size*/
		}
		
    }

    public virtual void loseFocus(){
        isFocus = false;
        hideUI();
    }
    public virtual void OnClick(Vector3 ScreenPoint){
        if(enable != true){
            return;
        }
        displayUI(GlobalRef.canvas);
    }

}
