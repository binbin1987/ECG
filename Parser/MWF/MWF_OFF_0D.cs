using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECG.Parser.MWF
{
    /// <summary>
    /// 数据偏移量
    /// </summary>
    internal class MWF_OFF_0D:ITLV<UInt64>
    {
        private ulong _offset;
        public override byte TagType
        {
            get { return 0x0D; }
        }

        public override ulong Content
        {
            get { return _offset; }
        }

        protected override ResolveResultCode ResolveContent(byte[] buffer, ref int offset)
        {
            if (GetData64(buffer,base.DataLength, ref offset, out _offset))
            {
                return ResolveResultCode.SUCCESS;
            }
            return ResolveResultCode.CONTENT_ERROR;
        }
    }
}
