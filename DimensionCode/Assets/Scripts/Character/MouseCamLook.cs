using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamLook : MonoBehaviour
{

    [SerializeField]
    public float sensitivity = 1.2f;
    [SerializeField]
    public float smoothing = 1.0f;
    // the chacter is the capsule
    public GameObject character;
    // get the incremental value of mouse moving
    private Vector2 mouseLook;
    // smooth the mouse moving
    private Vector2 smoothV;

    private float initialCharacterAngle;
    private float waitBuffer = 2f;

    // Use this for initialization
    void Start()
    {
        character = this.transform.parent.gameObject;
        initialCharacterAngle = character.transform.eulerAngles.y;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        waitBuffer -= Time.deltaTime;

        if (waitBuffer < 0f)
        {
            // md is mosue delta
            var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
            md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
            // the interpolated float result between the two float values
            smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
            smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
            // incrementally add to the camera look
            mouseLook += smoothV;

            mouseLook.y = Mathf.Clamp(mouseLook.y, -50f, 50f);
            // vector3.right means the x-axis
            transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
            character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x+initialCharacterAngle, character.transform.up);
        }
    }
}