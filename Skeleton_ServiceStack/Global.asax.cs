using System;
using System.Security.Policy;
using ServiceStack.CacheAccess;
using ServiceStack.CacheAccess.Providers;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;
using ServiceStack.WebHost.Endpoints;

namespace Skeleton_ServiceStack
{
	using ServiceStack.FluentValidation;
	using ServiceStack.ServiceInterface.Validation;

	public class Global : System.Web.HttpApplication
    {

        public class CaseAppHost : AppHostBase
        {
            public CaseAppHost() : base("Case Web Services", typeof (CaseService).Assembly)
            {
                
            }

            public override void Configure(Funq.Container container)
            {
                Plugins.Add(
                    new AuthFeature(() =>
                        new AuthUserSession(),
                        new IAuthProvider[]
                        {
                            new DigestAuthProvider(),
                            new BasicAuthProvider()
                        }));

                Plugins.Add(new RegistrationFeature());
				Plugins.Add(new ValidationFeature());

                container.Register<ICaseRepository>(new InMemoryCaseRepository());
				container.Register<IReferenceValidator>(new ReferenceValidator(new InMemoryCaseRepository()));
				container.RegisterValidators(typeof(CaseValidator).Assembly);

                container.Register<ICacheClient>(new MemoryCacheClient());
                var userRep = new InMemoryAuthRepository();
                container.Register<IUserAuthRepository>(userRep);

                string hash;
                string salt;
	            string password = "password";

	            new SaltedHash().GetHashAndSaltString(password, out hash, out salt);

                userRep.CreateUserAuth(new UserAuth
                {
                    Id = 1,
                    FirstName = "Joe",
                    LastName = "Bloggs",
                    DisplayName = "Joe Bloggs",
                    UserName = "jbloggs",
                    Email = "joe@bloggs.com",
                    Salt = salt,
                    PasswordHash = hash
                }, password);
            }
        }



        protected void Application_Start(object sender, EventArgs e)
        {
            new CaseAppHost().Init();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}