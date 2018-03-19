using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public enum towerState { Building, Living, Sleeping };
public delegate void towerCallback();
public interface Attackable     //everything can be hurt
{
	void beHurt(Hurtable bullet);
    Transform getTransform();
    int getID();
}

public enum AttackType {COMMON,AROW,MAGIC,PURE};
public enum ArmorType {LIGHT,HEAVY,BUILDING,NONE};

public interface Armor  //object that has Armor 
{
	ArmorType GetArmortype();
    float getArmorNum();
}

public interface UIDisplay  //object that can be displayed on UI
{
    
    void displayUI(Canvas canvas);
    void hideUI();
    List<UIElement> getElement();
}

public interface MessageReceiver{
    void receiveMessage(string message);
}

public interface Hurtable       //everything can make damage
{
	float getDamage();
    AttackType getType();
	AttackEffect getAE();

}

public class rotate{
    public static void setRotate(Transform cur,Transform targets){
        Vector3 dir =  targets.position - cur.position;
        dir.y = 0;
		dir.Normalize();
		Quaternion target = Quaternion.LookRotation(dir);


        cur.rotation = target;
    }
}
