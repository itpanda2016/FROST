using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplicationAuction.Models;

namespace WebApplicationAuction.Controllers
{
    [TestClass]
    public class AdminControllerTest {
        [TestMethod]
        public void CanChangeLoginName() {
            Member bob = new Member() { LoginName = "Bob" };
            FakeMembersRepository repositoryParam = new FakeMembersRepository();
            repositoryParam.Members.Add(bob);
            AdminController target = new AdminController(repositoryParam);
            string oldLoginName = bob.LoginName;
            string newLoginName = "Anstasisa";

            target.ChangeLoginName(oldLoginName, newLoginName);

            Assert.AreEqual(newLoginName, bob.LoginName);
            Assert.IsTrue(repositoryParam.DidSubmitChanges);
        }

        private class FakeMembersRepository : IMemberRepository {
            public List<Member> Members = new List<Member>();
            public bool DidSubmitChanges = false;
            public void AddMember(Member member) {
                throw new NotImplementedException();
            }
            public Member FetchByLoginName(string loginName) {
                return Members.First(m => m.LoginName == loginName);
            }
            public void SubmitChanges() {
                DidSubmitChanges = true;
            }
        }

        [TestMethod()]
        public void CanAddBid() {
            //准备建立一个场景
            Item target = new Item();
            Member memberParam = new Member();
            Decimal amountParam = 150M;

            //运作——执行测试
            target.AddBid(memberParam, amountParam);

            //断言——检查其行为
            Assert.AreEqual(1, target.Bids.Count());
            Assert.AreEqual(amountParam, target.Bids[0].BidAmount);
        }
        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CannotAddLowerBid() {
            //准备
            Item target = new Item();
            Member memberParam = new Member();
            Decimal amountParam = 150M;

            //动作
            target.AddBid(memberParam, amountParam);
            target.AddBid(memberParam, amountParam - 10); 
        }
        [TestMethod()]
        public void CanAddHigherBid() {
            //准备
            Item target = new Item();
            Member firstMember = new Member();
            Member secondMember = new Member();
            Decimal amountParam = 150M;

            //动作
            target.AddBid(firstMember, amountParam);
            target.AddBid(secondMember, amountParam + 10);

            //断言
            Assert.AreEqual(2, target.Bids.Count());
            Assert.AreEqual(amountParam + 10, target.Bids[1].BidAmount);
        }
    }
}