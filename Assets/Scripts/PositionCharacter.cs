using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class PositionCharacter : MonoBehaviour {
    Animator anim;

    public float MoveSpeed;
    public bool allowMovement;
    public bool isBlack;

    public bool goToTrain;

    private int mod;
    private Position pos;
    private float moveSpeed;

    private int mistakenPrayers;

    private int turnHash = Animator.StringToHash("Base Layer.turn_left");
	// Use this for initialization
	void Start () {
        mod = (isBlack) ? 1 : -1;
        moveSpeed = Random.Range(MoveSpeed - 0.5f, MoveSpeed + 0.5f);
        mistakenPrayers = 3;

        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (allowMovement)
        {
            if (pos == null)
            {
                GetFreeSpace();
            }

            if (transform.position.x >= pos.Location.x && isBlack)
            {
                    allowMovement = false;
                var script = gameObject.GetComponentInChildren<DestroyTest>();
                if (script)
                {
                    script.inPlace = true;
                }
            }
            if (transform.position.x <= pos.Location.x && !isBlack)
            {
                allowMovement = false;
                anim.SetTrigger(turnHash);
                var script = gameObject.GetComponentInChildren<DestroyTest>();
                if (script)
                {
                    script.inPlace = true;
                }
            }
            transform.Translate(0, 0,  moveSpeed * Time.deltaTime);
        }
        if (goToTrain)
        {
            SettingsData.Locations[pos.ID].isAvailable = true;
            transform.Translate(0, 0, -0.5f * moveSpeed * pos.Location.z * Time.deltaTime);
            if (transform.position.z >= pos.Location.z + 2 && isBlack)
            {
                GameObject.Find("Summoner" + isBlack.ToString()).GetComponent<SummonCharacter>().Summon(gameObject.name);

                Destroy(gameObject);
            }
            if (transform.position.z <= pos.Location.z - 2 && !isBlack)
            {
                GameObject.Find("Summoner" + isBlack.ToString()).GetComponent<SummonCharacter>().Summon(gameObject.name);

                Destroy(gameObject);
            }

        }
    }

    public void GetFreeSpace()
    {
        var freeSpace = SettingsData.Locations.Where(x => x.isBlack == isBlack && x.isAvailable).ToList();
        if (freeSpace.Count == 0)
        {
            pos = null; 
            return;
        }
        var rand = Random.Range(0, freeSpace.Count);
        pos = freeSpace[rand];

        SettingsData.Locations[pos.ID].isAvailable = false;
        SettingsData.Locations[pos.ID].TakenBy = gameObject.name;
    }
}
