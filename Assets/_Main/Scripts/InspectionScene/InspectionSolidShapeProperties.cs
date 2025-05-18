using UnityEngine;

namespace _Main.Scripts.InspectionScene
{
    [CreateAssetMenu(fileName = "NewInspectionSolidShapeProperty", menuName = "SolidShapes/InspectionProperty", order = 0)]
    public class InspectionSolidShapeProperties : ScriptableObject
    {
        [SerializeField] private string shapeName;
        [SerializeField] private GameObject inspectionSolidShapePrefab;
        [SerializeField] private Sprite volumeFormulaSprite, tsaFormulaSprite;

        public string ShapeName => shapeName;

        public Sprite TSAFormulaSprite => tsaFormulaSprite;

        public Sprite VolumeFormulaSprite => volumeFormulaSprite;

        public GameObject InspectionSolidShapePrefab => inspectionSolidShapePrefab;
    }
}