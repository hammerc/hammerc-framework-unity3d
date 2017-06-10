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
using System.Reflection;

namespace HammercLib.Utils
{
    /// <summary>
    /// 可存储多种类型的对象池类.
    /// 不同于 HammercLib.Pool 下对象池的设计, 该对象池可以支持任意类型对象的存取功能.
    /// 同时要求存储的对象必须有一无参构造函数, 其他无要求, 对于简单的需求上使用更方便.
    /// </summary>
    public sealed class MultiTypePool
    {
        private Dictionary<Type, List<object>> _typeMap;

        /// <summary>
        /// 构造函数.
        /// </summary>
        public MultiTypePool()
        {
            _typeMap = new Dictionary<Type, List<object>>();
        }

        /// <summary>
        /// 获取对象池中指定类型空闲的对象数量.
        /// </summary>
        /// <typeparam name="T">类型.</typeparam>
        /// <returns>对象池中指定类型空闲的对象数量.</returns>
        public int GetIdleCount<T>()
        {
            Type type = typeof(T);
            List<object> list = _typeMap[type];
            if(list != null)
            {
                return list.Count;
            }
            return 0;
        }

        /// <summary>
        /// 回收一个指定类型的对象到对象池.
        /// </summary>
        /// <typeparam name="T">类型.</typeparam>
        /// <param name="obj">回收的对象.</param>
        public void Restore<T>(T obj)
        {
            Type type = typeof(T);
            if(!_typeMap.ContainsKey(type))
            {
                _typeMap[type] = new List<object>();
            }
            List<object> list = _typeMap[type];
            list.Add(obj);
        }

        /// <summary>
        /// 从对象池中取出一个指定类型的对象.
        /// </summary>
        /// <typeparam name="T">类型.</typeparam>
        /// <returns>对象池中取出的对象.</returns>
        public T Take<T>()
        {
            Type type = typeof(T);
            if(!_typeMap.ContainsKey(type))
            {
                _typeMap[type] = new List<object>();
            }
            List<object> list = _typeMap[type];
            if(list.Count == 0)
            {
                ConstructorInfo constructorInfo = type.GetConstructor(Type.EmptyTypes);
                return (T) constructorInfo.Invoke(null);
            }
            T obj = (T) list[0];
            list.RemoveAt(0);
            return obj;
        }

        /// <summary>
        /// 清除指定类型的数据.
        /// </summary>
        /// <typeparam name="T">类型.</typeparam>
        public void Clear<T>()
        {
            Type type = typeof(T);
            if(_typeMap.ContainsKey(type))
            {
                _typeMap.Remove(type);
            }
        }

        /// <summary>
        /// 清除所有数据.
        /// </summary>
        public void ClearAll()
        {
            _typeMap.Clear();
        }
    }
}
