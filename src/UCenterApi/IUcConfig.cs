using System.Collections.Generic;


namespace UCenterApi
{
    /// <summary>
    /// ����
    /// Dozer ��Ȩ����
    /// �����ơ��޸ģ����뱣���ҵ���ϵ��ʽ��
    /// http://www.dozer.cc
    /// mailto:dozer.cc@gmail.com
    /// 
    /// �޸�: yiyun
    /// </summary>
    public interface IUcConfig
    {
        /// <summary>
        /// �ͻ��˰汾
        /// </summary>
        string UcClientVersion { get; set; }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        string UcClientRelease { get; set; }

        /// <summary>
        /// �Ƿ�����ɾ���û�
        /// </summary>
        bool ApiDeleteUser { get; set; }

        /// <summary>
        /// �Ƿ������������û�
        /// </summary>
        bool ApiRenameUser { get; set; }

        /// <summary>
        /// �Ƿ�����õ���ǩ
        /// </summary>
        bool ApiGetTag { get; set; }

        /// <summary>
        /// �Ƿ�����ͬ����¼
        /// </summary>
        bool ApiSynLogin { get; set; }

        /// <summary>
        /// �Ƿ�����ͬ���ǳ�
        /// </summary>
        bool ApiSynLogout { get; set; }

        /// <summary>
        /// �Ƿ������������
        /// </summary>
        bool ApiUpdatePw { get; set; }

        /// <summary>
        /// �Ƿ�������¹ؼ���
        /// </summary>
        bool ApiUpdateBadWords { get; set; }

        /// <summary>
        /// �Ƿ��������������������
        /// </summary>
        bool ApiUpdateHosts { get; set; }

        /// <summary>
        /// �Ƿ��������Ӧ���б�
        /// </summary>
        bool ApiUpdateApps { get; set; }

        /// <summary>
        /// �Ƿ�������¿ͻ��˻���
        /// </summary>
        bool ApiUpdateClient { get; set; }

        /// <summary>
        /// �Ƿ���������û�����
        /// </summary>
        bool ApiUpdateCredit { get; set; }

        /// <summary>
        /// �Ƿ�������UCenter�ṩ��������
        /// </summary>
        bool ApiGetCreditSettings { get; set; }

        /// <summary>
        /// �Ƿ������ȡ�û���ĳ�����
        /// </summary>
        bool ApiGetCredit { get; set; }

        /// <summary>
        /// �Ƿ��������Ӧ�û�������
        /// </summary>
        bool ApiUpdateCreditSettings { get; set; }

        ///// <summary>
        ///// ���سɹ�
        ///// </summary>
        //string ApiReturnSucceed { get; set; }

        ///// <summary>
        ///// ����ʧ��
        ///// </summary>
        //string ApiReturnFailed { get; set; }

        ///// <summary>
        ///// ���ؽ���
        ///// </summary>
        //string ApiReturnForbidden { get; set; }

        /// <summary>
        /// �� UCenter ��ͨ����Կ, Ҫ�� UCenter ����һ��
        /// </summary>
        string UcKey { get; set; }

        /// <summary>
        /// UCenter��ַ
        /// </summary>
        string UcApi { get; set; }

        /// <summary>
        /// Ĭ�ϱ���
        /// </summary>
        string UcCharset { get; set; }

        /// <summary>
        /// UCenter IP
        /// </summary>
        string UcIp { get; set; }

        /// <summary>
        /// Ӧ��ID
        /// </summary>
        string UcAppid { get; set; }
    }
}

