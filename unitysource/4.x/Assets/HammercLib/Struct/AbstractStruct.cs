// =================================================================================================
//
//	Hammerc Library
//	Copyright 2015 hammerc.org All Rights Reserved.
//
//	See LICENSE for full license information.
//
// =================================================================================================

using HammercLib.IO;

namespace HammercLib.Struct
{
    /// <summary>
    /// 可以写入字节流和从字节流中读取的自定义数据类.
    /// </summary>
    public abstract class AbstractStruct : IExternalizable
    {
        /// <summary>
        /// 自定义数据类的编码字节序.
        /// </summary>
        public const Endian STRUCT_ENDIAN = Endian.BigEndian;

        /// <summary>
        /// 构造函数.
        /// </summary>
        public AbstractStruct()
        {
        }

        public void WriteExternal(IDataOutput output)
        {
            output.endian = STRUCT_ENDIAN;
            this.WriteToBytes(output);
        }

        /// <summary>
        /// 编码本对象.
        /// </summary>
        /// <param name="output">输出流对象.</param>
        protected abstract void WriteToBytes(IDataOutput output);

        public void ReadExternal(IDataInput input)
        {
            input.endian = STRUCT_ENDIAN;
            this.ReadFromBytes(input);
        }

        /// <summary>
        /// 解码本对象.
        /// </summary>
        /// <param name="input">输入流对象.</param>
        protected abstract void ReadFromBytes(IDataInput input);
    }
}
