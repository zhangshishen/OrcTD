using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class NoMessageImage : Image
{
	// Use this for initialization
	override public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
	{
		return false;
	}
}
