using System;
using UnityEngine;


namespace UnityStandardAssets.Utility
{
    public class FollowTarget : MonoBehaviour
    {   

        public float maxX,minX,maxZ,minZ;
        public Transform target;
        public Vector3 offset = new Vector3(0f, 7.5f, 0f);

        private void LateUpdate()
        {
            transform.position = new Vector3(Mathf.Clamp(target.position.x,minX,maxX), target.position.y , Mathf.Clamp(target.position.z,minZ,maxZ));
            
        }
    }
}
