using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public delegate void buttonCallback();


public class StateButton : EventTrigger

{

    public buttonCallback callback;
    public string instruction;
    private GameObject gameobj;
    public void OnSelect(PointerEventData data){
        print("adda");
    }


    public override void OnPointerEnter(PointerEventData data){
        showInstruction();
    }
    public override void OnPointerExit(PointerEventData data){
        //print("leave"); 

        gameobj.SetActive(false);
    }
	public void showInstruction(){
        if(gameobj!=null){
            //print("unnull");
            if (gameobj.activeSelf == false)
                gameobj.SetActive(true);
            gameobj.GetComponent<RectTransform>().pivot.Set(0,0);
			gameobj.transform.position = Input.mousePosition;
            return;
        }
        GameObject go = Resources.Load("UI/DisplayPanel") as GameObject;
        go = Instantiate(go,GlobalRef.canvas.transform);
        gameobj = go;

        go.transform.position = Input.mousePosition;

    }
}