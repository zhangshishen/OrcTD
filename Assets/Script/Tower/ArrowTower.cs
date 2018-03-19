using UnityEngine;
using System.Collections;

public class ArrowTower : Tower
{
	// Use this for initialization
	void Awake()
	{
		
        /*TODO set parameter*/
		frequency = 0.5f;
		attackRange = 13.0f;
        url = "RoundTower/Arrow";

		model = GlobalRef.getModel();
		parent = GlobalRef.canvas.GetComponent<Transform>();
		//monster = GameObject.FindGameObjectsWithTag("Monster");

		//addUIElement("","",uicallback0,0);

	}
	
	// Update is called once per frame
	void Update()
	{
        
        base.Update();
	}
}
