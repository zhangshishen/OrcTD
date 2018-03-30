using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class Tower{

//    float attackRange;
//    float attackTime;
//    bool isEnable;
//    float curAttackTime;
//    // tower attack enemy
//    void attack(){

//    }

//    void update(){

//    }

//}
public class GlobalRef{
    public static Model mainModel;
    public static MainView mainView;



    public static Model getModel(){
        return mainModel;
    }
    public static Choosable focus;

	public static Canvas canvas;
	public static Vector3 WorldToUIPoint(Canvas canvas, Transform worldGo)
	{
		Vector3 v_v3 = Camera.main.WorldToScreenPoint(worldGo.position);
        Vector3 v_ui = Camera.main.ScreenToWorldPoint(v_v3);
		Vector3 v_new = new Vector3(v_ui.x, v_ui.y, canvas.GetComponent<RectTransform>().anchoredPosition3D.z);
		return v_new;
	}
}
public interface schedule{
    void updateCallback(float deltaTime);
}

public delegate void callback();

public class Model : MonoBehaviour {        //create and delete monster

    //MainView mainView;

    private static float timeBeforeStart = 3;      

    public List<Attackable> AttackableList = new List<Attackable>();
    public List<Tower> TowerList = new List<Tower>();
    public List<int> MonsterNum = new List<int>();

    public Hashtable callBackHashTable = new Hashtable();

    public float gameTime;
    //float timeInterval;
    float monsterFrequency;

    float curTime = 0;
    //float curMonsterTime = 0;
    float curMonsterNumber = 0;
    int TotalMonsterNumber;

    //int totalWave;
    //int curWave = 0;

    List<int> monsterNumber = new List<int>();
    List<string> monsterVector = new List<string>();  //monster array in reverse order refer to prefab




    public Vector3 bornPoint;
    Quaternion rotate = new Quaternion(0,270,0,0);

    int curID = 0;


	// Use this for initialization

    void initGame(){
        //totalWave = 1;
        monsterNumber.Insert(0,5);
        for(int i = 0;i<5;i++)
            monsterVector.Insert(0,"Monster");
    }

	void Awake () {
        GlobalRef.mainModel = this;
        GlobalRef.canvas = GameObject.FindGameObjectWithTag("ChooseCanvas").GetComponent<Canvas>();
        initGame();
        gameTime = 50.0f;
        monsterFrequency = 2.0f;
        updateWave(0);
	}
	// Update is called once per frame



	void Update()
	{
        
        curTime += Time.deltaTime;
        float time = curTime;


        if(time<timeBeforeStart){
            return;
        }else{
            time = time - timeBeforeStart;
                //timeBeforeStart = 0;
        }


        if(time>0){             //create Monster
            //curTime += time;
            //print(curMonsterNumber);
            if (time / monsterFrequency >= curMonsterNumber){
                if (curMonsterNumber < TotalMonsterNumber){
					curMonsterNumber += 1;
					CreateEnemy(time % monsterFrequency);
                }
                 
            }
        }

        if(time>=gameTime){     //next wave
            updateWave(time-gameTime);
        }

	}
    public void initMonster(){
        
    }
    public void updateWave(float deltaTime){

        if(monsterNumber.Count == 0){
            GameOver();
        }else{
            curTime = 0;
            curMonsterNumber = 0;
            TotalMonsterNumber = monsterNumber[monsterNumber.Count - 1];
            monsterNumber.RemoveAt(monsterNumber.Count - 1);
            curTime = deltaTime;
            //print(monsterNumber.Count);
        }
    }
    public void GameOver(){
        //Destroy(gameObject);
        //print("gameover");
    }
    public void BuildTower(Vector3 v){
        
    }
    void UpdateTower(){
        
    }
    public void pickTower(){
        
    }

    void CreateEnemy(float delta){
        //print(monsterVector.Count);

        GameObject monster = (GameObject)Resources.Load(monsterVector[monsterVector.Count - 1]);
        monsterVector.RemoveAt(monsterVector.Count - 1);
        monster = Instantiate(monster,bornPoint,rotate);
        Monster temp = monster.GetComponent<Monster>();

        AttackableList.Add(temp);

        temp.ID = curID;

        //monsterNumber.Add(curID);
        curID++;
        //monster.GetComponent<Animator>();


    }
    public Attackable getEnemyByID(int id){
		//List<Monster>.Enumerator mE = MonsterList.GetEnumerator();
		//List<int>.Enumerator iE = MonsterNum.GetEnumerator();

        //print("count=" + MonsterList.Count);
        foreach(var mons in AttackableList){
            if (mons.getID() == id)
                return mons;
        }
        return null;

		
    }
    public void EnemyDied(int id)
    {
		/*TODO*/

		foreach (var mons in AttackableList)
		{
            if (mons.getID() == id){
                mons.died();
                AttackableList.Remove(mons);
                return;
                /*TODO*/

            }
				
		}


        //MonsterNum.Remove(iE.Current);



    }
    void UpdateEnemy(){
        
    }
	
}
