using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECG.Parser.MWF
{
    /// <summary>
    /// 数据帧头位置
    /// </summary>
    internal class MWF_PNT_07 : ITLV<uint>
    {
        private uint _dataPointer ;
        public override byte TagType
        {
            get { return 0x07; }
        }

        public override uint Content
        {
            get { return _dataPointer; }
        }

        protected override ResolveResultCode ResolveContent(byte[] buffer, ref int offset)
        {
            if (GetData32(buffer, base.DataLength, ref offset, out _dataPointer))
            {
                return ResolveResultCode.SUCCESS;
            }
            return ResolveResultCode.CONTENT_ERROR;
        }
    }
}
