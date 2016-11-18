using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECG.Parser.MWF
{
    /// <summary>
    /// 标准TLV基类定义
    /// type、length、value
    /// </summary>
    internal abstract class ITLV<T> : BaseData
    {
        public abstract byte TagType
        {
            get;
        }

        public int DataLength
        {
            get;
            private set;
        }

        public abstract T Content
        {
            get;
        }

        protected abstract ResolveResultCode ResolveContent(byte[] buffer, ref int offset);

        public ResolveResultCode Resolve(byte[] buffer, ref int offset)
        {
            byte tagType = buffer[offset];
            if (TagType == tagType ||
                TagType == byte.MaxValue)//255作为通用解析器
            {
                offset++;
                //计算长度偏移量
                if ((tagType & 0x20) > 0)
                {
                    offset++;
                    while (offset < buffer.Length
                        &&(buffer[offset] & 0x80) > 0)
                    {
                        offset++;
                    }
                }
                //读取内容长度
                if (ResolveLength(buffer, ref offset))
                {
                    return ResolveContent(buffer, ref offset);
                }
                return ResolveResultCode.LENGTH_ERROR;
            }
            else
            {
                return ResolveResultCode.TAG_ERROR;
            }
        }

        private bool ResolveLength(byte[] buffer, ref int offset)
        {
            DataLength = buffer[offset];
            //自定义长度标签，为0x8*，*表示实际长度的位数
            if ((DataLength & 0x80) != 0)
            {
                int iLenTag = DataLength & 0x7f;
                if (iLenTag > 4)
                {
                    return false;
                }
                else
                {
                    DataLength = 0;
                    for (int i = 1; i <= iLenTag; i++)
                    {
                        DataLength = (DataLength * 0x100) + buffer[offset + i];
                    }
                }
                offset += iLenTag + 1;
            }
            else
            {
                offset++;
            }
            if (DataLength > 0)
            {
                return offset + DataLength <= buffer.Length;//长度足够存放内容数据
            }
            return false;
        }
    }
}
