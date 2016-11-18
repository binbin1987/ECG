using System;
using System.Text;

namespace ECG.Parser.MWF
{
    /// <summary>
    /// 波形属性
    /// 比如导联名称
    /// </summary>
    internal class MWF_LDN_09:ITLV<UInt16>
    {
        private ushort _code;
        private string _info;
        public override byte TagType
        {
            get { return 0x09; }
        }

        public override ushort Content
        {
            get { return _code; }
        }

        protected override ResolveResultCode ResolveContent(byte[] buffer, ref int offset)
        {
            int iCodeLength = offset;
            if (GetData16(buffer, base.DataLength, ref offset, out _code))
            {
                iCodeLength -= offset;
                if (DataLength != iCodeLength)
                {
                    _info = Encoding.Default.GetString(buffer, offset, DataLength - iCodeLength);
                }
                return ResolveResultCode.SUCCESS;
            }
            return ResolveResultCode.CONTENT_ERROR;
        }
    }
}
