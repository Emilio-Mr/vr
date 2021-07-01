using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    public Text curText;
    public GameObject leftController, rightController;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        leftController.transform.localPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);
        rightController.transform.localPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);

        curText.text = "DEBUG TEXT " + "\n" + leftController.transform.localPosition + "\n" + rightController.transform.localPosition;
        Canvas.ForceUpdateCanvases();
    }
}
