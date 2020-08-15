using System;
using System.Collections.Generic;
using System.Text;

namespace UCenterApi
{
    public abstract class BaseUcConfig : IUcConfig
    {
        public BaseUcConfig()
        {

        }

        public virtual string UcClientVersion { get; set; } = "1.5.2";
        public virtual string UcClientRelease { get; set; } = "20101001";
        public virtual bool ApiDeleteUser { get; set; } = true;
        public virtual bool ApiRenameUser { get; set; } = true;
        public virtual bool ApiGetTag { get; set; } = true;
        public virtual bool ApiSynLogin { get; set; } = true;
        public virtual bool ApiSynLogout { get; set; } = true;
        public virtual bool ApiUpdatePw { get; set; } = true;
        public virtual bool ApiUpdateBadWords { get; set; } = true;
        public virtual bool ApiUpdateHosts { get; set; } = true;
        public virtual bool ApiUpdateApps { get; set; } = true;
        public virtual bool ApiUpdateClient { get; set; } = true;
        public virtual bool ApiUpdateCredit { get; set; } = true;
        public virtual bool ApiGetCreditSettings { get; set; } = true;
        public virtual bool ApiGetCredit { get; set; } = true;
        public virtual bool ApiUpdateCreditSettings { get; set; } = true;

        //public virtual string ApiReturnSucceed { get; set; } = "1";
        //public virtual string ApiReturnFailed { get; set; } = "-1";
        //public virtual string ApiReturnForbidden { get; set; } = "-2";

        public abstract string UcKey { get; set; }
        public abstract string UcApi { get; set; }
        public virtual string UcCharset { get; set; } = "utf-8";
        public virtual string UcIp { get; set; } = "";
        public abstract string UcAppid { get; set; }
    }
}
