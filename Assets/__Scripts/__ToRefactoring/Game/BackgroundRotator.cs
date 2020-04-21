using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRotator : MonoBehaviour
{
    Transform tr;
	public float deltaAngle;

	void Awake()
	{
		tr = GetComponent<Transform>();
	}

	float angle;

	void Update()
	{
		tr.Rotate(0, 0, -deltaAngle, Space.Self);
	}
}
