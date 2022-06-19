using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ChangeButtonColors : MonoBehaviour
{
	private Image target;

	public Color[] Colors;

	private void Awake()
	{
		target = GetComponent<Image>();
	}

	public void ChangeColor(int n)
	{
		target.color = Colors[n];
	}

}
