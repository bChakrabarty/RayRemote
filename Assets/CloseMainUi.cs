using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class CloseMainUi : MonoBehaviour
{
	private Animator target;
	public GameObject ResetButton;
	public GameObject Content;

	public int UI
	{
		get
		{
			int val;
			val = target.GetInteger("IntegerValueOfUI");
			return val;
		}

		set
		{
			target.SetInteger("IntegerValueOfUI", value);
		}
	}

	private void Awake()
	{
		target = GetComponent<Animator>();
	}

	public void Close()
	{
		if (UI == 0)
		{
			//transform.parent.gameObject.SetActive(false);

			Content.SetActive(false);
			ResetButton.SetActive(true);
			// disable the combined UI
			//Obj.SetActive(false);

		}
		else
		{
			UI = 0;
		}
	}
}