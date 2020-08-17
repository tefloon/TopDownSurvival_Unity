using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PociskWybuch : MonoBehaviour
{
	[SerializeField] private GameObject wybuchPrefab;

	private void OnTriggerEnter2D(Collider2D other)
	{
		var go = Instantiate(wybuchPrefab, transform.position, Quaternion.identity);
		Destroy(go, 0.33f);
		Destroy(gameObject);
	}
}
