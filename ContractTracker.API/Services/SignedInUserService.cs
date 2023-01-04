namespace ContractTracker.API.Services
{
    public interface ISignedInUserService
    {
        string? GetCurrentUserAccountName();
    }
    public class SignedInUserService : ISignedInUserService
    {
        //READ ME! The HttpContext is injected per request and the accessor is set in Program.cs
        //However, NOTHING THAT TOUCHES HttpContext can be inside an async/task. It is not thread safe!
        //You may pick out the proprerties and pass them around, but even do that with caution. 
        private readonly IHttpContextAccessor context; 
        public SignedInUserService(IHttpContextAccessor context)
        {
            this.context = context;
        }

        public string? GetCurrentUserAccountName()
        {
            if (context.HttpContext == null)
                return null;

            if (context.HttpContext.User == null)
                return null;

            return string.IsNullOrEmpty(context.HttpContext.User.Identity?.Name) ? string.Empty : context.HttpContext.User.Identity?.Name;

        }
    }
}
