using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECG.Parser.MWF
{
    /// <summary>
    /// 空值定义，需要忽略的数据空值
    /// *未实现
    /// </summary>
    internal class MWF_NUL_12:ITLV<long>
    {
        public override byte TagType
        {
            get { return 0x12; }
        }

        public override long Content
        {
            get { return long.MaxValue; }
        }

        protected override ResolveResultCode ResolveContent(byte[] buffer, ref int offset)
        {
            offset += base.DataLength;
            return ResolveResultCode.SUCCESS;
        }
    }
}
