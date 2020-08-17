using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using UCenterApi.Model;
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

        public bool IsNeedHeaders { get; set; }

        public Dictionary<string, string> Headers { get; set; }

        #region Ctor
        public UcApiWrapper()
        {
            this.Headers = new Dictionary<string, string>();
        }
        #endregion


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
            string rtn = "";
            if (this.Action == UcActions.Test)
            {
                rtn = Test();
            }
            else if (this.Action == UcActions.DeleteUser)
            {
                rtn = DeleteUser();
            }
            else if (this.Action == UcActions.RenameUser)
            {
                rtn = RenameUser();
            }
            else if (this.Action == UcActions.GetTag)
            {
                rtn = GetTag();
            }
            else if (this.Action == UcActions.SynLogin)
            {
                rtn = SynLogin();
            }
            else if (this.Action == UcActions.SynLogout)
            {
                rtn = SynLogout();
            }
            else if (this.Action == UcActions.UpdatePw)
            {
                rtn = UpdatePw();
            }
            else if (this.Action == UcActions.UpdateBadWords)
            {
                rtn = UpdateBadWords();
            }
            else if (this.Action == UcActions.UpdateHosts)
            {
                rtn = UpdateHosts();
            }
            else if (this.Action == UcActions.UpdateApps)
            {
                rtn = UpdateApps();
            }
            else if (this.Action == UcActions.UpdateClient)
            {
                rtn = UpdateClient();
            }
            else if (this.Action == UcActions.UpdateCredit)
            {
                rtn = UpdateCredit();
            }
            else if (this.Action == UcActions.GetCreditSettings)
            {
                rtn = GetCreditSettings();
            }
            else if (this.Action == UcActions.GetCredit)
            {
                rtn = GetCredit();
            }
            else if (this.Action == UcActions.UpdateCreditSettings)
            {
                rtn = UpdateCreditSettings();
            }

            return rtn;
        }

        #region Apis
        protected string DeleteUser()
        {
            if (!_ucConfig.ApiDeleteUser) return API_RETURN_FORBIDDEN;
            var ids = this.QueryString["ids"];
            var idArray = new List<int>();
            foreach (var id in ids.Split(','))
            {
                int idInt;
                if (int.TryParse(id, out idInt)) idArray.Add(idInt);
            }

            var temp = this._ucApi.DeleteUser(idArray);
            return Write(temp); ;
        }

        protected string GetCredit()
        {
            if (!_ucConfig.ApiGetCredit) return API_RETURN_FORBIDDEN;
            int uid;
            int.TryParse(this.QueryString["uid"], out uid);
            int credit;
            int.TryParse(this.QueryString["credit"], out credit);

            var temp = this._ucApi.GetCredit(uid, credit);
            return Write(temp);
        }

        protected string GetCreditSettings()
        {
            if (!_ucConfig.ApiGetCreditSettings) return API_RETURN_FORBIDDEN;

            var temp = this._ucApi.GetCreditSettings();
            return Write(temp);
        }

        protected string GetTag()
        {
            if (!_ucConfig.ApiGetTag) return API_RETURN_FORBIDDEN;
            var tagName = this.QueryString["id"];
            var temp = this._ucApi.GetTag(tagName);

            return Write(temp);
        }

        protected string RenameUser()
        {
            if (!_ucConfig.ApiRenameUser) return API_RETURN_FORBIDDEN;
            int uid;
            int.TryParse(this.QueryString["uid"], out uid);
            var oldusername = this.QueryString["oldusername"];
            var newusername = this.QueryString["newusername"];
            var temp = this._ucApi.RenameUser(uid, oldusername, newusername);

            return Write(temp);
        }

        protected string SynLogin()
        {
            if (!_ucConfig.ApiSynLogin) return API_RETURN_FORBIDDEN;
            // TODO: 注意这里还有修改 Headers 的行为
            //Response.Headers.Add("P3P", "CP=\"CURa ADMa DEVa PSAo PSDo OUR BUS UNI PUR INT DEM STA PRE COM NAV OTC NOI DSP COR\"");
            this.IsNeedHeaders = true;
            this.Headers.Add("P3P", "CP=\"CURa ADMa DEVa PSAo PSDo OUR BUS UNI PUR INT DEM STA PRE COM NAV OTC NOI DSP COR\"");
            int uid;
            int.TryParse(this.QueryString["uid"], out uid);
            var temp = this._ucApi.SynLogin(uid);

            return Write(temp);
        }

        protected string SynLogout()
        {
            if (!_ucConfig.ApiSynLogout) return API_RETURN_FORBIDDEN;
            // TODO: 注意这里还有修改 Headers 的行为
            //Response.Headers.Add("P3P", "CP=\"CURa ADMa DEVa PSAo PSDo OUR BUS UNI PUR INT DEM STA PRE COM NAV OTC NOI DSP COR\"");
            this.IsNeedHeaders = true;
            this.Headers.Add("P3P", "CP=\"CURa ADMa DEVa PSAo PSDo OUR BUS UNI PUR INT DEM STA PRE COM NAV OTC NOI DSP COR\"");
            var temp = this._ucApi.SynLogout();

            return Write(temp);
        }

        protected string Test()
        {
            var temp = this._ucApi.Test();

            return Write(temp);
        }

        protected string UpdateApps()
        {
            if (!_ucConfig.ApiUpdateApps) return API_RETURN_FORBIDDEN;
            var apps = new UcApps(this.FormData);
            var temp = this._ucApi.UpdateApps(apps);

            return Write(temp);
        }

        protected string UpdateBadWords()
        {
            if (!_ucConfig.ApiUpdateBadWords) return API_RETURN_FORBIDDEN;
            var badWords = new UcBadWords(this.FormData);
            var temp = this._ucApi.UpdateBadWords(badWords);

            return Write(temp);
        }

        protected string UpdateClient()
        {
            if (!_ucConfig.ApiUpdateClient) return API_RETURN_FORBIDDEN;
            var client = new UcClientSetting(this.FormData);
            var temp = this._ucApi.UpdateClient(client);

            return Write(temp);
        }

        protected string UpdateCredit()
        {
            if (!_ucConfig.ApiUpdateCredit) return API_RETURN_FORBIDDEN;
            int uid;
            int.TryParse(this.QueryString["uid"], out uid);
            int credit;
            int.TryParse(this.QueryString["credit"], out credit);
            int amount;
            int.TryParse(this.QueryString["amount"], out amount);
            var temp = this._ucApi.UpdateCredit(uid, credit, amount);

            return Write(temp);
        }

        protected string UpdateCreditSettings()
        {
            if (!_ucConfig.ApiUpdateCreditSettings) return API_RETURN_FORBIDDEN;
            var creditSettings = new UcCreditSettings(this.FormData);
            var temp = this._ucApi.UpdateCreditSettings(creditSettings);

            return Write(temp);
        }

        protected string UpdateHosts()
        {
            if (!_ucConfig.ApiUpdateHosts) return API_RETURN_FORBIDDEN;
            var hosts = new UcHosts(this.FormData);
            var temp = this._ucApi.UpdateHosts(hosts);

            return Write(temp);
        }

        protected string UpdatePw()
        {
            if (!_ucConfig.ApiUpdatePw) return API_RETURN_FORBIDDEN;
            var username = this.QueryString["username"];
            var password = this.QueryString["password"];
            var temp = this._ucApi.UpdatePw(username, password);

            return Write(temp);
        }
        #endregion


        /// <summary>
        /// 检查合法性
        /// </summary>
        /// <returns></returns>
        protected virtual bool Check(out string msg)
        {
            msg = "";
            if (this.IsInvalidRequest)
            {
                msg = "Invalid Request";
            }
            if (this.IsAuthracationExpiried)
            {
                msg = "Authracation has expiried";
            }
            return true;
        }

        protected virtual string Write<T>(UcCollectionReturnBase<T> msg)
            where T : UcItemReturnBase
        {
            string rtn = msg.ToString();
            return rtn;
        }

        protected virtual string Write(ApiReturn result)
        {
            var msg = result == ApiReturn.Success ? API_RETURN_SUCCEED : API_RETURN_FAILED;

            return msg;
        }
    }
}

