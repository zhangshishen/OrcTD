using UnityEngine;
using System.Collections;

public class Skill
{
    // Use this for initialization
    public string ImgURL;
    public int tarType;    //skill type, include: everyone, enemy, ally

    public Choosable parent;
    public Transform preFocus;

    public virtual void invoke(MonsterProperties father,MonsterProperties target){
        //main function
    }

    public virtual void callBack(){
        GlobalRef.mainView.preSkill = this;
        preFocus = GlobalRef.mainView.curFocus;
    }

    public virtual Effect getEffect(){  //only for passiveskill
        return null;
    }

}
