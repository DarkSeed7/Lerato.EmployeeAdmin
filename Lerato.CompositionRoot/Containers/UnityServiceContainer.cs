using Unity;
using Unity.Resolution;

namespace Lerato.CompositionRoot.Containers
{
    public sealed class UnityServiceContainer
    {
       
        private static readonly UnityServiceContainer instance = new UnityServiceContainer();
        private static readonly UnityContainer Container;
   

        static UnityServiceContainer()
        {
            Container = new UnityContainer();
        }
        

        private UnityServiceContainer()
        {
        }
      

        public static UnityServiceContainer Instance
        {
            get
            {
                return instance;
            }
        }

        public void Register<T>()
        {
            if (!Container.IsRegistered(typeof(T)))
            {
                Container.RegisterType<T>();
            }
        }

        public void Register<T>(T type)
        {
            if (!Container.IsRegistered(typeof(T)))
            {
                Container.RegisterInstance<T>(type);
            }
        }

        public T Resolve<T>()
        {
            T ret = default(T);

            if (Container.IsRegistered(typeof(T)))
            {
                ret = Container.Resolve<T>();
            }

            return ret;
        }

        public T Resolve<T>(ResolverOverride[] constructionOverrides)
        {
            T ret = default(T);

            if (Container.IsRegistered(typeof(T)))
            {
                ret = Container.Resolve<T>(constructionOverrides);
            }

            return ret;
        }
    }
}
