using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AuctionDIandLoc.Models;
using AuctionDIandLoc.Controllers;

namespace AuctionDIandLoc.Tests
{
    [TestClass]
    public class AdminControllerTest
    {
        [TestMethod]
        public void CanChangeLoginName()
        {
            // Arrange (устанавливается сценарий)
            Member bob = new Member() { LoginName = "Bob" };
            FakeMembersRepository repositoryParam = new FakeMembersRepository();
            repositoryParam.Members.Add(bob);
            AdminController target = new AdminController(repositoryParam);
            string oldLoginParam = bob.LoginName;
            string newLoginParam = "Anastasia";
            // Act (проводится операция)
            target.ChangeLoginName(oldLoginParam, newLoginParam);
            // Assert (проверяется результат)
            Assert.AreEqual(newLoginParam, bob.LoginName);
            Assert.IsTrue(repositoryParam.DidSubmitChanges);
        }
        private class FakeMembersRepository : IMembersRepository
        {
            public List<Member> Members = new List<Member>();
            public bool DidSubmitChanges = false;
            public void AddMember(Member member)
            {
                throw new NotImplementedException();
            }
            public Member FetchByLoginName(string loginName)
            {
                return Members.First(m => m.LoginName == loginName);
            }
            public void SubmitChanges()
            {
                DidSubmitChanges = true;
            }
        }
    }
}