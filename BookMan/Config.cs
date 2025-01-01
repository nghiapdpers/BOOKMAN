using BookMan.ConsoleApp.DataServices;

namespace BookMan.ConsoleApp
{
    internal class Config
    {
        private static Config _instance;
        public static Config Instance
        {
            get
            {
                _instance ??= new Config();

                return _instance;
            }
        }
        private Config() { }
        private Settings _s = Settings.Default;
        public IDataAccess IDataAccess
        {
            get
            {
                var da = _s.DataAccess;
                switch (da)
                {
                    case "json": return new JsonDataAccess();
                    case "xml": return new XmlDataAccess();
                    case "bin":
                    case "binary":
                        return new BinaryDataAccess();
                    default: return new JsonDataAccess();
                }
            }
        }
        public string DataAcess
        {
            get => _s.DataAccess;
            set
            {
                _s.DataAccess = value;
                _s.Save();
            }
        }

        public string PrompText
        {
            get => _s.PrompText;
            set
            {
                _s.PrompText = value;
                _s.Save();
            }
        }

        public string DataFile
        {
            get => _s.DataFile;
            set
            {
                _s.DataFile = value;
                _s.Save();
            }
        }
    }
}
