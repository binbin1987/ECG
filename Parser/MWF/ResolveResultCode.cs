using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECG.Parser.MWF
{
    /// <summary>
    /// 解析结果
    /// </summary>
    internal enum ResolveResultCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        SUCCESS = 0x00,
        /// <summary>
        /// 未知错误
        /// </summary>
        UNKNOWN_ERROR = 0x01,
        /// <summary>
        /// 标签错误
        /// </summary>
        TAG_ERROR = 0x02,
        /// <summary>
        /// 长度错误
        /// </summary>
        LENGTH_ERROR = 0x03,
        /// <summary>
        /// 内容错误
        /// </summary>
        CONTENT_ERROR = 0x04
    }
}
