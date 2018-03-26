using UnityEngine;

using System.Collections;
using UnityEngine.UI;
public class Monster : Choosable,Attackable
{
    // Use this for initialization

    public Slider slider;
    //public NavMeshAgent nav;
    Vector3 dest = new Vector3(5.93f,0,2);

    public Animator anim;
    Navigator navigator;
    Transform transform;

    int curNavi = 0;
    Vector3 curDest;


    //need to set for every enemy
    public MonsterProperties prop;

    private float deltaTime;
    public int ID;

    bool isDied = false;



	void Awake()
	{

		navigator = GameObject.FindGameObjectWithTag("Navi").GetComponent<Navigator>();



		transform = GetComponent<Transform>();

        transform.LookAt(navigator.naviPoint[2]);
        prop = new Goblin(transform.position);

		anim = GetComponent<Animator>();
		anim.speed = prop.totalSpeed;

		slider = transform.Find("Canvas").transform.Find("Slider").GetComponent<Slider>();
		slider.maxValue = prop.life;
		slider.minValue = 0.0f;

        updateBloodUI();

	}
    private Vector3 temp = new Vector3();
    private void updateBloodUI(){
        temp.x = transform.position.x;
        temp.y = transform.position.y + 3.7f;
        temp.z = transform.position.z;
        Vector3 v = 
            Camera.main.WorldToScreenPoint(temp);
        v.y += 10.0f;
        //v.x -= 0.0f;
		slider.transform.position = v;
    }
    public Transform getTransform(){
        return transform;
    }
    void updateAnimState(){
        anim.speed = prop.totalSpeed;
        /*TODO*/
    }
    public int getID(){
        return ID;
    }
    public objectType getType(){
        return objectType.TypeMonster;
    }
    public void died(){
		anim.SetTrigger("died");
		prop.totalSpeed = 1;
		Destroy(gameObject, 2);
    }
    void updateNavi(){
        
        float less = float.MaxValue;
        int lessPoint = 0;
        int length = navigator.naviPoint.Length;


        for (int i = 1; i < length - 1;i++){

			Vector3 v1 = navigator.naviPoint[i].position - transform.position;
			Vector3 v2 = navigator.naviPoint[i+1].position - transform.position;

            float dis = calcDis(navigator.naviPoint[i].position, navigator.naviPoint[i + 1].position, transform.position);

			if (Vector3.Dot(v1, v2) > 0)
			{
                dis = Mathf.Min(v1.magnitude, v2.magnitude);
			}
            if (dis < 0.3) {
                less = dis;
                lessPoint = i;
            }
        }

        curDest = navigator.naviPoint[lessPoint+1].position;

    }

    float calcDis(Vector3 v1,Vector3 v2,Vector3 v3){
        Vector3 m = v3 - v1;
        Vector3 n = v2 - v1;
        n.Normalize();
        float c = Vector3.Dot(m,n);
        n = n * (-c);
        n = n + m;
        return n.magnitude;
    }
	
    void updatePos(){
        
        Vector3 dir = curDest - transform.position;
        dir.Normalize();
        Quaternion target = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, deltaTime * prop.turnSpeed);
        transform.position = (transform.position + dir*prop.speed*deltaTime);

    }
	// Update is called once per frame
	void Update()
    {
        updateAnimState();

        updateBloodUI();
        slider.value = prop.life;
        if(isDied){

            return;
        }
        this.deltaTime = Time.deltaTime;
        updateNavi();
        updatePos();
        Vector3 cur = (GetComponent<Transform>().position - dest);
        if (cur.magnitude < 1.1f){
            //arrive destination
            //point
            /*

            TODO

            */
            isDied = true;
            GlobalRef.mainModel.EnemyDied(ID);
        }
	}

    public void beHurt(Hurtable bullet){
        float coef = ArmorCalc.GetCoefficient(bullet.getType(),prop.GetArmortype());
        //print("coef=" + coef);

        //damage calculate fomula
        float f = Mathf.Atan(prop.getArmorNum()/10);
        f = 1 - f / Mathf.PI * 2;

        Debug.Log(f);

        prop.life-=bullet.getDamage() * coef*(f);


        if (prop.life<=0){
            isDied = true;
            GlobalRef.mainModel.EnemyDied(ID);
        }
    }

}
