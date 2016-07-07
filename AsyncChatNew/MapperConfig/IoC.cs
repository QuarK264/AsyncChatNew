using Ninject;

namespace AsyncChatNew.MapperConfig
{
    /// <summary>
    /// Сервис-локатор
    /// wtf i'm doing?
    /// </summary>
    public class IoC
    {
        private static IKernel _kernel;

        public static IKernel Instance
        {
            get { return _kernel ?? (_kernel = new StandardKernel()); }
        }
    }
}