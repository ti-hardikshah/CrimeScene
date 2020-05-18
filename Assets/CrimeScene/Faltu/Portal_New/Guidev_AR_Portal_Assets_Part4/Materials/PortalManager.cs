using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PortalManager : MonoBehaviour
{
    public GameObject MainCamera;

    public GameObject Sponza;

    public Material[] SponzaMaterials;
    public Material PortalPlaneMaterial;

    void Start()
    {
        SponzaMaterials = Sponza.GetComponent<Renderer>().sharedMaterials;
        PortalPlaneMaterial = Sponza.GetComponent<Renderer>().sharedMaterial;
    }

    private void OnTriggerStay(Collider other)
    {
        Vector3 camPositionInPortalSpace = transform.InverseTransformPoint(MainCamera.transform.position);

        if (camPositionInPortalSpace.y <= 0.0f)
        {
            // Disable stencil test
            for (int i = 0; i < SponzaMaterials.Length; i++)
            {
                SponzaMaterials[i].SetInt("_StencilComp", (int)CompareFunction.NotEqual);
            }

            PortalPlaneMaterial.SetInt("_CullMode", (int)CullMode.Front);
        }
        else if (camPositionInPortalSpace.y < 0.5f)
        {
            // Disable stencil test
            for (int i = 0; i < SponzaMaterials.Length; i++)
            {
                SponzaMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Always);
            }

            PortalPlaneMaterial.SetInt("_CullMode", (int)CullMode.Off);
        }
        else
        {
            // Enable stencil test
            for (int i = 0; i < SponzaMaterials.Length; i++)
            {
                SponzaMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Equal);
            }

            PortalPlaneMaterial.SetInt("_CullMode", (int)CullMode.Back);
        }
    }
}