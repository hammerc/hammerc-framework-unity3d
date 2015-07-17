// =================================================================================================
//
//	Hammerc Library
//	Copyright 2015 hammerc.org All Rights Reserved.
//
//	See LICENSE for full license information.
//
// =================================================================================================

using System;
using System.Collections.Generic;

namespace HammercLib.Pool
{
    /// <summary>
    /// 简单的对象池类.
    /// </summary>
    /// <typeparam name="T">存放到对象池的对象.</typeparam>
    public class SimpleObjectPool<T> : IObjectPool<T>
    {
        protected readonly List<T> _pools = new List<T>();
        protected readonly IObjectFactory<T> _factory;

        //最大可以达到的空闲对象数量, 超过该数量回收的对象会被销毁
        protected readonly int _maxIdleCount;
        protected int _activeCount = 0;

        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="factory">对象池工厂对象.</param>
        /// <param name="maxIdleCount">最大可以达到的空闲对象数量.</param>
        public SimpleObjectPool(IObjectFactory<T> factory, int maxIdleCount)
        {
            if(factory == null)
            {
                throw new Exception("工厂对象不能为空！");
            }
            _factory = factory;
            _maxIdleCount = maxIdleCount;
        }

        public int GetActiveCount()
        {
            return _activeCount;
        }

        public int GetIdleCount()
        {
            return _pools.Count;
        }

        public virtual void Restore(T obj)
        {
            if(_pools.Count >= _maxIdleCount)
            {
                _factory.DestroyObject(obj);
            }
            else
            {
                _factory.UnactivateObject(obj);
                _pools.Add(obj);
            }
            _activeCount--;
        }

        public virtual T Take()
        {
            T obj;
            if(_pools.Count == 0)
            {
                obj = _factory.CreateObject(true);
            }
            else
            {
                obj = _pools[0];
                _factory.ActivateObject(obj);
                _pools.RemoveAt(0);
            }
            _activeCount++;
            return obj;
        }

        public virtual void AddObject()
        {
            if(_pools.Count < _maxIdleCount)
            {
                T obj = _factory.CreateObject(false);
                _pools.Add(obj);
            }
        }

        public virtual void Clear()
        {
            foreach(T obj in _pools)
            {
                _factory.DestroyObject(obj);
            }
            _pools.Clear();
        }
    }
}
