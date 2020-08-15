using System;
using System.Collections.Generic;
using System.Text;
using UCenterApi.Model.CollectionReceive;
using UCenterApi.Model.CollectionReturn;
using UCenterApi.Model.ItemReceive;

namespace UCenterApi.Api
{
    public interface IUcApi
    {
        /// <summary>
        /// 此接口供仅测试连接。当 UCenter 发起 test 的接口请求时，如果成功获取到接口返回的 API_RETURN_SUCCEED 值，表示 UCenter 和应用通讯正常
        /// </summary>
        /// <returns></returns>
        ApiReturn Test();

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="ids">Uid</param>
        /// <returns></returns>
        ApiReturn DeleteUser(IEnumerable<int> ids);
        /// <summary>
        /// 重命名
        /// </summary>
        /// <param name="uid">Uid</param>
        /// <param name="oldUserName">旧用户名</param>
        /// <param name="newUserName">新用户名</param>
        /// <returns></returns>
        ApiReturn RenameUser(int uid, string oldUserName, string newUserName);
        /// <summary>
        /// 得到标签
        /// </summary>
        /// <param name="tagName">标签名</param>
        /// <returns></returns>
        UcTagReturns GetTag(string tagName);
        /// <summary>
        /// 同步登陆
        /// </summary>
        /// <param name="uid">uid</param>
        /// <returns></returns>
        ApiReturn SynLogin(int uid);
        /// <summary>
        /// 同步登出
        /// </summary>
        /// <returns></returns>
        ApiReturn SynLogout();
        /// <summary>
        /// 更新密码
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="passWord">密码</param>
        /// <returns></returns>
        ApiReturn UpdatePw(string userName, string passWord);
        /// <summary>
        /// 更新不良词汇
        /// </summary>
        /// <param name="badWords">不良词汇</param>
        /// <returns></returns>
        ApiReturn UpdateBadWords(UcBadWords badWords);
        /// <summary>
        /// 更新Hosts
        /// </summary>
        /// <param name="hosts">Hosts</param>
        /// <returns></returns>
        ApiReturn UpdateHosts(UcHosts hosts);
        /// <summary>
        /// 更新App
        /// </summary>
        /// <param name="apps">App</param>
        /// <returns></returns>
        ApiReturn UpdateApps(UcApps apps);
        /// <summary>
        /// 更新UCenter设置
        /// </summary>
        /// <param name="client">UCenter设置</param>
        /// <returns></returns>
        ApiReturn UpdateClient(UcClientSetting client);
        /// <summary>
        /// 更新用户积分
        /// </summary>
        /// <param name="uid">Uid</param>
        /// <param name="credit">积分编号</param>
        /// <param name="amount">积分增减</param>
        /// <returns></returns>
        ApiReturn UpdateCredit(int uid, int credit, int amount);
        /// <summary>
        /// 得到积分设置
        /// </summary>
        /// <returns></returns>
        UcCreditSettingReturns GetCreditSettings();
        /// <summary>
        /// 得到积分
        /// </summary>
        /// <param name="uid">Uid</param>
        /// <param name="credit">积分编号</param>
        /// <returns></returns>
        ApiReturn GetCredit(int uid, int credit);
        /// <summary>
        /// 更新积分设置
        /// </summary>
        /// <param name="creditSettings">积分设置</param>
        /// <returns></returns>
        ApiReturn UpdateCreditSettings(UcCreditSettings creditSettings);

    }

    /// <summary>
    /// 返回类型
    /// </summary>
    public enum ApiReturn
    {
        /// <summary>
        /// 失败
        /// </summary>
        Failed,
        /// <summary>
        /// 成功
        /// </summary>
        Success,
    }
}
