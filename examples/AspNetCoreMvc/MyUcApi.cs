using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCenterApi.Api;
using UCenterApi.Model.CollectionReceive;
using UCenterApi.Model.CollectionReturn;
using UCenterApi.Model.ItemReceive;

namespace AspNetCoreMvc
{
    public class MyUcApi : BaseUcApi
    {
        public override ApiReturn DeleteUser(IEnumerable<int> ids)
        {
            Console.WriteLine($"{nameof(DeleteUser)}: {string.Join(",", ids)}");

            return ApiReturn.Success;
        }

        public override ApiReturn GetCredit(int uid, int credit)
        {
            Console.WriteLine($"{nameof(GetCredit)}: {uid}, {credit}");

            return ApiReturn.Success;
        }

        public override UcCreditSettingReturns GetCreditSettings()
        {
            Console.WriteLine(nameof(GetCreditSettings));
            var rtn = new UcCreditSettingReturns();
            rtn.Items.Add(new UCenterApi.Model.ItemReturn.UcCreditSettingReturn("Q币", "2"));


            return rtn;
        }

        public override UcTagReturns GetTag(string tagName)
        {
            Console.WriteLine($"{nameof(GetTag)}: {tagName}");
            var rtn = new UcTagReturns("test", new UCenterApi.Model.ItemReturn.UcTagReturn("t", 1, "admin", DateTime.Now, "eee", "eee"));

            return rtn;
        }

        public override ApiReturn RenameUser(int uid, string oldUserName, string newUserName)
        {
            Console.WriteLine($"{nameof(RenameUser)}: {uid}, {oldUserName}, {newUserName}");

            return ApiReturn.Success;
        }

        public override ApiReturn SynLogin(int uid)
        {
            Console.WriteLine($"{nameof(SynLogin)}: {uid}");

            return ApiReturn.Success;
        }

        public override ApiReturn SynLogout()
        {
            Console.WriteLine($"{nameof(SynLogout)}");

            return ApiReturn.Success;
        }

        public override ApiReturn UpdateApps(UcApps apps)
        {
            Console.WriteLine($"{nameof(UpdateApps)}");

            return ApiReturn.Success;
        }

        public override ApiReturn UpdateBadWords(UcBadWords badWords)
        {
            Console.WriteLine($"{nameof(UpdateBadWords)}");

            return ApiReturn.Success;
        }

        public override ApiReturn UpdateClient(UcClientSetting client)
        {
            Console.WriteLine($"{nameof(UpdateClient)}");

            return ApiReturn.Success;
        }

        public override ApiReturn UpdateCredit(int uid, int credit, int amount)
        {
            Console.WriteLine($"{nameof(UpdateCredit)}");

            return ApiReturn.Success;
        }

        public override ApiReturn UpdateCreditSettings(UcCreditSettings creditSettings)
        {
            Console.WriteLine($"{nameof(UpdateCreditSettings)}");

            return ApiReturn.Success;
        }

        public override ApiReturn UpdateHosts(UcHosts hosts)
        {
            Console.WriteLine($"{nameof(UpdateHosts)}");

            return ApiReturn.Success;
        }

        public override ApiReturn UpdatePw(string userName, string passWord)
        {
            Console.WriteLine($"{nameof(UpdatePw)}: {userName}, {passWord}");

            return ApiReturn.Success;
        }
    }
}
