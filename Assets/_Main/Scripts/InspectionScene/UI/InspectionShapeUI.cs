using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Main.Scripts.InspectionScene.UI
{
    public class InspectionShapeUI : MonoBehaviour
    {
        [SerializeField] private InspectionSolidShapeProperties mySolidShapeProperties;
        [SerializeField] private Image btnImage;
        
        public void OnButtonClick()
        {
            InspectionMiniGameManager.Instance.UpdateTarget(new InspectionTargetStruct(mySolidShapeProperties, btnImage));
        }
    }
}