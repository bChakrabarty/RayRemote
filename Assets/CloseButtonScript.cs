using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;

public class CloseButtonScript : MonoBehaviour
{
	public UnityEvent onTouch;

	void OnTriggerEnter()
	{
		onTouch.Invoke();
	}
}
