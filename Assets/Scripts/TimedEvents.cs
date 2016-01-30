using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimedEvents : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GameObject.Find("BlackKarma").GetComponent<Text>().text= SettingsData.BlackKarma.ToString();
        GameObject.Find("WhiteKarma").GetComponent<Text>().text = SettingsData.WhiteKarma.ToString();
        if (SettingsData.BlackKarma <= 0)
        {
            InitiateEnd(true);
        }
        if (SettingsData.WhiteKarma <= 0)
        {
            InitiateEnd(false);
        }
    }
    
    void InitiateEnd(bool isBlack)
    {
        //end initiation here
    }
}
