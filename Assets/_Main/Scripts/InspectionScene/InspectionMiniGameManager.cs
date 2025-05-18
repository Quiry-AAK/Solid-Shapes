using System;
using System.Collections.Generic;
using _Main.Scripts.Misc;
using _Main.Scripts.MobileInput;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Main.Scripts.InspectionScene
{
    public class InspectionMiniGameManager : MonoSingleton<InspectionMiniGameManager>
    {
        [Header("References")] [SerializeField]
        private List<GameObject> firstTimeUpdateTargetEnableObjects;

        [Header("Toggle Projection")]
        [SerializeField] private Button toggleProjectionBtn;
        [SerializeField] private Image toggleProjectionBtnIconImage;
        [SerializeField] private Sprite showProjectionSprite, hideProjectionSprite;

        [Header("Target")] [SerializeField] private TextMeshProUGUI titleTxt;

        [SerializeField] private Image volumeFormulaImg;
        [SerializeField] private TextMeshProUGUI volumeTxt;
        [SerializeField] private Image tsaFormulaImg;
        [SerializeField] private TextMeshProUGUI tsaTxt;
        [SerializeField] private Transform targetSocketTr;

        [Header("Colors")] [SerializeField] private Color selectedColor;
        [SerializeField] private Color defaultColor;

        [Header("Controller")] [SerializeField]
        private MobileInputHandler inputHandler;

        [SerializeField] private Transform cameraTr;
        [SerializeField] private float rotationSpeed, zoomSpeed, minZoom, maxZoom;


        private InspectionTargetStruct _currentInspectionTarget;
        private DragInspectController _dragInspectController;
        private ToggleProjectionManager _toggleProjectionManager;


        private void Start()
        {
            _dragInspectController =
                new DragInspectController(inputHandler, cameraTr, targetSocketTr, rotationSpeed, zoomSpeed, minZoom,
                    maxZoom);
            _toggleProjectionManager = new ToggleProjectionManager(toggleProjectionBtnIconImage, showProjectionSprite,
                hideProjectionSprite);
            toggleProjectionBtn.onClick.AddListener(ToggleProjection);
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            _dragInspectController =
                new DragInspectController(inputHandler, cameraTr, targetSocketTr, rotationSpeed, zoomSpeed, minZoom,
                    maxZoom);
        }
#endif

        private void Update()
        {
            if (IsThereAnyTarget())
            {
                _dragInspectController.HandleRotation();
                _dragInspectController.HandleZoom();
                volumeTxt.text = _currentInspectionTarget.InspectionTarget.GetVolumeString();
                tsaTxt.text = _currentInspectionTarget.InspectionTarget.GetTSAString();
            }
        }

        public void UpdateTarget(InspectionTargetStruct targetStruct)
        {
            if (IsThereAnyTarget())
            {
                _currentInspectionTarget.TargetBtnImage.color = defaultColor;
            }

            else
            {
                FirstTimeSettingTargetSettings();
            }

            _currentInspectionTarget = targetStruct;
            _currentInspectionTarget.TargetBtnImage.color = selectedColor;
            volumeFormulaImg.sprite = _currentInspectionTarget.TargetSolidShapeProperty.VolumeFormulaSprite;
            tsaFormulaImg.sprite = _currentInspectionTarget.TargetSolidShapeProperty.TSAFormulaSprite;

            titleTxt.text = targetStruct.TargetSolidShapeProperty.ShapeName;

            if (targetSocketTr.childCount > 0)
                Destroy(targetSocketTr.GetChild(0).gameObject);
            _currentInspectionTarget.InGameInspectionShapeGameObject.transform.SetParent(targetSocketTr);
            _currentInspectionTarget.InGameInspectionShapeGameObject.transform.localPosition = Vector3.zero;
            
            _toggleProjectionManager.ResetProjection();
            toggleProjectionBtn.gameObject.SetActive(_currentInspectionTarget.InspectionTarget.HasProjection());
        }

        private bool IsThereAnyTarget()
        {
            return !_currentInspectionTarget.Equals(default(InspectionTargetStruct));
        }

        private void FirstTimeSettingTargetSettings()
        {
            foreach (var enableObject in firstTimeUpdateTargetEnableObjects)
            {
                enableObject.SetActive(true);
            }
        }

        private void ToggleProjection()
        {
            if (IsThereAnyTarget())
            {
                _toggleProjectionManager.ToggleProjection(_currentInspectionTarget.InspectionTarget);
            }
        }
    }
}