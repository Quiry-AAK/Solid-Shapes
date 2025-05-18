using System;
using System.Collections.Generic;
using _Main.Scripts.Projection;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Main.Scripts.InspectionScene
{
    public abstract class InspectionTarget : MonoBehaviour
    {
        [Header("Surface Area")] [SerializeField]
        private List<GameObject> surfaceAreaCanvasGameObjects;

        [SerializeField] private List<GameObject> disableOnProjectionGameObjects;
        [SerializeField] private List<GameObject> notChildObjectsAtSpawn;
        
        [Header("References")] [SerializeField]
        protected Transform tr;
        [SerializeField] protected Animator animator;
        public abstract ProjectionManager ProjectionManager {
            get;
        }

        private void OnEnable()
        {
            foreach (var o in notChildObjectsAtSpawn)
            {
                o.transform.SetParent(null);
            }
        }

        private void OnDisable()
        {
            foreach (var o in notChildObjectsAtSpawn)
            {
                Destroy(o);
            }
        }

        public virtual string GetVolumeString()
        {
            return "V = " + GetVolume().ToString("F1");
        }
        
        public virtual string GetTSAString()
        {
            return "TSA = " + GetTSA().ToString("F1");
        }
        
        protected abstract float GetVolume();
        
        protected abstract float GetTSA();

        public virtual void ShowSurfaceAreas(bool show)
        {
            foreach (var surfaceAreaCanvasGameObject in surfaceAreaCanvasGameObjects)
            {
                surfaceAreaCanvasGameObject.SetActive(show);
            }

            foreach (var disableOnProjectionGameObject in disableOnProjectionGameObjects)
            {
                disableOnProjectionGameObject.SetActive(!show);
            }
        }
        protected abstract void ResizeInspectionTarget(float _);
        protected abstract void RecalculateSurfaceAreas(float _);

        public bool HasProjection()
        {
            return animator != null;
        }
    }
}