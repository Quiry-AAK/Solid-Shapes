using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Main.Scripts.InspectionScene
{
    public abstract class SurfaceAreaManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI resultTxt;

        public void UpdateResultTxt()
        {
            resultTxt.text = "A = " + GetSurfaceArea();
        }
        
        protected abstract int GetSurfaceArea();
    }
}