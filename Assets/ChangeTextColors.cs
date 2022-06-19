using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ChangeTextColors : MonoBehaviour
{
	private Text target;

	public Color[] Colors;

	private void Awake()
	{
		target = GetComponent<Text>();
	}

	public void ChangeColor(int n)
	{
		target.color = Colors[n];
	}

}

