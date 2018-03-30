using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public delegate void buttonCallback();


public class StateButton : EventTrigger

{

    public buttonCallback callback;
    public string Instruction;
    private GameObject gameobj;

    public string UIName;

    public void OnSelect(PointerEventData data){
        print("adda");
    }


    public override void OnPointerEnter(PointerEventData data){
        showInstruction();
    }
    public override void OnPointerExit(PointerEventData data){
        //print("leave"); 
        gameobj.SetActive(false);
        //GlobalRef.hideTemp();
    }
    public virtual void showInstruction()
    {
        if (gameobj != null)
        {
            //print("unnull");
            if (gameobj.activeSelf == false)
                gameobj.SetActive(true);
            //GlobalRef.AddTempUI(gameobj);
            return;
        }

        RectTransform parent = GetComponent<RectTransform>();

        GameObject go = Resources.Load("UI/DisplayPanel") as GameObject;
        go = Instantiate(go, parent);

        Transform got = go.GetComponent<RectTransform>();
        Transform text = got.Find("Text");
        Text txt = text.GetComponent<Text>();
        txt.text = Instruction;


        RectTransform curRect = go.GetComponent<RectTransform>();
        gameobj = go;

        curRect.anchorMax = new Vector2(0, 1);
        curRect.anchorMin = new Vector2(0, 1);
        curRect.pivot = new Vector2(0, 0);
        curRect.localPosition = new Vector3(0, 35, 0);

    }
}