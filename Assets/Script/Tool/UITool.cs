using UnityEngine;

using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;
using UnityEngine.Events;




public class UIElement
{
    
    public string resourceURL;
    public string instruction;
    public List<string> additionalInstruction;

    public UnityAction callback;    //callback that affect gameobject not other UI element
    public GameObject obj;

    public List<UIElement> child;

    public float scale = 1.0f;

    private int flag;
    public callback highlightCallback;

    public void AddChild(UIElement ui){
        child.Add(ui);
    }

    public UIElement(string resourceurl, string instruction, UnityAction call, callback highlight, int flag = 1,List<UIElement> child = null){
        this.resourceURL = resourceurl;
        this.instruction = instruction;
        this.callback = call;
        this.highlightCallback = highlight;
        this.flag = flag;
        this.child = child;
    }

    public void setPosition(Vector3 pos){
        obj.GetComponent<RectTransform>().anchoredPosition = pos;
    }

    public void initUI(Transform parent){
		Canvas canvas = GlobalRef.canvas;
		GameObject go = Resources.Load(resourceURL) as GameObject;

		obj = GameObject.Instantiate(go, parent);

        initChildPosition();

        if (flag == 1){
            Button sbt = obj.GetComponent<Button>();
			sbt.onClick.AddListener(delegate () { callback(); });
        }else{
            
        }
    }

    private void initChildPosition(){
        int i = 0;
        if (child == null)
            return;
		foreach (var ele in child)
		{

            ele.initUI(this.obj.GetComponent<Transform>());
            ele.scale = this.scale * 0.3f;
            ele.setPosition(new Vector3(0,ele.scale * 100.0f + ele.scale * 80.0f * i++));

			GlobalRef.mainModel.callBackHashTable.Add(ele.obj, ele.highlightCallback);

			//TODO
			ele.obj.SetActive(false);
			/*TODO set position and size*/
		}
    }
    public void addInstruction(string instruction){
        
    }

}