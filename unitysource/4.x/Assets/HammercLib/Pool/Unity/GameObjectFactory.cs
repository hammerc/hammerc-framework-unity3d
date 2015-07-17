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

namespace HammercLib.Pool
{
    /// <summary>
    /// 游戏对象工厂类.
    /// </summary>
    /// <typeparam name="T">继承自 MonoBehaviour 同时实现 IAutoObject&lt;GameObject&gt; 的具体脚本类型.</typeparam>
    public class GameObjectFactory<T> : IObjectFactory<IAutoObject<GameObject>> where T : Component, IAutoObject<GameObject>
    {
        private GameObject _gameObject;

        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="gameObject">创建的对象类型.</param>
        public GameObjectFactory(GameObject gameObject)
        {
            _gameObject = gameObject;
        }

        public IAutoObject<GameObject> CreateObject(bool doActive)
        {
            GameObject go = GameObject.Instantiate(_gameObject) as GameObject;
            //取出预先绑定好的继承自 UnityAutoObject 的脚本
            IAutoObject<GameObject> autoObject = go.GetComponent<T>();
            if(autoObject == null)
            {
                throw new Exception("对象池生成的对象必须绑定继承自 UnityAutoObject 的脚本！");
            }
            if(doActive)
            {
                this.ActivateObject(autoObject);
            }
            else
            {
                this.UnactivateObject(autoObject);
            }
            return autoObject;
        }

        public void ActivateObject(IAutoObject<GameObject> obj)
        {
            obj.GetObject().SetActive(true);
        }

        public void UnactivateObject(IAutoObject<GameObject> obj)
        {
            obj.GetObject().SetActive(false);
        }

        public void DestroyObject(IAutoObject<GameObject> obj)
        {
            GameObject.Destroy(obj.GetObject());
        }
    }
}
