using System.Collections;

using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.Events;

public class Choosable : MonoBehaviour 
{


    protected bool enable = true;
    public Transform parent = null;    //father canvas
    public GameObject UIObject; //UI to show
    public Model model;         //main model
    public string UITag;
    //Canvas UICanvas;            //main UI canvas
    public Canvas parentCanvas = GlobalRef.canvas;

    public bool isFocus;
    public Transform trans;

    public static Hashtable UIRegister = new Hashtable();

    public UIElement UIItem;

    //public List<UIButton> sharedButtonList;

    public string[] instruction;
    public MonsterProperties prop;

    //private bool enable = true;
    protected virtual void SetEnable(bool enable){
        this.enable = enable;
    }

	public virtual List<UIButton> getUI()
	{
		List<UIButton> ls = new List<UIButton>();

        if (prop.Skill == null) return ls;

		foreach (var ele in prop.Skill)
		{
			ls.Add(new UIButton(ele.ImgURL, new UnityAction(ele.callBack)));
		}

		return ls;
	}

	public virtual string[] getInstruction()
	{
        string[] res = new string[6];

        if (prop.type == "other") return null;

        res[0] = prop.attack.ToString("0000.0");
        res[1] = prop.armor.ToString("0000.0");
        res[2] = prop.speed.ToString("0000.0");

        res[3] = prop.GetAttack().ToString("0000.0");
        res[4] = prop.getArmorNum().ToString("0000.0");
        res[5] = prop.GetSpeed().ToString("0000.0");

        return res;

	}


	protected virtual void PreInitUIElement()   //init UI element in main UI rectangle
	{
        if(parent==null){
            //print("error no parent canvas");
            parent = GlobalRef.canvas.GetComponent<Transform>();
        }else{
            return;
        }

        if(UIItem!=null){
            
            UIItem.Background.pivot=new Vector2(0.5f, 0.0f);
			UIItem.Background.anchorMax= new Vector2(0.5f, 0.0f);
			UIItem.Background.anchorMin= new Vector2(0.5f, 0.0f);
			UIItem.Background.position= new Vector3(0, 0, 0);

            UIItem.obj.GetComponent<Transform>().SetParent(parent, false);
			

		}

         UIItem.setActive(false);

	}


    public void hideUI(){
        UIItem.setActive(false);
    }


    public virtual void displayUI(Canvas canvas){
        //Transform rect = canvas.transform.Find("MainRect");
        //print("click on obj");

            
            UIItem.setActive(true);

			/*TODO set position and size*/
		
		
    }

    public virtual void loseFocus(){
        isFocus = false;
        hideUI();
    }
    public virtual void OnClick(Vector3 ScreenPoint){

        if(GlobalRef.mainView.preSkill!=null){      //before this point, there's some skill been used
            //TODO add animation
            var skill = GlobalRef.mainView.preSkill;
            skill.invoke(skill.preFocus.GetComponent<Choosable>().prop, prop);
            GlobalRef.mainView.preSkill = null;

        }else{
			if (enable != true)
			{
				return;
			}
			displayUI(GlobalRef.canvas);

        }


    }

}