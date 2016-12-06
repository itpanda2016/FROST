using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationAuction.Models {
    public class MemberRepository:IMemberRepository {
        public void AddMember(Member member) {

        }
        public Member FetchByLoginName(string loginName) {
            return new Member();
        }
        public void SubmitChanges() {

        }
    }
}