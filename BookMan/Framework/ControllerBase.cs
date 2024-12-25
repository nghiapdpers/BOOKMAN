using System;

namespace BookMan.ConsoleApp.Framework
{
    public abstract class ControllerBase
    {
        public virtual void Render(ViewBase view)
        {
            view.Render();
        }

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

        public abstract void Help();
    }
}
