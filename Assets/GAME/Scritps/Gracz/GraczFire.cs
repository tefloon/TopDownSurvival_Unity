using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraczFire : MonoBehaviour
{
	[SerializeField] private BronSkrypt skryptBroni;

    // Update is called once per frame
    void Update()
    {
	    if (Input.GetButton("Fire1"))
	    {
			skryptBroni.Strzel();
		}
    }
}
