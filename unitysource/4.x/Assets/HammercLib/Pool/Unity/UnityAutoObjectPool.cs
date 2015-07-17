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
    /// 可作为脚本组件绑定到 GameObject 上的可自动回收的对象池对象.
    /// </summary>
    /// <typeparam name="T">继承自 MonoBehaviour 同时实现 IAutoObject&lt;GameObject&gt; 的具体脚本类型.</typeparam>
    public class UnityAutoObjectPool<T> : MonoBehaviour, IAutoObjectPool<GameObject> where T : Component, IAutoObject<GameObject>
    {
        /// <summary>
        /// 对象池管理的对象类型.
        /// </summary>
        public GameObject source;

        /// <summary>
        /// 对象池中最大允许的空闲对象.
        /// </summary>
        public int maxIdleCount = 10;

        protected IAutoObjectPool<GameObject> _pool;

        void Awake()
        {
            _pool = new AutoObjectPool<GameObject>(new GameObjectFactory<T>(source), maxIdleCount);
        }

        public int GetActiveCount()
        {
            return _pool.GetActiveCount();
        }

        public int GetIdleCount()
        {
            return _pool.GetIdleCount();
        }

        void Update()
        {
            this.CheckRestore();
        }

        public virtual void Restore(IAutoObject<GameObject> obj)
        {
            _pool.Restore(obj);
        }

        public virtual IAutoObject<GameObject> Take()
        {
            return _pool.Take();
        }

        public virtual void AddObject()
        {
            _pool.AddObject();
        }

        public virtual void CheckRestore()
        {
            _pool.CheckRestore();
        }

        public virtual void Clear()
        {
            _pool.Clear();
        }
    }
}
