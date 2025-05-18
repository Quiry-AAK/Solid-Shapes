using _Main.Scripts.Projection;
using UnityEngine;
using UnityEngine.UI;

namespace _Main.Scripts.InspectionScene
{
    public class ToggleProjectionManager
    {
        private Image toggleProjectionBtnIcon;
        private Sprite showSprite, hideSprite;
        private bool toggleProjectionVal;

        public ToggleProjectionManager(Image toggleProjectionBtnIcon, Sprite showSprite, Sprite hideSprite)
        {
            this.toggleProjectionBtnIcon = toggleProjectionBtnIcon;
            this.showSprite = showSprite;
            this.hideSprite = hideSprite;
            
            toggleProjectionVal = false;
        }

        public void ToggleProjection(InspectionTarget inspectionTarget)
        {
            toggleProjectionVal = !toggleProjectionVal;
            inspectionTarget.ShowSurfaceAreas(toggleProjectionVal);
            
            if (toggleProjectionVal)
            {
                inspectionTarget.ProjectionManager.ShowProjection();
                toggleProjectionBtnIcon.sprite = hideSprite;
            }
            else
            {
                inspectionTarget.ProjectionManager.HideProjection();
                toggleProjectionBtnIcon.sprite = showSprite;
            }
        }

        public void ResetProjection()
        {
            toggleProjectionVal = false;
            toggleProjectionBtnIcon.sprite = showSprite;
        }
    }
}