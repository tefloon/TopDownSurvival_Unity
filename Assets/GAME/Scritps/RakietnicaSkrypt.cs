using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RakietnicaSkrypt : BronSkrypt
{
	[SerializeField] private Transform przechowalniaPociskow;

	[SerializeField] private GameObject pociskPrefab;
	[SerializeField] private Transform miejsceStrzelania;
	[SerializeField] private float silaStrzalu;

	private float nastepnyStrzal = 1f;

	public override void Strzel()
	{
		if (Time.time >= nastepnyStrzal)
		{
			var go = Instantiate(pociskPrefab, miejsceStrzelania.position, miejsceStrzelania.rotation, przechowalniaPociskow);
			go.GetComponent<Rigidbody2D>().AddForce(miejsceStrzelania.right * silaStrzalu, ForceMode2D.Impulse);

			nastepnyStrzal += OdstepStrzalu;
		}
	}
}
