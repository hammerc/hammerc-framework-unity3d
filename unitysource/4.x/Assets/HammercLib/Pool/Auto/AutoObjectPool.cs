// =================================================================================================
//
//	Hammerc Library
//	Copyright 2015 hammerc.org All Rights Reserved.
//
//	See LICENSE for full license information.
//
// =================================================================================================

using System.Collections.Generic;

namespace HammercLib.Pool
{
    /// <summary>
    /// 可进行自动回收的对象池类.
    /// </summary>
    /// <typeparam name="T">实际需要对象池操作的对象类型.</typeparam>
    public class AutoObjectPool<T> : SimpleObjectPool<IAutoObject<T>>, IAutoObjectPool<T>
    {
        private readonly List<IAutoObject<T>> _usingList = new List<IAutoObject<T>>();

        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="factory">对象池工厂对象.</param>
        /// <param name="maxIdleCount">最大可以达到的空闲对象数量.</param>
        public AutoObjectPool(IObjectFactory<IAutoObject<T>> factory, int maxIdleCount) : base(factory, maxIdleCount)
        {
        }

        public override void Restore(IAutoObject<T> obj)
        {
            base.Restore(obj);
            _usingList.Remove(obj);
        }

        public override IAutoObject<T> Take()
        {
            IAutoObject<T> obj = base.Take();
            _usingList.Add(obj);
            obj.ResetObject();
            return obj;
        }

        public virtual void CheckRestore()
        {
            for(int i = 0; i < _usingList.Count; i++)
            {
                IAutoObject<T> obj = _usingList[i];
                obj.CheckRestore();
                if(obj.restore)
                {
                    this.Restore(obj);
                    i--;
                }
            }
        }

        public override void Clear()
        {
            base.Clear();
            foreach(IAutoObject<T> obj in _usingList)
            {
                _factory.DestroyObject(obj);
            }
            _usingList.Clear();
        }
    }
}
