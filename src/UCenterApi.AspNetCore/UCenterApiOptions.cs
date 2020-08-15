using System;
using System.Collections.Generic;
using System.Text;

namespace UCenterApi.AspNetCore
{
    public class UCenterApiOptions : BaseUcConfig
    {
        public override string UcKey { get; set; }
        public override string UcApi { get; set; }
        public override string UcAppid { get; set; }
    }
}
