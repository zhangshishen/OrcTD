using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface tracer
{
	bool traceEnemy(Vector3 target);    //adjust direction and position
}


public class routeCalc                  //a tools class for calculate route, using bezier, spline
{             //calculate bullet which has fixed route
    public static Vector3[] array = new Vector3[10];
    public static Vector3[] point = new Vector3[10];
    public static Vector3 interpolate(Vector3 src, Vector3 dst, float t){
		Vector3 ret = new Vector3();
		ret.x = src.x * (1 - t) +dst.x*t;
        ret.y = src.y * (1 - t) + dst.y * t;
        ret.z = src.z * (1 - t) + dst.z * t;

        return ret;
    }
    public static Vector3 line(Vector3 src,Vector3 dst, float t,out Vector3 dir){
        dir = dst - src;
        dir.Normalize();
        return interpolate(src, dst, t);
    }
	public static Vector3 bezier(Vector3[] po, float t)
	{
        //ArrayList array = new ArrayList();
        if (t > 1) t = 1;
        if (t < 0) t = 0;
        int m = po.Length;

        //MonoBehaviour.print("m=" + m);
        //Vector3[] array = new Vector3[po.Length];
        //Vector3[] point = new Vector3[po.Length];
        for (int i = 0; i < m;i++){
            point[i] = po[i];
        }

		while (m > 1)
		{
            
			for (int i = 0; i < m - 1; i++)
			{
				array[i] = (t*point[i + 1] +(1-t)* point[i]);
			}
			Vector3[] temp = array;
			array = point;
			point = temp;

            m--;
            //MonoBehaviour.print("x=" + point[0].x + " y=" + point[0].y + " z=" + point[0].z);
		}
		return point[0];
	}
	public static void calcRoute()
	{

	}
}