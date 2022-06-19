using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SD : MonoBehaviour
{
	public float Min, Max;
	public float Cur;
	public RectTransform rt;

	public void SED(SliderEventData d)
	{
		float val = d.NewValue;
		Cur = Mathf.Lerp(Min, Max, val);
		var p = rt.anchoredPosition;
		p.y = Cur;
		rt.anchoredPosition = p;
	}

}
