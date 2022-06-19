using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteViz : MonoBehaviour
{
	public GameObject thumbVirtual;
	protected IMixedRealityHandJointService handJointService;

	Transform IndexMiddle, IndexDistal, RingDistal, RingMiddle, ThumbTip;

	// Start is called before the first frame update
	void Start()
	{
		handJointService = CoreServices.GetInputSystemDataProvider<IMixedRealityHandJointService>();

		if (handJointService != null)
		{
			IndexMiddle = handJointService.RequestJointTransform(TrackedHandJoint.IndexMiddleJoint, Handedness.Right);
			//IndexDistal = handJointService.RequestJointTransform(TrackedHandJoint.IndexDistalJoint, Handedness.Right);

			//RingMiddle = handJointService.RequestJointTransform(TrackedHandJoint.RingMiddleJoint, Handedness.Right);
			//RingDistal = handJointService.RequestJointTransform(TrackedHandJoint.RingDistalJoint, Handedness.Right);
			ThumbTip = handJointService.RequestJointTransform(TrackedHandJoint.ThumbTip, Handedness.Right);
		}
		else
		{
			Debug.Log("Tracking failed");
		}
	}

	// Update is called once per frame
	void Update()
	{
		//Vector3 indexMid = calcMidPoint(IndexMiddle.position, IndexDistal.position);
		//Vector3 ringMid = calcMidPoint(RingMiddle.position, RingDistal.position);

		//Vector3 remoteLine = indexMid - ringMid;

		//Debug.Log(remoteLine);
		thumbVirtual.transform.position = ThumbTip.position;

		transform.position = IndexMiddle.position;
		transform.rotation = Quaternion.LookRotation(IndexMiddle.transform.up);

	}

	Vector3 calcMidPoint(Vector3 v1, Vector3 v2)
	{
		return new Vector3(
			(v1.x + v2.x) / 2.0f,
			(v1.y + v2.y) / 2.0f,
			(v1.z + v2.z) / 2.0f
		);
	}
}
