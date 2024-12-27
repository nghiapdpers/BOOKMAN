using System;

namespace BookMan.ConsoleApp.Framework
{
    /// <summary>
    /// Class cha cho các controller
    /// </summary>
    public class ControllerBase
    {
        /// <summary>
        /// Render ra một view
        /// </summary>
        /// <param name="view">View cần render</param>
        public virtual void Render(ViewBase view)
        {
            view.Render();
        }

        /// <summary>
        /// Render và lưu file vào thư mục
        /// </summary>
        /// <typeparam name="T">Model dùng để lưu</typeparam>
        /// <param name="view"></param>
        /// <param name="saveFile"></param>
        /// <param name="fileName"></param>
        /// <param name="folder"></param>
        /// <exception cref="Exception"></exception>
        public virtual void Render<T>(ViewBase<T> view, bool saveFile = false, string fileName = null, string folder = null)
        {
            view.Render();

            if (saveFile)
            {
                if (string.IsNullOrEmpty(fileName))
                {
                    throw new Exception("Tên file không được rỗng");
                }

                view.SaveToPath(fileName, folder);
            }
        }

        /// <summary>
        /// Thông báo một message
        /// </summary>
        /// <param name="message"></param>
        public virtual void Render(Message message) => Render(new MessageView(message));
        /// <summary>
        /// Thông báo thành công
        /// </summary>
        /// <param name="text"></param>
        public virtual void Success(string text) => Render(new MessageView(new Message
        {
            Type = MessageType.SUCCECSS,
            Description = text,
        }));
        /// <summary>
        /// Thông báo lỗi
        /// </summary>
        /// <param name="text"></param>
        public virtual void Error(string text) => Render(new MessageView(new Message
        {
            Type = MessageType.ERROR,
            Description = text,
        }));
        /// <summary>
        /// Thông báo thường
        /// </summary>
        /// <param name="text"></param>
        public virtual void Information(string text) => Render(new MessageView(new Message
        {
            Type = MessageType.INFORMATION,
            Description = text,
        }));
        /// <summary>
        /// Thông báo câu hỏi và xác nhận
        /// </summary>
        /// <param name="text"></param>
        /// <param name="confirmCommand"></param>
        public virtual void Confirmation(string text, string confirmCommand) => Render(new MessageView(new Message
        {
            Type = MessageType.CONFIRMATION,
            Description = text,
            BackRoute = confirmCommand,
        }));
    }
}
