// =================================================================================================
//
//	Hammerc Library
//	Copyright 2015 hammerc.org All Rights Reserved.
//
//	See LICENSE for full license information.
//
// =================================================================================================

namespace HammercLib.Pool
{
    /// <summary>
    /// 对象工厂接口.
    /// </summary>
    /// <typeparam name="T">存放到对象池的对象.</typeparam>
    public interface IObjectFactory<T>
    {
        /// <summary>
        /// 创建一个对象.
        /// </summary>
        /// <param name="doActive">是否激活创建的对象.</param>
        /// <returns>创建的对象.</returns>
        T CreateObject(bool doActive);

        /// <summary>
        /// 激活指定对象.
        /// </summary>
        /// <param name="obj">对象.</param>
        void ActivateObject(T obj);

        /// <summary>
        /// 使指定对象失效.
        /// </summary>
        /// <param name="obj">对象.</param>
        void UnactivateObject(T obj);

        /// <summary>
        /// 销毁指定对象.
        /// </summary>
        /// <param name="obj">对象.</param>
        void DestroyObject(T obj);
    }
}
