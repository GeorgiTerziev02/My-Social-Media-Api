namespace MySocialMedia.Server.Infrastructure.Extensions
{
    using Microsoft.AspNetCore.Mvc;

    public static class ObjectExtensions
    {
        public static ActionResult<TModel> OrNotFound<TModel>(this TModel model)
        {
            if (model == null)
            {
                return new NotFoundResult();
            }

            return model;
        }
    }
}
