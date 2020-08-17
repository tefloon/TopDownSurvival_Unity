using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GraczRuch : MonoBehaviour
{
	[SerializeField] private float predkosc = 5f;

	private Rigidbody2D rb;

	private Vector2 ruch;
	private Vector2 pozycjaMyszy;

	void Start()
    {
	    rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
	    ruch.x = Input.GetAxisRaw("Horizontal");
	    ruch.y = Input.GetAxisRaw("Vertical");

	    pozycjaMyszy = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
	    rb.MovePosition(rb.position + predkosc * Time.fixedDeltaTime * ruch);

	    Vector2 kierunek = pozycjaMyszy - rb.position;

	    float kat = Mathf.Atan2(kierunek.y, kierunek.x) * Mathf.Rad2Deg - 90f;
		rb.rotation = kat;

    }
}
