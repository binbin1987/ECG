using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECG.Parser.MWF
{
    /// <summary>
    /// 压缩参数
    /// </summary>
    internal class MWF_CMP_0E : ITLV<CompressionInfo>
    {
        private CompressionInfo _compression = new CompressionInfo();
        public override byte TagType
        {
            get { return 0x0E; }
        }

        public override CompressionInfo Content
        {
            get { return _compression; }
        }

        protected override ResolveResultCode ResolveContent(byte[] buffer, ref int offset)
        {
            ushort sCompressionType = 0;
            if (GetData16(buffer, base.DataLength, ref offset, out sCompressionType))
            {
                if (Enum.IsDefined(typeof(CompressionType), sCompressionType))
                {
                    _compression.Compression = (CompressionType)sCompressionType;
                    if (_compression.Compression == CompressionType.No
                        || base.DataLength <= 2)
                    {
                        return ResolveResultCode.SUCCESS;
                    }
                    else
                    {
                        if (GetData32(buffer, 4, ref offset, out _compression.DataLength))
                        {
                            if (GetData32(buffer, base.DataLength - 6, ref offset, out _compression.CompressedLength))
                            {
                                return ResolveResultCode.SUCCESS;
                            }
                        }
                    }
                }
            }
            return ResolveResultCode.CONTENT_ERROR;
        }
    }

    internal struct CompressionInfo
    {
        public CompressionType Compression;
        public UInt32 DataLength;
        public UInt32 CompressedLength;
    }

    /// <summary>
    /// 压缩类型
    /// </summary>
    internal enum CompressionType : ushort
    {
        /// <summary>
        /// 无
        /// </summary>
        No = 0,
        /// <summary>
        /// 压缩头数据节点
        /// </summary>
        MFER_Header = 2,
        /// <summary>
        /// 压缩波形数据节点
        /// </summary>
        MFER_Waveform = 3
    }
}
