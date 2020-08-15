using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using UCenterApi.Model.CollectionReceive;
using UCenterApi.Model.CollectionReturn;
using UCenterApi.Model.ItemReceive;

namespace UCenterApi.Api
{
    public class UcApiWrapper
    {
        public const string API_RETURN_SUCCEED = "1";
        public const string API_RETURN_FAILED = "-1";
        public const string API_RETURN_FORBIDDEN = "-2";

        private readonly IUcApi _ucApi;
        private readonly IUcConfig _ucConfig;
        private readonly UcUtility _ucUtility;

        /// <summary>
        /// Action
        /// </summary>
        public string Action { get; private set; }

        private string Code { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        public long Time { get; private set; }

        /// <summary>
        /// Query参数
        /// </summary>
        public NameValueCollection QueryString { get; private set; }
        /// <summary>
        /// Form参数
        /// </summary>
        public string FormData { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsInvalidRequest { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsAuthracationExpiried { get; private set; }


        public UcApiWrapper(string code, NameValueCollection queryString, string formData, IUcConfig ucConfig, IUcApi ucApi, UcUtility ucUtility)
        {
            this.Code = code;
            this.QueryString = queryString;
            this.FormData = formData;

            Action = QueryString["action"];
            long time;
            if (long.TryParse(QueryString["time"], out time)) Time = time;
            IsInvalidRequest = QueryString.Count == 0 && UcActions.Contains(Action);
            IsAuthracationExpiried = (UcUtility.PhpTimeNow() - Time) > 0xe10;


            this._ucConfig = ucConfig;
            this._ucApi = ucApi;
            this._ucUtility = ucUtility;
        }

        public string Process()
        {
            switch (this.Action)
            {
              // TODO: 根据不同 Action 调用 API
            }

            return "";
        }

        #region Apis
        protected string DeleteUser()
        {
            throw new NotImplementedException();
        }

        protected string GetCredit()
        {
            throw new NotImplementedException();
        }

        protected string GetCreditSettings()
        {
            throw new NotImplementedException();
        }

        protected string GetTag()
        {
            throw new NotImplementedException();
        }

        protected string RenameUser()
        {
            throw new NotImplementedException();
        }

        protected string SynLogin()
        {
            throw new NotImplementedException();
        }

        protected string SynLogout()
        {
            throw new NotImplementedException();
        }

        protected string Test()
        {
            throw new NotImplementedException();
        }

        protected string UpdateApps()
        {
            throw new NotImplementedException();
        }

        protected string UpdateBadWords()
        {
            throw new NotImplementedException();
        }

        protected string UpdateClient()
        {
            throw new NotImplementedException();
        }

        protected string UpdateCredit()
        {
            throw new NotImplementedException();
        }

        protected string UpdateCreditSettings()
        {
            throw new NotImplementedException();
        }

        protected string UpdateHosts()
        {
            throw new NotImplementedException();
        }

        protected string UpdatePw()
        {
            throw new NotImplementedException();
        } 
        #endregion


    }
}
