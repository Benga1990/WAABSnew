using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using WAABSnew.Models;

namespace WAABSnew.DataAccessLayer
{
    public class WAABSInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<WAABSContext>
    {
        protected override void Seed(WAABSContext context)
        {
            var buyers = new List<BuyerModel>
            {
                new BuyerModel{FirstName="Dave", LastName="Smith", JoinDate=DateTime.Parse("2020-01-01"), InProcess=false},
                new BuyerModel{FirstName="Gen", LastName="Bodby", JoinDate=DateTime.Parse("2019-03-01"), InProcess=false},
                new BuyerModel{FirstName="Steve", LastName="Jobs", JoinDate=DateTime.Parse("2020-04-01"), InProcess=false}
            };

            buyers.ForEach(s => context.BuyerModels.Add(s));
            context.SaveChanges();

            var sellers = new List<SellerModel>
            {
                new SellerModel{FirstName = "Micky", LastName = "Jicky", JoinDate = DateTime.Parse("2020-02-01"), InProcess = false },
                new SellerModel{FirstName = "Mickyz", LastName = "Jickyz", JoinDate = DateTime.Parse("2020-03-01"), InProcess = false },
                new SellerModel{FirstName = "Dicky", LastName = "McNicky", JoinDate = DateTime.Parse("2020-04-01"), InProcess = false },
            };

            sellers.ForEach(s => context.SellerModels.Add(s));
            context.SaveChanges();

            var estateAgents = new List<EstateAgentModel>
            {
                new EstateAgentModel{CompanyName = "Collins", FirstName = "Loon", LastName = "Goon", JoinDate = DateTime.Parse("2020-03-07")},
                new EstateAgentModel{CompanyName = "Rollins", FirstName = "Moon", LastName = "Toony", JoinDate = DateTime.Parse("2020-03-07")},
                new EstateAgentModel{CompanyName = "Jesusolins", FirstName = "Dream", LastName = "Chocolate", JoinDate = DateTime.Parse("2020-03-09")}
            };

            estateAgents.ForEach(s => context.EstateAgentModels.Add(s));
            context.SaveChanges();

            var bankStaff = new List<BankModel>
            {
                new BankModel{CompanyName = "Bank1", FirstName = "Soon", LastName = "Goon", JoinDate = DateTime.Parse("2020-03-07")},
                new BankModel{CompanyName = "Bank2", FirstName = "Soony", LastName = "Goon", JoinDate = DateTime.Parse("2020-03-07")},
                new BankModel{CompanyName = "Bank1000", FirstName = "Soon", LastName = "Goon", JoinDate = DateTime.Parse("2020-03-07")}
            };

            bankStaff.ForEach(s => context.BankModels.Add(s));
            context.SaveChanges();

            var solicitors = new List<SolicitorModel>
            {
                new SolicitorModel{CompanyName = "Solic1", FirstName = "Soon", LastName = "Goon", JoinDate = DateTime.Parse("2020-03-07")},
                new SolicitorModel{CompanyName = "Solic2", FirstName = "Sooney", LastName = "Gooneys", JoinDate = DateTime.Parse("2020-03-10")},
                new SolicitorModel{CompanyName = "Solic300", FirstName = "Sooneyzz", LastName = "Gooneysz", JoinDate = DateTime.Parse("2020-04-10")},
            };

            solicitors.ForEach(s => context.SolicitorModels.Add(s));
            context.SaveChanges();
        }
    }
}