using System;
using UnityEngine;

namespace _Main.Scripts.Misc
{
    public class AlwaysLocalScaleOne : MonoBehaviour
    {
        [SerializeField] private Transform parent;

        void LateUpdate()
        {
            Vector3 parentWorldScale = parent.lossyScale;
            
            Vector3 newLocalScale = new Vector3(
                1 / parentWorldScale.x,
                1 / parentWorldScale.y,
                1 / parentWorldScale.z
            );
            
            transform.localScale = newLocalScale;
        }
    }
}