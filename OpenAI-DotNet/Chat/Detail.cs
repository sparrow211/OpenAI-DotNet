using System;

namespace OpenAI.Chat
{
    public enum Detail
    {
        Auto = 0,

        /// <summary>
        /// 将禁用“高分辨率”模型。该模型将收到低分辨率512px x 512px 版本的图像，并以65 个代币的预算表示图像。这允许 API 返回更快的响应，并为不需要高细节的用例使用更少的输入令牌
        /// </summary>
        Low,

        /// <summary>
        /// 将禁用“高分辨率”模型。该模型将收到低分辨率 512px x 512px 版本的图像，并以65个代币的预算表示图像。这允许 API 返回更快的响应，并为不需要高细节的用例使用更少的输入令牌
        /// </summary>
        High,
    }
}