// =================================================================================================
//
//	Hammerc Library
//	Copyright 2015 hammerc.org All Rights Reserved.
//
//	See LICENSE for full license information.
//
// =================================================================================================

using System;
using UnityEngine;
using System.Collections;

namespace HammercLib.Utils
{
    /// <summary>
    /// 协程工具类, 用在非继承 MonoBehaviour 的类中方便的使用协程.
    /// </summary>
    public class CoroutineHelper : IDisposable
    {
        private GameObject _gameObject;
        private MonoBehaviour _monoBehaviour;

        /// <summary>
        /// 构造函数.
        /// </summary>
        public CoroutineHelper()
        {
            _gameObject = new GameObject();
            _gameObject.name = "CoroutineHelper";
            _monoBehaviour = _gameObject.AddComponent<MonoBehaviour>();
        }

        /// <summary>
        /// 设置为加载场景时不销毁本对象.
        /// </summary>
        public void DontDestroyOnLoad()
        {
            GameObject.DontDestroyOnLoad(_gameObject);
        }

        /// <summary>
        /// 开始一个协程.
        /// </summary>
        /// <param name="routine">协程方法.</param>
        /// <returns>协程对象.</returns>
        public Coroutine StartCoroutine(IEnumerator routine)
        {
            return _monoBehaviour.StartCoroutine(routine);
        }

        /// <summary>
        /// 停止一个协程.
        /// </summary>
        /// <param name="routine">协程对象.</param>
        public void StopCoroutine(IEnumerator routine)
        {
            _monoBehaviour.StopCoroutine(routine);
        }

        /// <summary>
        /// 停止一个协程.
        /// </summary>
        /// <param name="routine">协程方法.</param>
        public void StopCoroutine(Coroutine routine)
        {
            _monoBehaviour.StopCoroutine(routine);
        }

        /// <summary>
        /// 停止本类启动的所有协程.
        /// </summary>
        public void StopAllCoroutines()
        {
            _monoBehaviour.StopAllCoroutines();
        }

        /// <summary>
        /// 销毁本对象.
        /// </summary>
        public void Dispose()
        {
            GameObject.Destroy(_gameObject);
        }
    }
}
