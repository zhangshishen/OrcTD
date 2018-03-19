using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainController : MonoBehaviour {
    
    Model mainModel;
    MainView mainview;
    enum Event {empty,BuildTower,WhichToBuild,ChooseTower,MouseDown,MouseDrag,MouseUp };
    Vector3 pickPoint;
    List<Event> eventList;
    Event mainEvent;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        switch(mainEvent){
            case Event.empty:
                break;
            case Event.BuildTower:
                mainModel.BuildTower(pickPoint);
                break;
            case Event.WhichToBuild:
                mainModel.pickTower();
                break;

        }
	}
}
