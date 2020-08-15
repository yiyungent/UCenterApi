using System.Collections.Generic;
using UCenterApi.Model.CollectionReceive;
using UCenterApi.Model.CollectionReturn;
using UCenterApi.Model.ItemReceive;

namespace UCenterApi.Api
{
    /// <summary>
    /// UCenter -> 你使用UCenterApi的站点
    /// 供 UCenter 通过 HTTP 调用
    /// </summary>
    public abstract class BaseUcApi : IUcApi
    {
        public virtual ApiReturn Test()
        {
            return ApiReturn.Success;
        }

        #region 抽象 Apis

        public abstract ApiReturn DeleteUser(IEnumerable<int> ids);

        public abstract ApiReturn GetCredit(int uid, int credit);

        public abstract UcCreditSettingReturns GetCreditSettings();

        public abstract UcTagReturns GetTag(string tagName);

        public abstract ApiReturn RenameUser(int uid, string oldUserName, string newUserName);

        public abstract ApiReturn SynLogin(int uid);

        public abstract ApiReturn SynLogout();

        public abstract ApiReturn UpdateApps(UcApps apps);

        public abstract ApiReturn UpdateBadWords(UcBadWords badWords);

        public abstract ApiReturn UpdateClient(UcClientSetting client);

        public abstract ApiReturn UpdateCredit(int uid, int credit, int amount);

        public abstract ApiReturn UpdateCreditSettings(UcCreditSettings creditSettings);

        public abstract ApiReturn UpdateHosts(UcHosts hosts);

        public abstract ApiReturn UpdatePw(string userName, string passWord);

        #endregion


    }
}
