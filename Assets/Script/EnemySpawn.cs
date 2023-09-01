using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

		public float jeda = 0.8f;
		float timer;
		public GameObject[] Enemy;
		
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > jeda)
		{
			int random = Random.Range(0, Enemy.Length);
			Instantiate(Enemy[random], transform.position, transform.rotation);
			timer = 0;
		}
	}
}
