using System;
using TMPro;
using UnityEngine;

namespace _Main.Scripts.Misc
{
    public class DisableTextMeshProRaycastUtil : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<TextMeshProUGUI>().raycastTarget = false;
        }
        
    }
}