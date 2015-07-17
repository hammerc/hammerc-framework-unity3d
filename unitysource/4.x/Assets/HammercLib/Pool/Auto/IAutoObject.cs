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
    /// 可自动回收对象的接口.
    /// 
    /// 为何需要 T 类型: 
    /// 对象池存放的就是实现了 IAutoObject 接口的对象, 但是在 U3D 中 GameObject 对象
    /// 是无法扩展的, 只能扩展脚本组件, 脚本组件实现 IAutoObject 接口被对象池操作, 需
    /// 要提供一个接口告诉对象池实际需要对象池操作的 GameObject 对象.
    /// 
    /// </summary>
    /// <typeparam name="T">实际需要对象池操作的对象类型.</typeparam>
    public interface IAutoObject<T>
    {
        /// <summary>
        /// 获取是否可以进行回收.
        /// </summary>
        bool restore { get; }

        /// <summary>
        /// 检测当前对象是否可以进行回收, 本方法会每帧调用.
        /// </summary>
        void CheckRestore();

        /// <summary>
        /// 获取实际需要对象池操作的对象.
        /// </summary>
        /// <returns>实际需要对象池操作的对象.</returns>
        T GetObject();

        /// <summary>
        /// 从对象池中取出或创建时会调用该方法, 可以重置数据.
        /// </summary>
        void ResetObject();
    }
}
