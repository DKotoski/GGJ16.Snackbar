using UnityEngine;
using System.Collections;

public class SummonCharacter : MonoBehaviour {
    public GameObject SummonPrefab;
    public Vector3 Location;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Summon(string name)
    {
        var Instance = (GameObject)Instantiate(SummonPrefab);
        Instance.transform.position = Location;
        Instance.name = name;
        Instance.transform.GetChild(0).name = Instance.transform.GetChild(0).name + " " + name;
    }
}
