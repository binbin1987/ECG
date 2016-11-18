using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECG.Parser.MWF
{
    /// <summary>
    /// 普通解析器
    /// </summary>
    internal class MWF_NORMAL_FF : ITLV<string>
    {
        private string _content=string.Empty;
        public override byte TagType
        {
            get {  return byte.MaxValue; }
        }

        public override string Content
        {
            get { return _content; }
        }

        protected override ResolveResultCode ResolveContent(byte[] buffer, ref int offset)
        {
            _content += Encoding.Default.GetString(buffer, offset, base.DataLength) + Environment.NewLine;
            offset += base.DataLength;
            return ResolveResultCode.SUCCESS;
        }
    }
}
