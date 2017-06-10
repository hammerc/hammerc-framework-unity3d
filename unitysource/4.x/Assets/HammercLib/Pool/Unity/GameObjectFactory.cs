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
        private bool _dontDestroyOnLoad;
        private GameObject _poolGameObject;

        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="gameObject">创建的对象类型.</param>
        /// <param name="dontDestroyOnLoad">指定该对象池创建的对象是否切换场景时不被销毁.</param>
        /// <param name="poolGameObject">对象池脚本的游戏对象.</param>
        public GameObjectFactory(GameObject gameObject, bool dontDestroyOnLoad, GameObject poolGameObject)
        {
            _gameObject = gameObject;
            _dontDestroyOnLoad = dontDestroyOnLoad;
            _poolGameObject = poolGameObject;
        }

        public IAutoObject<GameObject> CreateObject(bool doActive)
        {
            GameObject go = GameObject.Instantiate(_gameObject) as GameObject;
            //对象切换场景时不被销毁
            if(_dontDestroyOnLoad)
            {
                GameObject.DontDestroyOnLoad(go);
            }
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
            //某些情况下比如销毁场景时, 可能走到这一步时对象池已经被销毁, 这里将报错去除
            try
            {
                //将回收的对象作为当前对象的子对象, 方便折叠进行查看
                obj.GetObject().transform.SetParent(_poolGameObject.transform);
            }
            catch(Exception exception)
            {
            }
            //设置为不活跃
            obj.GetObject().SetActive(false);
        }

        public void DestroyObject(IAutoObject<GameObject> obj)
        {
            GameObject.Destroy(obj.GetObject());
        }
    }
}
