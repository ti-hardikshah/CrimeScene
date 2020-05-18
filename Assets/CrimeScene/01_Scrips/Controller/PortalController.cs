using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


    public class PortalController : MonoBehaviour
    {


        public MeshRenderer MeshRenderer;
     //   public UnityARVideo unityARvideo;

        private bool isInSide = false;
        private bool isOutSide = true;


       private Camera cam;



        private void Awake()
        {
            cam = Camera.main;
        }

        // Start is called before the first frame update
        void Start()
        {
            OutSidedPortal();
        }

        // Update is called once per frame
        void Update()
        {

        }


        private void OnTriggerStay(Collider col)
        {
            Vector3 playerPos = cam.transform.position + cam.transform.forward * (cam.nearClipPlane * 4);
            Vector3 pos = transform.InverseTransformPoint(playerPos);

            if (pos.z <= 0)
            {

                if (isOutSide)
                {
                    isOutSide = false;
                    isInSide = true;
                    InSidePortal();
                }
            }
            else {

                if (isInSide)
                {
                    isInSide = false;
                    isOutSide = true;
                    OutSidedPortal();
                }
            }
        }


        void OutSidedPortal() {

        StartCoroutine(DelayChnageMaterial(3));
        }

        void InSidePortal() {

        StartCoroutine(DelayChnageMaterial(6));
    }


        IEnumerator DelayChnageMaterial(int chnage)
        {

           // unityARvideo.shouldRender = false;
            yield return new WaitForEndOfFrame();
            MeshRenderer.enabled = false;

            SetMaterials(chnage);
            yield return new WaitForEndOfFrame();
            MeshRenderer.enabled = true;
          //  unityARvideo.shouldRender = true;

        }


        void SetMaterials(int fullRender)
        {
            //var stencilTest = fullRender ? CompareFunction.NotEqual : CompareFunction.Equal;
            Shader.SetGlobalInt("_StencilTest", fullRender);
        }

    }
