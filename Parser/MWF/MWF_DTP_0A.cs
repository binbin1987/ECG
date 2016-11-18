using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECG.Parser.MWF
{
    /// <summary>
    /// 数据类型
    /// </summary>
    internal class MWF_DTP_0A : ITLV<DataType>
    {
        private DataType _dataType = DataType.Int16;
        public override byte TagType
        {
            get { return 0x0A; }
        }

        public override DataType Content
        {
            get { return _dataType; }
        }

        protected override ResolveResultCode ResolveContent(byte[] buffer, ref int offset)
        {
            if (Enum.IsDefined(typeof(DataType), buffer[offset]))
            {
                _dataType = (DataType)buffer[offset];
                offset += 1;
                return ResolveResultCode.SUCCESS;
            }
            return ResolveResultCode.CONTENT_ERROR;
        }
    }
    /// <summary>
    /// 数据类型
    /// </summary>
    internal enum DataType : byte
    {
        /// <summary>
        /// 
        /// </summary>
        Int16,
        /// <summary>
        /// 
        /// </summary>
        uInt16,
        /// <summary>
        /// 
        /// </summary>
        Int32,
        /// <summary>
        /// 
        /// </summary>
        uInt8,
        /// <summary>
        /// 
        /// </summary>
        Int16_Status,
        /// <summary>
        /// 
        /// </summary>
        Int8,
        /// <summary>
        /// 
        /// </summary>
        uInt32,
        /// <summary>
        /// 
        /// </summary>
        Int64,
        /// <summary>
        /// 
        /// </summary>
        Int8_AHA
    }
}
