using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ColorChanger : MonoBehaviour
{
    [SerializeField]
    public Material PurpleMaterial = null;

    [SerializeField]
    public Material PinkMaterial = null;

    private MeshRenderer meshRenderer = null;

    private XRGrabInteractable grabInteractable = null;

    //private void Awake()
    //{
    //    meshRenderer = GetComponent<MeshRenderer>();
    //    grabInteractable = GetComponent<XRGrabInteractable>();

    //    grabInteractable.onActivate.AddListener(setPink);
    //    grabInteractable.onDeactivate.AddListener(setPurple);
    //}

    //private void OnDestroy()
    //{

    //    grabInteractable.onActivate.RemoveListener(SetPink);
    //    grabInteractable.onDeactivate.RemoveListener(setPurple);
    //}

    private void SetPink()
    {
        meshRenderer.material = PinkMaterial;
    }

    private void SetPurple()
    {
        meshRenderer.material = PurpleMaterial;
    }
}
