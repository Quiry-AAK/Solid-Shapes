using UnityEngine;

namespace _Main.Scripts.Projection
{
    public class ProjectionManager
    {
        private Animator _animator;

        public ProjectionManager(Animator animator)
        {
            _animator = animator;
        }
       
        public void ShowProjection()
        {
            _animator.SetTrigger("ShowProjection");
        }
        
        public void HideProjection()
        {
            _animator.SetTrigger("HideProjection");
        }
        
    }
}