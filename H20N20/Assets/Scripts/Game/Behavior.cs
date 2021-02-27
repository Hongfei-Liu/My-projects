using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behavior : MonoBehaviour
{
	public Transform BulletUp;
	public Transform SpeedUp;
	public Transform HpUp;
	public Transform SpeedDown;
	public Transform BulletDown;

	private int whichPowerUp;

	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		whichPowerUp = Random.Range(1, 5);

		if (whichPowerUp == 1)
		{
			Instantiate(BulletUp, transform.position, BulletUp.rotation);
		}

		if (whichPowerUp == 2)
		{
			Instantiate(SpeedUp, transform.position, SpeedUp.rotation);
		}
		if (whichPowerUp == 3)
		{
			Instantiate(HpUp, transform.position, HpUp.rotation);
		}
		if (whichPowerUp == 4)
		{
			Instantiate(SpeedDown, transform.position, SpeedDown.rotation);
		}
		if (whichPowerUp == 5)
		{
			Instantiate(BulletDown, transform.position, BulletDown.rotation);
		}
	}
}
