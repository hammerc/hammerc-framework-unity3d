// =================================================================================================
//
//	Hammerc Library
//	Copyright 2015 hammerc.org All Rights Reserved.
//
//	See LICENSE for full license information.
//
// =================================================================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace HammercLib.IO
{
    /// <summary>
    /// 数据输出类.
    /// </summary>
    public class ByteArrayOutput : IDataOutput
    {
        /// <summary>
        /// 数据记录列表.
        /// </summary>
        protected List<TypeInfo> _list;

        /// <summary>
        /// 字节顺序.
        /// </summary>
        protected Endian _endian;

        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="endian">字节序.</param>
        public ByteArrayOutput(Endian endian = Endian.LittleEndian)
        {
            _list = new List<TypeInfo>();
            _endian = endian;
        }

        public Endian endian
        {
            get { return _endian; }
        }

        /// <summary>
        /// 获取数据对应的字节数组.
        /// </summary>
        public byte[] bytes
        {
            get
            {
                if(_list.Count == 0)
                {
                    return null;
                }
                //记录字符串转换后的字节避免转换两次
                List<byte[]> bytesList = new List<byte[]>();
                //先计算出需要的字节的总长度
                int size = 0;
                byte[] bytes = null;
                for(int i = 0; i < _list.Count; i++)
                {
                    TypeInfo item = _list[i];
                    switch(item.type)
                    {
                        case DataType.Boolean:
                        case DataType.Byte:
                        case DataType.UnsignedByte:
                            ++size;
                            break;
                        case DataType.Short:
                        case DataType.UnsignedShort:
                            size += 2;
                            break;
                        case DataType.Int:
                        case DataType.UnsignedInt:
                        case DataType.Float:
                            size += 4;
                            break;
                        case DataType.Long:
                        case DataType.UnsignedLong:
                        case DataType.Double:
                            size += 8;
                            break;
                        case DataType.Utf:
                            size += 2;
                            bytes = Encoding.UTF8.GetBytes((string)item.value);
                            bytesList.Add(bytes);
                            size += bytes.Length;
                            break;
                        case DataType.UtfBytes:
                            bytes = Encoding.UTF8.GetBytes((string)item.value);
                            bytesList.Add(bytes);
                            size += bytes.Length;
                            break;
                        case DataType.MultiBytes:
                            bytes = Encoding.GetEncoding(item.charSet).GetBytes((string)item.value);
                            bytesList.Add(bytes);
                            size += bytes.Length;
                            break;
                        case DataType.Bytes:
                            bytes = (byte[])item.value;
                            bytesList.Add(bytes);
                            size += bytes.Length;
                            break;
                    }
                }
                //将数据写入字节流中
                ByteBuffer byteBuffer = new ByteBuffer(size, _endian);
                int index = 0;
                for(int i = 0; i < _list.Count; i++)
                {
                    TypeInfo item = _list[i];
                    switch(item.type)
                    {
                        case DataType.Boolean:
                            if((Boolean)item.value)
                            {
                                byteBuffer.WriteByte(1);
                            }
                            else
                            {
                                byteBuffer.WriteByte(0);
                            }
                            break;
                        case DataType.Byte:
                            byteBuffer.WriteByte((sbyte)item.value);
                            break;
                        case DataType.UnsignedByte:
                            byteBuffer.WriteUnsignedByte((byte)item.value);
                            break;
                        case DataType.Short:
                            byteBuffer.WriteShort((short)item.value);
                            break;
                        case DataType.UnsignedShort:
                            byteBuffer.WriteUnsignedShort((ushort)item.value);
                            break;
                        case DataType.Int:
                            byteBuffer.WriteInt((int)item.value);
                            break;
                        case DataType.UnsignedInt:
                            byteBuffer.WriteUnsignedInt((uint)item.value);
                            break;
                        case DataType.Long:
                            byteBuffer.WriteLong((long)item.value);
                            break;
                        case DataType.UnsignedLong:
                            byteBuffer.WriteUnsignedLong((ulong)item.value);
                            break;
                        case DataType.Float:
                            byteBuffer.WriteFloat((float)item.value);
                            break;
                        case DataType.Double:
                            byteBuffer.WriteDouble((double)item.value);
                            break;
                        case DataType.Utf:
                            bytes = bytesList[index++];
                            byteBuffer.WriteUnsignedShort((ushort)bytes.Length);
                            byteBuffer.WriteBytes(bytes);
                            break;
                        case DataType.UtfBytes:
                        case DataType.MultiBytes:
                        case DataType.Bytes:
                            bytes = bytesList[index++];
                            byteBuffer.WriteBytes(bytes);
                            break;
                    }
                }
                return byteBuffer.ToArray();
            }
        }

        public void WriteBoolean(bool value)
        {
            _list.Add(new TypeInfo(DataType.Boolean, value));
        }

        public void WriteByte(sbyte value)
        {
            _list.Add(new TypeInfo(DataType.Byte, value));
        }

        public void WriteUnsignedByte(byte value)
        {
            _list.Add(new TypeInfo(DataType.UnsignedByte, value));
        }

        public void WriteShort(short value)
        {
            _list.Add(new TypeInfo(DataType.Short, value));
        }

        public void WriteUnsignedShort(ushort value)
        {
            _list.Add(new TypeInfo(DataType.UnsignedShort, value));
        }

        public void WriteInt(int value)
        {
            _list.Add(new TypeInfo(DataType.Int, value));
        }

        public void WriteUnsignedInt(uint value)
        {
            _list.Add(new TypeInfo(DataType.UnsignedInt, value));
        }

        public void WriteLong(long value)
        {
            _list.Add(new TypeInfo(DataType.Long, value));
        }

        public void WriteUnsignedLong(ulong value)
        {
            _list.Add(new TypeInfo(DataType.UnsignedLong, value));
        }

        public void WriteFloat(float value)
        {
            _list.Add(new TypeInfo(DataType.Float, value));
        }

        public void WriteDouble(double value)
        {
            _list.Add(new TypeInfo(DataType.Double, value));
        }

        public void WriteUTF(string value)
        {
            _list.Add(new TypeInfo(DataType.Utf, value));
        }

        public void WriteUTFBytes(string value)
        {
            _list.Add(new TypeInfo(DataType.UtfBytes, value));
        }

        public void WriteMultiBytes(string value, string charSet)
        {
            _list.Add(new TypeInfo(DataType.MultiBytes, value));
        }

        public void WriteBytes(byte[] bytes)
        {
            _list.Add(new TypeInfo(DataType.Bytes, bytes));
        }

        public void WriteBytes(byte[] bytes, int offset, int length)
        {
            byte[] useBytes = new byte[length - offset];
            Array.Copy(bytes, offset, useBytes, 0, length);
            _list.Add(new TypeInfo(DataType.Bytes, useBytes));
        }

        /// <summary>
        /// 清除数据.
        /// </summary>
        public void clear()
        {
            _list.Clear();
        }

        protected enum DataType
        {
            Boolean,
            Byte,
            UnsignedByte,
            Short,
            UnsignedShort,
            Int,
            UnsignedInt,
            Long,
            UnsignedLong,
            Float,
            Double,
            Utf,
            UtfBytes,
            MultiBytes,
            Bytes
        }

        protected struct TypeInfo
        {
            public DataType type;
            public object value;
            public string charSet;

            public TypeInfo(DataType type, object value, string charSet = null)
            {
                this.type = type;
                this.value = value;
                this.charSet = charSet;
            }
        }
    }
}
