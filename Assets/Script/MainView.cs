using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainView : MonoBehaviour {
    Text ScoreBoard;
    // Use this for initialization
    public Transform curFocus = null;
    public Camera mainCam;
    private Transform camT;
    int ClickMask;

    private float move_speed = 3.0f;
	void Start () {
        GlobalRef.mainView = this;
        camT = mainCam.GetComponent<Transform>();
        ClickMask = LayerMask.GetMask("Pointable");
	}
	
	// Update is called once per frame
	void Update () {
        //UI highLight
		if (EventSystem.current.IsPointerOverGameObject())  //click on the ui
		{
            GameObject go = EventSystem.current.currentSelectedGameObject;     
            return;
		}

		//camera move
		if (Input.GetMouseButton(0))
        {
            Vector3 vec = new Vector3(camT.position.x-(Input.GetAxis("Mouse X") * move_speed),camT.position.y,camT.position.z - (Input.GetAxis("Mouse Y")));
            camT.position = vec;
        }

		if (Input.GetMouseButtonDown(0))    //clear temp dialog
		{
			

		}
        //mouse pick choosable
		if (Input.GetMouseButtonUp(0))
		{
            if (mousePick() == true){
                return;
            }

		}

	}
    bool mousePick()        //test if click on GameObject(NO UI)
    {
        //Transform ta = GetComponent<Transform>();
        //Vector3 v3(ta);

        RaycastHit floorHit;
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(camRay, out floorHit, 1000f, ClickMask)){
            

			if (EventSystem.current.IsPointerOverGameObject())
			{//click on the ui
				return true;
			}


            if (curFocus != floorHit.transform){
                if(curFocus!=null)
                    curFocus.GetComponent<Choosable>().loseFocus();
            }

            curFocus = floorHit.transform;
            //print("curadd");
			Vector2 _pos = Vector2.one;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(GlobalRef.canvas.transform as RectTransform,
						Input.mousePosition, GlobalRef.canvas.worldCamera, out _pos);
            curFocus.GetComponent<Choosable>().OnClick(Input.mousePosition);

            return true;
        } else {
            //print("no focus");
            if(curFocus!=null){

                curFocus.GetComponent<Choosable>().loseFocus();
                curFocus = null;
            }
            return false;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        print("asd");
    }
    private void OnMouseUp()
    {
        
    }

    void DrawPrimitive(){
        
    }
    void DisplayUI()
    {

    }
    void DrawUI(){
        
    }
    void DrawScore(){
        
    }
    void DrawScoreBoard(){
        
    }
}
