using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
	public bool isActive = false;

	public bool isGravityActive = false;

	protected LineRenderer lineRenderer;

	// Number of points on the line
	public int numPoints = 300;
	public float distanceFactor = 12.0f;
	public GameObject PointingVectorProxy;
	protected bool PointingVectorAuto = true;

	public float jitterThreshold = 0.006f;
	public float collisionRadius = 0.01f;

	// distance between those points on the line
	public float timeBetweenPoints = 0.008f;

	// The physics layers that will cause the line to stop being drawn
	public LayerMask CollidableLayers;

	public Vector3 touchPosition;
	protected Vector3 oldPosition;

	protected Vector3 OriginPoint, OriginRotationVector;


	CircularBuffer.CircularBuffer<Vector3> originHistory = new CircularBuffer.CircularBuffer<Vector3>(3);
	CircularBuffer.CircularBuffer<Vector3> rotationHistory = new CircularBuffer.CircularBuffer<Vector3>(5);

	protected void init()
	{
		lineRenderer = GetComponent<LineRenderer>();
	}

	protected void Update()
	{
		if (isActive)
		{
			DrawPointer();
		}
		else
		{
			List<Vector3> points = new List<Vector3>();
			lineRenderer.positionCount = 0;
		}

	}

	protected void CalculatePointerVectors()
	{
		OriginPoint = GetMeanVector(originHistory.ToArray());
		OriginRotationVector = GetMeanVector(rotationHistory.ToArray());
	}

	private Vector3 GetMeanVector(Vector3[] positions)
	{
		if (positions.Length == 0)
			return Vector3.zero;
		float x = 0f;
		float y = 0f;
		float z = 0f;
		foreach (Vector3 pos in positions)
		{
			x += pos.x;
			y += pos.y;
			z += pos.z;
		}
		return new Vector3(x / positions.Length, y / positions.Length, z / positions.Length);
	}

	private void DrawPointer()
	{
		CalculatePointerVectors();

		if (Vector3.Distance(oldPosition, OriginPoint) < jitterThreshold)
		{
			return;
		}

		lineRenderer.positionCount = (int)numPoints;
		List<Vector3> points = new List<Vector3>();

		transform.position = OriginPoint;

		if (PointingVectorAuto)
		{
			PointingVectorProxy.transform.rotation = Quaternion.LookRotation(OriginRotationVector, Vector3.up);
		}

		Vector3 startingPosition = PointingVectorProxy.transform.position;

		Vector3 startingVelocity = PointingVectorProxy.transform.forward * distanceFactor;

		for (float t = 0; t < numPoints; t += timeBetweenPoints)
		{
			Vector3 newPoint = startingPosition + t * startingVelocity;

			newPoint.y = startingPosition.y + startingVelocity.y * t + (isGravityActive ? Physics.gravity.y / 2f * t * t : 0);

			points.Add(newPoint);

			Collider[] colliders = Physics.OverlapSphere(newPoint, collisionRadius, CollidableLayers);
			if (colliders.Length > 0)
			{
				touchPosition = newPoint;
				lineRenderer.positionCount = points.Count;
				break;
			}

			foreach (Collider collider in colliders)
			{
				if (collider.gameObject.name == "CheckpointPlate")
				{
					collider.gameObject.GetComponent<Renderer>().material.color = Color.green;
				}
			}
		}

		lineRenderer.SetPositions(points.ToArray());

		oldPosition = OriginPoint;
	}

	public void ActivatePointer()
	{
		isActive = true;
	}

	public void DeactivatePointer()
	{
		isActive = false;
	}

	public void SetColors(Color startColor, Color endColor)
	{
		lineRenderer.startColor = startColor;
		lineRenderer.endColor = endColor;
	}
}