using System.Collections.Generic;


namespace UCenterApi
{
    /// <summary>
    /// 配置
    /// Dozer 版权所有
    /// 允许复制、修改，但请保留我的联系方式！
    /// http://www.dozer.cc
    /// mailto:dozer.cc@gmail.com
    /// 
    /// 修改: yiyun
    /// </summary>
    public interface IUcConfig
    {
        /// <summary>
        /// 客户端版本
        /// </summary>
        string UcClientVersion { get; set; }

        /// <summary>
        /// 发行时间
        /// </summary>
        string UcClientRelease { get; set; }

        /// <summary>
        /// 是否允许删除用户
        /// </summary>
        bool ApiDeleteUser { get; set; }

        /// <summary>
        /// 是否允许重命名用户
        /// </summary>
        bool ApiRenameUser { get; set; }

        /// <summary>
        /// 是否允许得到标签
        /// </summary>
        bool ApiGetTag { get; set; }

        /// <summary>
        /// 是否允许同步登录
        /// </summary>
        bool ApiSynLogin { get; set; }

        /// <summary>
        /// 是否允许同步登出
        /// </summary>
        bool ApiSynLogout { get; set; }

        /// <summary>
        /// 是否允许更改密码
        /// </summary>
        bool ApiUpdatePw { get; set; }

        /// <summary>
        /// 是否允许更新关键字
        /// </summary>
        bool ApiUpdateBadWords { get; set; }

        /// <summary>
        /// 是否允许更新域名解析缓存
        /// </summary>
        bool ApiUpdateHosts { get; set; }

        /// <summary>
        /// 是否允许更新应用列表
        /// </summary>
        bool ApiUpdateApps { get; set; }

        /// <summary>
        /// 是否允许更新客户端缓存
        /// </summary>
        bool ApiUpdateClient { get; set; }

        /// <summary>
        /// 是否允许更新用户积分
        /// </summary>
        bool ApiUpdateCredit { get; set; }

        /// <summary>
        /// 是否允许向UCenter提供积分设置
        /// </summary>
        bool ApiGetCreditSettings { get; set; }

        /// <summary>
        /// 是否允许获取用户的某项积分
        /// </summary>
        bool ApiGetCredit { get; set; }

        /// <summary>
        /// 是否允许更新应用积分设置
        /// </summary>
        bool ApiUpdateCreditSettings { get; set; }

        ///// <summary>
        ///// 返回成功
        ///// </summary>
        //string ApiReturnSucceed { get; set; }

        ///// <summary>
        ///// 返回失败
        ///// </summary>
        //string ApiReturnFailed { get; set; }

        ///// <summary>
        ///// 返回禁用
        ///// </summary>
        //string ApiReturnForbidden { get; set; }

        /// <summary>
        /// 与 UCenter 的通信密钥, 要与 UCenter 保持一致
        /// </summary>
        string UcKey { get; set; }

        /// <summary>
        /// UCenter地址
        /// </summary>
        string UcApi { get; set; }

        /// <summary>
        /// 默认编码
        /// </summary>
        string UcCharset { get; set; }

        /// <summary>
        /// UCenter IP
        /// </summary>
        string UcIp { get; set; }

        /// <summary>
        /// 应用ID
        /// </summary>
        string UcAppid { get; set; }
    }
}

