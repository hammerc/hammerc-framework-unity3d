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
        /// 是否自动初始化对象池.
        /// </summary>
        public bool autoInit = true;

        /// <summary>
        /// 指定该对象池创建的对象是否切换场景时不被销毁.
        /// 如果不销毁则需要手动调用 Clear 方法进行效果.
        /// </summary>
        public bool dontDestroyOnLoad = false;

        /// <summary>
        /// 对象池中最大允许的空闲对象.
        /// </summary>
        public int maxIdleCount = 10;

        protected IAutoObjectPool<GameObject> _pool;

        void Awake()
        {
            if(_pool == null && autoInit)
            {
                _pool = new AutoObjectPool<GameObject>(new GameObjectFactory<T>(source, dontDestroyOnLoad, this.gameObject), maxIdleCount);
            }
        }

        /// <summary>
        /// 初始化对象池, 在取消自动初始化时需要调用该方法进行初始化.
        /// </summary>
        public void Init()
        {
            if(_pool == null)
            {
                _pool = new AutoObjectPool<GameObject>(new GameObjectFactory<T>(source, dontDestroyOnLoad, this.gameObject), maxIdleCount);
            }
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
