// -------------------------------------
//  Domain		: Avariceonline.com
//  Author		: Nicholas Ventimiglia
//  Product		: Unity3d Foundation
//  Published		: 2015
//  -------------------------------------

using Foundation.Databinding.View;
using UnityEngine;

namespace Foundation.Databinding.Components
{
    /// <summary>
    /// String --> Animation.PlayAnimation
    /// </summary>
    [AddComponentMenu("Foundation/Databinding/AnimationBinder")]
    public class AnimationBinder : BindingBase
    {
        protected Animation Anim;
        
        [HideInInspector]
        public BindingInfo AnimationBindingInfo = new BindingInfo
        {
            BindingName = "AnimationClip",
            Filters = BindingFilter.Properties,
            FilterTypes = new[] { typeof(string) }
        };
        
        void Awake()
        {
            Init();
        }

        public override void Init()
        {
            Anim = GetComponent<Animation>();
            AnimationBindingInfo.Action = UpdatePosition;
        }

        private void UpdatePosition(object arg)
        {
            var s = (string) arg;
            if (string.IsNullOrEmpty(s))
            {
                Anim.Stop();
            }
            else
            {
                Anim.Play(s);
            }
        }
    }
}