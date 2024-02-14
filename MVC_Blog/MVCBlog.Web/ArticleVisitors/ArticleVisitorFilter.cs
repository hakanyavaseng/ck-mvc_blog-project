//using Microsoft.AspNetCore.Cors;
//using Microsoft.AspNetCore.Mvc.Filters;
//using MVCBlog.Data.UnitOfWorks;
//using MVCBlog.Entity.Entities;

//namespace MVCBlog.Web.ArticleVisitors
//{
//    public class ArticleVisitorFilter : IAsyncActionFilter
//    {
//        private readonly IUnitOfWork _unitOfWork;
//        public ArticleVisitorFilter(IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
            
//        }
//        public bool Disable { get; set; }
//        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
//        {
//            //if(Disable) return next();

//            List<Visitor> visitors = await _unitOfWork.GetRepository<Visitor>().GetAllAsync();


//            string getIp = context.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
//            string getUserAgent = context.HttpContext.Request.Headers["User-Agent"];

//            Visitor visitor = new(getIp, getUserAgent);



//            if (visitors.Any(x => x.IpAddress == visitor.IpAddress))
//                await next();
//            else
//            {
//                await _unitOfWork.GetRepository<Visitor>().AddAsync(visitor);
//                await _unitOfWork.SaveAsync();
//                await next();
//            }

//        }
//    }
//}
