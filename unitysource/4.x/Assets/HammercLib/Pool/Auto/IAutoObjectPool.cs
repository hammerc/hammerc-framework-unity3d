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
    /// 可自动回收的对象池接口.
    /// </summary>
    /// <typeparam name="T">实际需要对象池操作的对象类型.</typeparam>
    public interface IAutoObjectPool<T> : IObjectPool<IAutoObject<T>>
    {
        /// <summary>
        /// 检测对象池中的对象是否可以进行回收, 本方法应每帧调用.
        /// </summary>
        void CheckRestore();
    }
}
