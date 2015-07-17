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
    /// 对象池接口.
    /// </summary>
    /// <typeparam name="T">存放到对象池的对象.</typeparam>
    public interface IObjectPool<T>
    {
        /// <summary>
        /// 获取当前从对象池取出使用的对象数量.
        /// </summary>
        /// <returns>当前从对象池取出使用的对象数量.</returns>
        int GetActiveCount();

        /// <summary>
        /// 获取对象池中空闲的对象数量.
        /// </summary>
        /// <returns>对象池中空闲的对象数量.</returns>
        int GetIdleCount();

        /// <summary>
        /// 回收一个对象到对象池.
        /// </summary>
        /// <param name="obj">回收的对象.</param>
        void Restore(T obj);

        /// <summary>
        /// 从对象池中取出一个对象.
        /// </summary>
        /// <returns>对象池中取出的对象.</returns>
        T Take();

        /// <summary>
        /// 增加对象池里的一个对象.
        /// </summary>
        void AddObject();

        /// <summary>
        /// 清除对象池.
        /// </summary>
        void Clear();
    }
}
