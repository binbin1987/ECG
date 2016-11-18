using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECG.Parser.MWF
{
    /// <summary>
    /// 空白节点
    /// </summary>
    internal class MWF_ZRO_00 : ITLV<String>
    {
        private string _content=string.Empty;
        public override byte TagType
        {
            get { return 0x00; }
        }

        public override string Content
        {
            get { return _content; }
        }

        protected override ResolveResultCode ResolveContent(byte[] buffer, ref int offset)
        {
            while (offset < buffer.Length
                && buffer[offset] == 0x00)
            {
                _content += "00 ";
                offset++;
            }
            return ResolveResultCode.SUCCESS;
        }
    }
}
