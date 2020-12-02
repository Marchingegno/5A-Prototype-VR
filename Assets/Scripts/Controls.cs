using System.Collections;
using System.Collections.Generic;
using Unity.XR.Oculus;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class Controls : MonoBehaviour
{
    public UnityEngine.XR.InputDevice leftHand;
    public UnityEngine.XR.InputDevice rightHand;

    public Text overlayText;
    
    // Start is called before the first frame update
    void Start()
    {
        
        var inputDevices = new List<UnityEngine.XR.InputDevice>();
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, inputDevices);
        
        foreach (var device in inputDevices)
        {
            Debug.Log(string.Format("Device found with name '{0}' and role '{1}'", device.name, device.role.ToString()));
            overlayText.text += string.Format("Device found with name '{0}' and role '{1}'", device.name,
                device.role.ToString());

        }

        //leftHand = inputDevices[2];
        rightHand = inputDevices[0];
        rightHand.SendHapticImpulse(0, 0.7f, 5f);

    }

    // Update is called once per frame
    void Update()
    {
        rightHand.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
        if (primaryButtonValue)
        {
            Debug.Log("Pressing primary button");
            overlayText.text += "Pressing primary button";
            gameObject.GetComponent<Material>().color = Color.blue;
        }
            

        /*rightHand.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);
        if (triggerValue < 0.5f)
            Debug.Log("Trigger pressed " + triggerValue);
        */
        /*rightHand.TryGetFeatureValue(CommonUsages.grip, out float gripValue);
        if(gripValue)
            Debug.Log("Pressed grip");
        */
        rightHand.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxis);
        /*if(primary2DAxis != Vector2.zero)
        {
            Debug.Log("Pressed 2daxis");
            debugInGameConsole.text += "Pressing 2daxis";
            gameObject.GetComponent<Material>().color = Color.red;
        }*/
    }
    
    
}
