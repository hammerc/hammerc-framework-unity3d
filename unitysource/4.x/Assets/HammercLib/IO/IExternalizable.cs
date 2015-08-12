// =================================================================================================
//
//	Hammerc Library
//	Copyright 2015 hammerc.org All Rights Reserved.
//
//	See LICENSE for full license information.
//
// =================================================================================================

namespace HammercLib.IO
{
    /// <summary>
    /// 定义了可以进行序列化和反序列化的数据类型.
    /// </summary>
    public interface IExternalizable
    {
        /// <summary>
        /// 将其自身编码到数据流中.
        /// </summary>
        /// <param name="output">数据输出对象.</param>
        void WriteExternal(IDataOutput output);

        /// <summary>
        /// 将其自身从数据流中解码.
        /// </summary>
        /// <param name="input">数据输入对象.</param>
        void ReadExternal(IDataInput input);
    }
}
