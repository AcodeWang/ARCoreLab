using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PortalController : MonoBehaviour {

    public Material[] materials;

    bool wasInFront = true;

    bool isInARWorld = false;
    bool hasCollided = false;


	// Use this for initialization
	void Start () {
        SetStencilMaterials(true);
	}

    void SetStencilMaterials(bool fullRender){

        var stencilTest = fullRender ? CompareFunction.Equal : CompareFunction.NotEqual;
        foreach (var mat in materials){
            mat.SetInt("_StencilTest", (int) stencilTest);
        }
    }

    bool GetIsInFront(){

        Vector3 camWorldPosition = Camera.main.transform.position + Camera.main.transform.forward * Camera.main.nearClipPlane;

        Vector3 cameraRelativePosition = transform.InverseTransformPoint(camWorldPosition);

        return cameraRelativePosition.z <= 0;
       
    }

    private void OnTriggerEnter(Collider other)
    {
        wasInFront = GetIsInFront();
        hasCollided = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.name != Camera.main.name){
            return;
        }


    }

    private void OnTriggerExit(Collider other)
    {
        hasCollided = false;
    }

    // Update is called once per frame
    void Update () {

        if(hasCollided){

            if ((wasInFront && !GetIsInFront()) || (!wasInFront && GetIsInFront()))
            {
                isInARWorld = !isInARWorld;
                SetStencilMaterials(!isInARWorld);
            }

            wasInFront = GetIsInFront();
          
        }
	}

    private void OnDestroy()
    {
        SetStencilMaterials(false);
    }
}
