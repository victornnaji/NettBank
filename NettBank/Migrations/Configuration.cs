namespace NettBank.Migrations
{
    using NettBank.Models;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NettBank.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NettBank.Models.ApplicationDbContext context)
        {
            var CarLoan = new LoanType{ Name = "Car Loan" , Icon ="Car.svg"};
            var StudentLoan = new LoanType { Name = "Student Loan", Icon = "Student.svg" };
            var PropertyLoan = new LoanType { Name = "Property Loan", Icon = "Property.svg" };
            var BusinessLoan = new LoanType { Name = "Business Loan", Icon = "Business.svg" };

            var LoanCompanies = new List<LoanCompany>()
           {
               new LoanCompany()
               {
                Name = "Abeg",
                Rating = 4,
                InterestRate = 3.78,
                ComparisonRate = 3.99,
                MaxAmount = 5000000,
                MinAmount = 100000,
                MaxDuration = 5,
                ImagePath = "Abeg.svg",
                RepaymentFrequency = "Monthly",
                Catch = "Better Service",
                LoanTypes = new List<LoanType>() {CarLoan, StudentLoan}
               },

               new LoanCompany()
               {
                Name = "Access Bank",
                Rating = 4.1,
                InterestRate = 4.08,
                ComparisonRate = 4.19,
                MaxAmount = 50000000,
                MinAmount = 100000,
                MaxDuration = 10,
                ImagePath = "AccessBank.svg",
                RepaymentFrequency = "Monthly",
                
                LoanTypes = new List<LoanType>() {CarLoan, StudentLoan, BusinessLoan, PropertyLoan}
               },

               new LoanCompany()
               {
                Name = "Aella Credit",
                Rating = 4.0,
                InterestRate = 3.54,
                ComparisonRate = 3.70,
                MaxAmount = 5000000,
                MinAmount = 100000,
                MaxDuration = 2,
                ImagePath = "AellaCredit.svg",
                RepaymentFrequency = "Monthly",
                
                LoanTypes = new List<LoanType>() {BusinessLoan}
               },

               new LoanCompany()
               {
                Name = "ALAT",
                Rating = 4.5,
                InterestRate = 5.58,
                ComparisonRate = 6.19,
                MaxAmount = 50000000,
                MinAmount = 500000,
                MaxDuration = 8,
                ImagePath = "ALAT.svg",
                RepaymentFrequency = "Monthly",
                
                LoanTypes = new List<LoanType>() {CarLoan, StudentLoan, BusinessLoan, PropertyLoan}
               },

               new LoanCompany()
               {
                Name = "Aso Savings Nigeria",
                Rating = 4,
                InterestRate = 3.08,
                ComparisonRate = 3.19,
                MaxAmount = 5000000,
                MinAmount = 100000,
                MaxDuration = 4,
                ImagePath = "AsoSavings.svg",
                RepaymentFrequency = "Quarterly",
                LoanTypes = new List<LoanType>() {CarLoan, StudentLoan}
               },
               new LoanCompany()
               {
                Name = "AXA Mansard",
                Rating = 4.7,
                InterestRate = 5.00,
                ComparisonRate = 5.19,
                MaxAmount = 100000000,
                MinAmount = 1000000,
                MaxDuration = 10,
                ImagePath = "AXAMansard.svg",
                RepaymentFrequency = "Monthly",
                Catch = "Business Friendly",
                LoanTypes = new List<LoanType>() {CarLoan, StudentLoan, BusinessLoan, PropertyLoan}
               },
               new LoanCompany()
               {
                Name = "Barter",
                Rating = 4.5,
                InterestRate = 3.00,
                ComparisonRate = 3.15,
                MaxAmount = 20000000,
                MinAmount = 1000000,
                MaxDuration = 3,
                ImagePath = "Barter.svg",
                RepaymentFrequency = "Monthly",
                LoanTypes = new List<LoanType>() {StudentLoan,PropertyLoan}
               },
               new LoanCompany()
               {
                Name = "Branch",
                Rating = 4.3,
                InterestRate = 4.00,
                ComparisonRate = 4.30,
                MaxAmount = 30000000,
                MinAmount = 100000,
                MaxDuration = 4,
                ImagePath = "Branch.svg",
                RepaymentFrequency = "Monthly",
                Catch = "School and student",
                LoanTypes = new List<LoanType>() {StudentLoan}
               },
               new LoanCompany()
               {
                Name = "Cowrywise",
                Rating = 4.9,
                InterestRate = 5.00,
                ComparisonRate = 5.30,
                MaxAmount = 100000000,
                MinAmount = 1000000,
                MaxDuration = 6,
                ImagePath = "Cowrywise.svg",
                RepaymentFrequency = "Monthly",
                LoanTypes = new List<LoanType>() {CarLoan, StudentLoan, BusinessLoan, PropertyLoan}
               },

               new LoanCompany()
               {
                Name = "EcoBank",
                Rating = 4.3,
                InterestRate = 8.10,
                ComparisonRate = 8.15,
                MaxAmount = 100000000,
                MinAmount = 500000,
                MaxDuration = 12,
                ImagePath = "Ecobank.svg",
                RepaymentFrequency = "Monthly",
                LoanTypes = new List<LoanType>() {CarLoan, StudentLoan, BusinessLoan, PropertyLoan}
               },

               new LoanCompany()
               {
                Name = "Eyowo",
                Rating = 4.8,
                InterestRate = 5.78,
                ComparisonRate = 6.00,
                MaxAmount = 30000000,
                MinAmount = 500000,
                MaxDuration = 5,
                ImagePath = "Eyowo.svg",
                RepaymentFrequency = "Monthly",
                Catch = "Best Service",
                LoanTypes = new List<LoanType>() {CarLoan, StudentLoan, BusinessLoan, PropertyLoan}
               },

               new LoanCompany()
               {
                Name = "FarmCrowdy",
                Rating = 4.6,
                InterestRate = 4.18,
                ComparisonRate = 4.30,
                MaxAmount = 10000000,
                MinAmount = 500000,
                MaxDuration = 7,
                ImagePath = "Farmcrwody.svg",
                RepaymentFrequency = "Monthly",
                LoanTypes = new List<LoanType>() {PropertyLoan}
               },

               new LoanCompany()
               {
                Name = "FCMB",
                Rating = 4,
                InterestRate = 7.78,
                ComparisonRate = 7.90,
                MaxAmount = 100000000,
                MinAmount = 1000000,
                MaxDuration = 20,
                ImagePath = "FCMB.svg",
                RepaymentFrequency = "Monthly",
                
                LoanTypes = new List<LoanType>() {CarLoan, StudentLoan, BusinessLoan, PropertyLoan}
               },

               new LoanCompany()
               {
                Name = "Fidelity Bank",
                Rating = 4.1,
                InterestRate = 9.78,
                ComparisonRate = 10.00,
                MaxAmount = 300000000,
                MinAmount = 100000,
                MaxDuration = 21,
                ImagePath = "FidelityBank.svg",
                RepaymentFrequency = "Monthly",
                LoanTypes = new List<LoanType>() {CarLoan, StudentLoan, BusinessLoan, PropertyLoan}
               },

               new LoanCompany()
               {
                Name = "Fliqpay",
                Rating = 4.8,
                InterestRate = 3.08,
                ComparisonRate = 3.20,
                MaxAmount = 1000000,
                MinAmount = 500000,
                MaxDuration = 4,
                ImagePath = "Fliqpay.svg",
                RepaymentFrequency = "Monthly",
                Catch = "Best Service",
                LoanTypes = new List<LoanType>() {CarLoan, StudentLoan, PropertyLoan}
               },

               new LoanCompany()
               {
                Name = "GTB",
                Rating = 4.2,
                InterestRate = 8.78,
                ComparisonRate = 8.99,
                MaxAmount = 30000000,
                MinAmount = 100000,
                MaxDuration = 7,
                ImagePath = "GTB.svg",
                RepaymentFrequency = "Monthly",
                
                LoanTypes = new List<LoanType>() {CarLoan, StudentLoan, BusinessLoan, PropertyLoan}
               },

               new LoanCompany()
               {
                Name = "Heritage Bank",
                Rating = 4,
                InterestRate = 6.8,
                ComparisonRate = 7.00,
                MaxAmount = 15000000,
                MinAmount = 500000,
                MaxDuration = 6,
                ImagePath = "HeritageBank.svg",
                RepaymentFrequency = "Monthly",
                Catch = "Best Service",
                LoanTypes = new List<LoanType>() {CarLoan, StudentLoan, BusinessLoan, PropertyLoan}
               },

               new LoanCompany()
               {
                Name = "KoraPay",
                Rating = 4.5,
                InterestRate = 5.78,
                ComparisonRate = 6.00,
                MaxAmount = 1000000,
                MinAmount = 50000,
                MaxDuration = 4,
                ImagePath = "Korapay.svg",
                RepaymentFrequency = "Monthly",
                Catch = "Cheapest Loan",
                LoanTypes = new List<LoanType>() {StudentLoan, BusinessLoan}
               },

               new LoanCompany()
               {
                Name = "LendSqr",
                Rating = 4.8,
                InterestRate = 4.28,
                ComparisonRate = 4.40,
                MaxAmount = 10000000,
                MinAmount = 500000,
                MaxDuration = 7,
                ImagePath = "Lendsqr.svg",
                RepaymentFrequency = "Monthly",
                Catch = "Best Service",
                LoanTypes = new List<LoanType>() {StudentLoan, BusinessLoan, PropertyLoan}
               },

               new LoanCompany()
               {
                Name = "OnePipe",
                Rating = 4.8,
                InterestRate = 5.78,
                ComparisonRate = 6.10,
                MaxAmount = 30000000,
                MinAmount = 500000,
                MaxDuration = 6,
                ImagePath = "OnePipe.svg",
                RepaymentFrequency = "Monthly",
                
                LoanTypes = new List<LoanType>() {CarLoan, StudentLoan, BusinessLoan, PropertyLoan}
               },

               new LoanCompany()
               {
                Name = "Paga",
                Rating = 4.7,
                InterestRate = 6.00,
                ComparisonRate = 6.20,
                MaxAmount = 20000000,
                MinAmount = 1000000,
                MaxDuration = 7,
                ImagePath = "Paga.svg",
                RepaymentFrequency = "Monthly",
                
                LoanTypes = new List<LoanType>() {CarLoan, StudentLoan, BusinessLoan, PropertyLoan}
               },

               new LoanCompany()
               {
                Name = "Paylater",
                Rating = 4.8,
                InterestRate = 5.00,
                ComparisonRate = 5.10,
                MaxAmount = 20000000,
                MinAmount = 500000,
                MaxDuration = 4,
                ImagePath = "Paylater.svg",
                RepaymentFrequency = "Monthly",
                
                LoanTypes = new List<LoanType>() {CarLoan, BusinessLoan, PropertyLoan}
               },

               new LoanCompany()
               {
                Name = "PayStack",
                Rating = 5,
                InterestRate = 7.78,
                ComparisonRate = 8.00,
                MaxAmount = 15000000,
                MinAmount = 500000,
                MaxDuration = 7,
                ImagePath = "Paystack.svg",
                RepaymentFrequency = "Quarterly",
                Catch = "Best Service",
                LoanTypes = new List<LoanType>() {CarLoan, StudentLoan, BusinessLoan, PropertyLoan}
               },

               new LoanCompany()
               {
                Name = "PiggyVest",
                Rating = 4.8,
                InterestRate = 6.87,
                ComparisonRate = 7.00,
                MaxAmount = 30000000,
                MinAmount = 500000,
                MaxDuration = 5,
                ImagePath = "PiggyVest.svg",
                RepaymentFrequency = "Monthly",
                Catch = "Best Service",
                LoanTypes = new List<LoanType>() {CarLoan, StudentLoan, BusinessLoan, PropertyLoan}
               },

               new LoanCompany()
               {
                Name = "Quickteller",
                Rating = 4.5,
                InterestRate = 9.08,
                ComparisonRate = 9.15,
                MaxAmount = 100000000,
                MinAmount = 1000000,
                MaxDuration = 10,
                ImagePath = "Quickteller.svg",
                RepaymentFrequency = "Monthly",
                Catch = "Broad Service",
                LoanTypes = new List<LoanType>() {CarLoan, StudentLoan, BusinessLoan, PropertyLoan}
               },

               new LoanCompany()
               {
                Name = "RenMoney",
                Rating = 4.7,
                InterestRate = 5.00,
                ComparisonRate = 5.10,
                MaxAmount = 3000000,
                MinAmount = 500000,
                MaxDuration = 6,
                ImagePath = "RenMoney.svg",
                RepaymentFrequency = "Monthly",
                
                LoanTypes = new List<LoanType>() {CarLoan, StudentLoan, BusinessLoan, PropertyLoan}
               },

               new LoanCompany()
               {
                Name = "Schoolable",
                Rating = 4.3,
                InterestRate = 3.08,
                ComparisonRate = 3.16,
                MaxAmount = 1000000,
                MinAmount = 50000,
                MaxDuration = 6,
                ImagePath = "Schoolable.svg",
                RepaymentFrequency = "Monthly",
                Catch = "Student Services",
                LoanTypes = new List<LoanType>() {StudentLoan}
               },

               new LoanCompany()
               {
                Name = "Standard Chartered",
                Rating = 4.7,
                InterestRate = 8.01,
                ComparisonRate = 8.20,
                MaxAmount = 3000000,
                MinAmount = 100000,
                MaxDuration = 9,
                ImagePath = "StandardCharterd.svg",
                RepaymentFrequency = "Monthly",
                
                LoanTypes = new List<LoanType>() {CarLoan, StudentLoan, BusinessLoan, PropertyLoan}
               },

               new LoanCompany()
               {
                Name = "Sterling Bank",
                Rating = 4.3,
                InterestRate = 10.00,
                ComparisonRate = 10.10,
                MaxAmount = 30000000,
                MinAmount = 100000,
                MaxDuration = 9,
                ImagePath = "SterlingBank.svg",
                RepaymentFrequency = "Monthly",
                
                LoanTypes = new List<LoanType>() {CarLoan, StudentLoan, BusinessLoan, PropertyLoan}
               },

               new LoanCompany()
               {
                Name = "Thank U Cash",
                Rating = 4.9,
                InterestRate = 4.08,
                ComparisonRate = 4.12,
                MaxAmount = 500000,
                MinAmount = 20000,
                MaxDuration = 4,
                ImagePath = "ThankUCash.svg",
                RepaymentFrequency = "Yearly",
                Catch = "Best Loan",
                LoanTypes = new List<LoanType>() {StudentLoan, BusinessLoan,}
               },

               new LoanCompany()
               {
                Name = "Ventures Platform",
                Rating = 4,
                InterestRate = 5,
                ComparisonRate = 5.10,
                MaxAmount = 10000000,
                MinAmount = 500000,
                MaxDuration = 4,
                ImagePath = "VenturesPlatform .svg",
                RepaymentFrequency = "Monthly",
                
                LoanTypes = new List<LoanType>() {StudentLoan, BusinessLoan, PropertyLoan}
               },

               new LoanCompany()
               {
                Name = "Verifi",
                Rating = 4.5,
                InterestRate = 5.78,
                ComparisonRate = 6.00,
                MaxAmount = 30000000,
                MinAmount = 500000,
                MaxDuration = 3,
                ImagePath = "VerifiLogo.svg",
                RepaymentFrequency = "Monthly",
                
                LoanTypes = new List<LoanType>() {CarLoan, StudentLoan, BusinessLoan, PropertyLoan}
               },

               new LoanCompany()
               {
                Name = "Verve",
                Rating = 4,
                InterestRate = 7.80,
                ComparisonRate = 8.00,
                MaxAmount = 10000000,
                MinAmount = 100000,
                MaxDuration = 5,
                ImagePath = "VerveLogo.svg",
                RepaymentFrequency = "Monthly",
           
                LoanTypes = new List<LoanType>() {CarLoan, StudentLoan, BusinessLoan, PropertyLoan}
               },

               new LoanCompany()
               {
                Name = "Wallets Africa",
                Rating = 4.4,
                InterestRate = 4.87,
                ComparisonRate = 4.90,
                MaxAmount = 12000000,
                MinAmount = 100000,
                MaxDuration = 5,
                ImagePath = "WalletsAfrica.svg",
                RepaymentFrequency = "Monthly",
                Catch = "Best Service",
                LoanTypes = new List<LoanType>() {CarLoan, StudentLoan, BusinessLoan, PropertyLoan}
               },

               new LoanCompany()
               {
                Name = "Wema Bank",
                Rating = 4.2,
                InterestRate = 10.78,
                ComparisonRate = 10.90,
                MaxAmount = 30000000,
                MinAmount = 500000,
                MaxDuration = 12,
                ImagePath = "WemaBank.svg",
                RepaymentFrequency = "Monthly",
                LoanTypes = new List<LoanType>() {CarLoan, StudentLoan, BusinessLoan, PropertyLoan}
               },
           };


            if (!context.LoanCompanies.Any())
            {
                context.LoanCompanies.AddRange(LoanCompanies);
                context.SaveChanges();
            }
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
