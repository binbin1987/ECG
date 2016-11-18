using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECG.Parser.MWF
{
    /// <summary>
    /// 每帧序列数
    /// </summary>
    internal class MWF_SEQ_06 : ITLV<uint>
    {
        private uint _numberOfSequences;
        public override byte TagType
        {
            get { return 0x06; }
        }

        public override uint Content
        {
            get { return _numberOfSequences; }
        }

        protected override ResolveResultCode ResolveContent(byte[] buffer, ref int offset)
        {
            if (GetData32(buffer, base.DataLength, ref offset, out _numberOfSequences))
            {
                return ResolveResultCode.SUCCESS;
            }
            return ResolveResultCode.CONTENT_ERROR;
        }
    }
}
