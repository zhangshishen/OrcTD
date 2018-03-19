using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
public class NewMonoBehaviour : MonoBehaviour
{
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
			
	}
}
//public delegate void UICallBack();


public class UIElement
{
    
    public string resourceURL;
    public string instruction;

    public UnityAction callback;    //callback that affect gameobject not other UI element
    public GameObject obj;

    public callback highlightCallback;
    public UIElement(){
        
    }
    public void addInstruction(string instruction){
        
    }

}