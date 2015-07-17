// =================================================================================================
//
//	Hammerc Library
//	Copyright 2015 hammerc.org All Rights Reserved.
//
//	See LICENSE for full license information.
//
// =================================================================================================

using UnityEngine;

namespace HammercLib.Pool
{
    /// <summary>
    /// 可自动回收对象, 需要添加到 UnityAutoObjectPool 对象池的 GameObject 可以绑定一个继承自该类的对象也可以自行实现.
    /// </summary>
    public class UnityAutoObject : MonoBehaviour, IAutoObject<GameObject>
    {
        protected bool _restore = false;

        public bool restore
        {
            get
            {
                return _restore;
            }
        }

        public virtual void CheckRestore()
        {
        }

        public GameObject GetObject()
        {
            return this.gameObject;
        }

        public virtual void ResetObject()
        {
            _restore = false;
        }
    }
}
