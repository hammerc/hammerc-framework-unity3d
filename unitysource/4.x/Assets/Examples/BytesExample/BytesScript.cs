using UnityEngine;
using System.Collections;
using HammercLib.IO;
using HammercLib.Utils;

public class BytesScript : MonoBehaviour
{
    void Start()
    {
    }
    
    void Update()
    {
    }

    void OnGUI()
    {
        if(GUI.Button(new Rect(50,50,200,30), "使用BigEndian写入文件"))
        {
            ByteArrayOutput output = new ByteArrayOutput();
            output.endian = Endian.BigEndian;

            output.WriteBoolean(true);
            output.WriteByte(-55);
            output.WriteUnsignedByte(188);
            output.WriteShort(-12345);
            output.WriteUnsignedShort(65535);
            output.WriteInt(-1234567);
            output.WriteUnsignedInt(1234567);
            output.WriteLong(-1234567891011);
            output.WriteUnsignedLong(1234567891011);
            output.WriteFloat(123.456f);
            output.WriteDouble(123456789.123456789d);
            output.WriteUTF("Hello Unity3D! 你好，尤三弟！");

            byte[] bytes = output.bytes;
            FileHelper.SaveAsBytes("C:\\test_big_endian.bytes", bytes);

            Debug.Log("save file ok!");
        }
        if(GUI.Button(new Rect(50, 100, 200, 30), "读取BigEndian的数据"))
        {
            byte[] bytes = FileHelper.ReadAsBytes("C:\\test_big_endian.bytes");
            ByteArrayInput input = new ByteArrayInput(bytes);
            input.endian = Endian.BigEndian;

            Debug.Log("位置: " + input.position + ", 剩余: " + input.bytesAvailable);
            Debug.Log(input.ReadBoolean());
            Debug.Log(input.ReadByte());
            Debug.Log(input.ReadUnsignedByte());
            Debug.Log(input.ReadShort());
            Debug.Log(input.ReadUnsignedShort());
            Debug.Log(input.ReadInt());
            Debug.Log("位置: " + input.position + ", 剩余: " + input.bytesAvailable);
            Debug.Log(input.ReadUnsignedInt());
            Debug.Log(input.ReadLong());
            Debug.Log(input.ReadUnsignedLong());
            Debug.Log(input.ReadFloat());
            Debug.Log(input.ReadDouble());
            Debug.Log(input.ReadUTF());
            Debug.Log("位置: " + input.position + ", 剩余: " + input.bytesAvailable);
        }

        if(GUI.Button(new Rect(300, 50, 200, 30), "使用LittleEndian写入文件"))
        {
            ByteArrayOutput output = new ByteArrayOutput();
            output.endian = Endian.LittleEndian;

            output.WriteBoolean(true);
            output.WriteByte(-55);
            output.WriteUnsignedByte(188);
            output.WriteShort(-12345);
            output.WriteUnsignedShort(65535);
            output.WriteInt(-1234567);
            output.WriteUnsignedInt(1234567);
            output.WriteLong(-1234567891011);
            output.WriteUnsignedLong(1234567891011);
            output.WriteFloat(123.456f);
            output.WriteDouble(123456789.123456789d);
            output.WriteUTF("Hello Unity3D! 你好，尤三弟！");

            byte[] bytes = output.bytes;
            FileHelper.SaveAsBytes("C:\\test_little_endian.bytes", bytes);

            Debug.Log("save file ok!");
        }
        if(GUI.Button(new Rect(300, 100, 200, 30), "读取LittleEndian的数据"))
        {
            byte[] bytes = FileHelper.ReadAsBytes("C:\\test_little_endian.bytes");
            ByteArrayInput input = new ByteArrayInput(bytes);
            input.endian = Endian.LittleEndian;

            Debug.Log("位置: " + input.position + ", 剩余: " + input.bytesAvailable);
            Debug.Log(input.ReadBoolean());
            Debug.Log(input.ReadByte());
            Debug.Log(input.ReadUnsignedByte());
            Debug.Log(input.ReadShort());
            Debug.Log(input.ReadUnsignedShort());
            Debug.Log(input.ReadInt());
            Debug.Log("位置: " + input.position + ", 剩余: " + input.bytesAvailable);
            Debug.Log(input.ReadUnsignedInt());
            Debug.Log(input.ReadLong());
            Debug.Log(input.ReadUnsignedLong());
            Debug.Log(input.ReadFloat());
            Debug.Log(input.ReadDouble());
            Debug.Log(input.ReadUTF());
            Debug.Log("位置: " + input.position + ", 剩余: " + input.bytesAvailable);
        }
    }
}
