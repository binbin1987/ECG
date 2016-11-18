using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECG.Parser.MWF
{
    /// <summary>
    /// 版本
    /// </summary>
    internal class MWF_VER_02 : ITLV<Version>
    {
        private Version _version = new Version();
        public override byte TagType
        {
            get { return 0x02; }
        }

        public override Version Content
        {
            get { return _version; }
        }

        protected override ResolveResultCode ResolveContent(byte[] buffer, ref int offset)
        {
            _version.Main = buffer[offset];
            offset++;
            _version.Sub = buffer[offset];
            offset++;
            _version.Revision = buffer[offset];
            return ResolveResultCode.SUCCESS;
        }
    }

    internal struct Version
    {
        public byte Main;
        public byte Sub;
        public byte Revision;
    }
}
