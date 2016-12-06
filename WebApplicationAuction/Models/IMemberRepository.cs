using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationAuction.Models {
    public interface IMemberRepository {
        void AddMember(Member member);
        Member FetchByLoginName(string loginName);
        void SubmitChanges();
    }
}