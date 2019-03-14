using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomlocatgionizer : MonoBehaviour
{

    public GameObject Prefab;
	public int amountToSpawn = 100;
	public Vector2 Ylines;
	public Vector2 Xlines;
	
    void Start()
    {
		int i;
        for(i = 0; i < amountToSpawn; i++) {
			GameObject tmp = Instantiate(Prefab);
            tmp.transform.position = new Vector3((int)Random.Range(Ylines.x,Ylines.y)+transform.position.x,2,(int)Random.Range(Xlines.x,Xlines.y)+transform.position.z);
		}
    }
}
