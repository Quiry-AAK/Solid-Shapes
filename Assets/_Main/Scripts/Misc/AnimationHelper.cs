using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace _Main.Scripts.Misc
{
    public class AnimationHelper : MonoBehaviour
    {
        [SerializeField] private List<GameObject> gos;
        [SerializeField] private Vector3 interval, unfoldInterval;

        [ContextMenu("Make Cone")]
        public void MakeCone()
        {
            for (var i = 0; i < gos.Count; i++)
            {
                if (i == 0)
                    continue;
                gos[i].transform.localRotation = Quaternion.Euler(interval * i);
            }
        }

        [ContextMenu("Unfold Cone")]
        public void UnfoldCone()
        {
            for (var i = 0; i < gos.Count; i++)
            {
                if (i == 0)
                    continue;

                if (i < gos.Count / 2)
                {
                    gos[i].transform.localRotation =
                        Quaternion.Euler(unfoldInterval * i + gos[0].transform.localEulerAngles);
                }
                else
                {
                    gos[i].transform.localRotation =
                        Quaternion.Euler(-unfoldInterval * (i - gos.Count / 2) + gos[0].transform.localEulerAngles);
                }
            }
        }
        
        [ContextMenu("Unfold Cylinder")]
        public void UnfoldCylinder()
        {
            for (var i = 0; i < gos.Count; i++)
            {
                gos[i].transform.localRotation =
                    Quaternion.Euler(unfoldInterval * (i + 1));
            }
        }
    }
}