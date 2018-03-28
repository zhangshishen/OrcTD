using UnityEngine;
using System.Collections;

public class ArrowTower : Tower
{
	// Use this for initialization
	void Start()
	{

		/*TODO set parameter*/
		prop = new TowerProperties(GetComponent<Transform>().position);
		prop.SetFrequency(0.5f);
		prop.SetAttackRange(13.0f);
		attackerbase = new ArrowAttacker(prop);

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
