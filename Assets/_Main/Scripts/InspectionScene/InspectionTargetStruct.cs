using UnityEngine;
using UnityEngine.UI;

namespace _Main.Scripts.InspectionScene
{
    public struct InspectionTargetStruct
    {
        private InspectionSolidShapeProperties _targetSolidShapeProperty;
        private InspectionTarget _inspectionTarget;
        private Image _targetBtnImage;
        private GameObject _inGameInspectionShapeGameObject;

        public InspectionTargetStruct(InspectionSolidShapeProperties targetSolidShapeProperty, Image targetBtnImage)
        {
            _targetSolidShapeProperty = targetSolidShapeProperty;
            _targetBtnImage = targetBtnImage;
            _inGameInspectionShapeGameObject = Object.Instantiate(_targetSolidShapeProperty.InspectionSolidShapePrefab);
            _inspectionTarget = _inGameInspectionShapeGameObject.GetComponent<InspectionTarget>();
        }

        public InspectionSolidShapeProperties TargetSolidShapeProperty => _targetSolidShapeProperty;
        public Image TargetBtnImage => _targetBtnImage;

        public InspectionTarget InspectionTarget => _inspectionTarget;

        public GameObject InGameInspectionShapeGameObject => _inGameInspectionShapeGameObject;
    }
}