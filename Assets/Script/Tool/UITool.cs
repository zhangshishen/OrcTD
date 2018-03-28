using UnityEngine;

using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;
using UnityEngine.Events;


public class UIConfig{      //config of UIElement 
    
    public bool order = true;  //true = row, false = column
    public bool align = true;

    //public float space = 10.0f;

    public string backGroundImageURL;   

    public float[] intervalScale = new float[0];       //the scale of every interval
    public float defaultInterval = 10.0f;

    public callback ButtonDownCallback;
    public callback ButtonUpCallback;
    public callback MoveOnCallback;

    public UIConfig(){
        
    }
}

public class UIElement
{
    
    public string resourceURL;
    public string instruction;
    public List<string> additionalInstruction;

    public callback highlightCallback;
    public UnityAction callback;    //callback that affect gameobject not other UI element
    public GameObject obj;

    public List<UIElement> child;


    public float scale = 1.0f;

    private int flag;   //is button or not
    private UIConfig config;

    public RectTransform Background;   

    public void setActive(bool active){
        obj.SetActive(active);
        if (child == null) return;
        foreach (var ele in child){
            ele.setActive(active);
        }
    }

    public Rect getSize(){
        return Background.rect;
    }
    public RectTransform getUICanvasByRect(){
        return Background;
    }

    public void AddChild(UIElement ui){
        child.Add(ui);
    }
    public void setScale(float scale){
        Background.localScale *= scale;
    }

	//child should have already been init
    public UIElement(string resourceurl, string instruction, UnityAction call, callback highlight, UIConfig config = null,int flag = 1, List<UIElement> child = null)  
	{
        if (config==null||this.config ==null){
            this.config = new UIConfig();
        }
		this.resourceURL = resourceurl;
		this.instruction = instruction;

		this.callback = call;
		this.highlightCallback = highlight;
		this.flag = flag;

		//this.config = config;
		this.child = child;

		GameObject go = Resources.Load(resourceURL) as GameObject;

		obj = GameObject.Instantiate(go);


		Background = obj.GetComponent<RectTransform>();

		if (flag == 1)
		{
			Button sbt = obj.GetComponent<Button>();
			sbt.onClick.AddListener(callback);
		}
		else
		{

		}

        initChild();

	}



    public void setPosition(Vector3 pos){
        obj.GetComponent<RectTransform>().anchoredPosition = pos;
    }

    private void initChild(){
        
        if (child == null||child.Count==0)
            return;

        float width = Background.rect.width;
		float height = Background.rect.height;
        float defaultInverval,curPointX,curPointY,IntervalX,IntervalY;

        Vector2 pivot;

        if (config == null || config.order == true){    //list in column

            pivot.x = 0.5f;
            pivot.y = 1.0f;

            defaultInverval = height / (float)child.Count;
			if (config.align)
			{
				defaultInverval = 10;
			}

            IntervalX = 0;
            IntervalY = defaultInverval;

            curPointX = width / 2;
            curPointY = height-15;

        }else{

			pivot.x = 0.0f;
            pivot.y = 0.5f;

            defaultInverval = width / (float)child.Count;
			if (config.align)   //not average
			{
				defaultInverval = 10;
			}

			IntervalX = defaultInverval;
			IntervalY = 0;

			curPointX = width + 15;
			curPointY = height /2;
        }

        int curCount = 0;

        foreach (var ele in child)
		{
            Transform cur = Background.GetComponent<Transform>();
            ele.Background.GetComponent<Transform>().SetParent(cur);

            //set scale
            if (config.intervalScale.Length>curCount){    //interval of 
                IntervalX *= config.intervalScale[curCount];
                IntervalY *= config.intervalScale[curCount];
            }

            ele.Background.pivot.Set(pivot.x,pivot.y);
            ele.Background.position.Set(curPointX + IntervalX, curPointY + IntervalY, 0);
            /*TODO set position and size*/
            curCount++;
		}
    }
    public void addInstruction(string instruction){
        
    }

}