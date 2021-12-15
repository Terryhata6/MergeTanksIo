namespace Utilits
{
    public class Singleton<T> where T : new()
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance.Equals(null))
                {
                    return new T();
                }
                else
                {
                    return _instance;
                }
            }
            protected set
            {
                _instance = value;
            }
        }
        
    }
}