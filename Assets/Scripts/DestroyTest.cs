using UnityEngine;
using System.Collections;

public class DestroyTest : MonoBehaviour {
    public Material indicatorMaterial;

    public int NextEventIn;
    public int EventTimer;

    public bool inPlace;

    private bool ableToBeHit;

    private Material originalMaterial;
    private int nextEventIn;
    private int eventTimer;
	// Use this for initialization
	void Start () {
        inPlace = false;
        ableToBeHit = false;

        nextEventIn = NextEventIn;
        eventTimer = EventTimer;

        originalMaterial = gameObject.GetComponent<Renderer>().material;
    }
	
	// Update is called once per frame
	void Update () {
        if (inPlace)
        {
            nextEventIn--;
            if (nextEventIn < 0)
            {

                eventTimer--;
                if (eventTimer > 0)
                {
                    ableToBeHit = true;

                }
                else
                {
                    gameObject.GetComponent<Renderer>().material = originalMaterial;
                    ableToBeHit = false;
                    nextEventIn = NextEventIn;
                    eventTimer = EventTimer;
                    if (transform.parent.name.ToLower().Contains("black"))
                    {
                        SettingsData.BlackKarma--;
                    }
                    else
                    {
                        SettingsData.WhiteKarma--;
                    }
                    transform.parent.GetComponent<PositionCharacter>();
                }
            }
        }
	}

    public void OnMouseDown()
    {
        if (ableToBeHit)
        {            
            gameObject.GetComponentInParent<PositionCharacter>().goToTrain = true;
        }
    }
}
