using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSyncActivePostion : MonoBehaviour
{
	public GameObject Target;

	private void OnEnable()
	{
		Target.transform.position = transform.position;
		Target.transform.rotation = transform.rotation;
	}

}
