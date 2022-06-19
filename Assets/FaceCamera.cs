using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
	void Update()
	{
		var cam = Camera.main;
		if (cam == null)
		{
			return;
		}

		transform.LookAt(cam.transform);
	}
}
