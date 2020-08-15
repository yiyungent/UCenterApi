using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using UCenterApi.Api;

namespace UCenterApi.AspNetCore
{
    public class UCenterApiMiddleware
    {
        protected readonly RequestDelegate _next;

        protected readonly UCenterApiOptions _options;

        public UCenterApiMiddleware(RequestDelegate next, IOptions<UCenterApiOptions> optionsAccessor)
        {
            _next = next;
            _options = optionsAccessor.Value;
        }

        public async Task InvokeAsync(HttpContext context, IUcApi ucApi, IUcConfig ucConfig, UcUtility ucUtility)
        {
            NameValueCollection tempQs = new NameValueCollection();
            tempQs = HttpUtility.ParseQueryString(context.Request.QueryString.Value);
            string code = tempQs["code"];
            NameValueCollection queryString = HttpUtility.ParseQueryString(ucUtility.AuthCodeDecode(code));

            string formData = context.Request.Form.ToString();

            UcApiWrapper ucApiWrapper = new UcApiWrapper(code, queryString, formData, ucConfig, ucApi, ucUtility);

            string responseStr = ucApiWrapper.Process();
            
            await context.Response.WriteAsync(responseStr);
        }
    }
}
