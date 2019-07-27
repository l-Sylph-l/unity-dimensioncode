using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallLiftLvl3 : MonoBehaviour
{
    public GetSmallLiftLvl3Button liftButtonUp;
    public GetSmallLiftLvl3Button liftButtonDown;
    public GameObject liftPlatform;
    public CharacterController player;
    public GameObject liftCollider;  

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ButtonTriggered();
    }

    public void ButtonTriggered()
    {
        Vector3 start = new Vector3(-1.16f, -7.26f, -1.33f);
        Vector3 target = new Vector3(-1.16f, -2.76f, -1.33f);

        if (liftButtonUp.buttonClick)
        {
            float step = 1f * Time.deltaTime;
            liftPlatform.transform.localPosition = Vector3.MoveTowards(liftPlatform.transform.localPosition, target, step);

            liftButtonDown.buttonClick = false;
        }

        if ((liftButtonDown.buttonClick) || (player.GetCurrentCollider().name != liftCollider.name))
        {
            float step = 1f * Time.deltaTime;
            liftPlatform.transform.localPosition = Vector3.MoveTowards(liftPlatform.transform.localPosition, start, step);

            liftButtonUp.buttonClick = false;
        }
    }
}
