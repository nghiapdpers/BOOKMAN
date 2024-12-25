using System;

namespace BookMan.ConsoleApp.Framework
{
    /// <summary>
    /// Các kiểu của message
    /// </summary>
    public enum MessageType { SUCCECSS, ERROR, INFORMATION, CONFIRMATION }

    /// <summary>
    /// Tạo kiểu dữ liệu Message
    /// </summary>
    public struct Message
    {
        public MessageType Type { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public string BackRoute { get; set; }
    }

    /// <summary>
    /// Class hiển thị thông tin message
    /// </summary>
    public class MessageView : ViewBase<Message>
    {
        public MessageView(Message model) : base(model)
        {
        }

        /// <summary>
        /// Render thông tin message tùy theo kiểu message
        /// </summary>
        public override void Render()
        {
            switch (Model.Type)
            {
                case MessageType.ERROR:
                    ViewHelp.WriteLine(Model.Label.ToUpper() ?? "LỖI", System.ConsoleColor.DarkRed);
                    break;
                case MessageType.SUCCECSS:
                    ViewHelp.WriteLine(Model.Label.ToUpper() ?? "THÀNH CÔNG", System.ConsoleColor.DarkGreen);
                    break;
                case MessageType.INFORMATION:
                    ViewHelp.WriteLine(Model.Label.ToUpper() ?? "THÔNG TIN", System.ConsoleColor.DarkYellow);
                    break;
                case MessageType.CONFIRMATION:
                    ViewHelp.WriteLine(Model.Label.ToUpper() ?? "XÁC NHẬN", System.ConsoleColor.DarkMagenta);
                    break;
            }
            ViewHelp.WriteLine(Model.Description, Model.Type == MessageType.CONFIRMATION ? System.ConsoleColor.DarkCyan : System.ConsoleColor.White);
            if (Model.Type == MessageType.CONFIRMATION)
            {
                ViewHelp.Write("[Gõ 'y' hoặc 'yes' để nhận, nhập bất kì để hủy] >>>: ");
                bool answer = Console.ReadLine().ToBool();
                if (answer)
                {
                    Router.Forward(Model.BackRoute);
                }
            }
        }
    }
}
