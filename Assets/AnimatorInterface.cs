using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorInterface : MonoBehaviour
{
	public Animator Target;
	public string IntParameterName;

	public void SetInt(int val)
	{
		Target.SetInteger(IntParameterName, val);
	}
}
