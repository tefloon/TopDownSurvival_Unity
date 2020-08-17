using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrzeciwnikRuch : MonoBehaviour
{
	[SerializeField] float odlegloscZatrzymania;
	[SerializeField] float predkoscRuchu;
	[SerializeField] float odlegloscWykrywania;

	private Rigidbody2D rb;
	private Collider2D[] znalezioneCollidery;
	private Transform cel;
	

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		Namierz();
	}

	private void FixedUpdate()
	{
		Idz();
	}

	void Namierz()
	{
		znalezioneCollidery = Physics2D.OverlapCircleAll(rb.position, odlegloscWykrywania);

		foreach (var collider in znalezioneCollidery)
		{
			if (collider.gameObject.CompareTag("Player"))
			{
				cel = collider.transform;
				//print("Wykryłem");
				return;
			}
		}

		//print("Nie wykryłem");

		cel = null;
	}

	void Idz()
	{
		if (!cel)
		{
			//print("Wychodzę! Nie ma celu");
			return;
		}

		if (Vector2.Distance(transform.position, cel.position) <= odlegloscZatrzymania)
		{
			//print("Wychodzę! Jestem za blisko");
			return;
		}

		//print("Idę");

		Vector2 kierunek = (cel.position - transform.position).normalized;
		
		rb.SetRotation(Mathf.Atan2(kierunek.y, kierunek.x) * Mathf.Rad2Deg - 90f);
		rb.MovePosition((Vector2)transform.position + predkoscRuchu * Time.deltaTime * kierunek.normalized);
	}
}
