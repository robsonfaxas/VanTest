using System;
using Bogus;
using VanhackTest.Application.FakeDB.Enums;
using VanhackTest.Core.Utils;


namespace VanhackTest.Application.FakeDB
{
   public class Jobs
   {
            private static int nextId = 1;

            public int Id { get; set; }
            public DateTime CreatedAt { get; set; }
            public int NumberOfPositions { get; set; }
            public string CompanyName { get; set; }
            public string Title { get; set; }
            public string Area { get; set; }
            public string  Description { get; set; }
            public string  Skills { get; set; }
            public string  Slug { get; set; }
            public int TotalHires { get; set; }
            public string FlagCode { get; set; }
            public string Location { get; set; }
            public string Relocate { get; set; }
            public Decimal SalaryFrom { get; set; }
            public Decimal SalaryTo { get; set; }
            public string Currency { get; set; }
            public string JobType { get; set; }
            public bool CanApply { get; set; }

            public static Faker<Jobs> FakeJobs { get; } = new Faker<Jobs>()
                        .RuleFor(p => p.Id, f => nextId++)
                        .RuleFor(p => p.CreatedAt, f => f.Date.Past(18))
                        .RuleFor(p => p.NumberOfPositions, f => f.Random.Int(0, 10))
                        .RuleFor(p => p.CompanyName, f => f.Company.CompanyName())
                        .RuleFor(p => p.Title, f => f.Name.JobTitle())
                        .RuleFor(p => p.Area, f => f.Name.JobDescriptor())
                        .RuleFor(p => p.Description, f => f.Lorem.Text())
                        .RuleFor(p => p.Skills, f => f.Lorem.Lines())
                        .RuleFor(p => p.Slug, f => f.Lorem.Slug())
                        .RuleFor(p => p.TotalHires, f => f.Random.Int(0, 10))
                        .RuleFor(p => p.FlagCode, f => f.Address.CountryCode())
                        .RuleFor(p => p.Location, f => string.Format("{0} - {1}", f.Address.City(), f.Address.Country()))
                        .RuleFor(p => p.Relocate, f => f.Random.Enum<Relocate>().GetEnumDescription())
                        .RuleFor(p => p.SalaryFrom, f => f.Finance.Amount(25000,35000,0) )
                        .RuleFor(p => p.SalaryTo, f => f.Finance.Amount(35001,99999,0) )
                        .RuleFor(p => p.JobType, f => f.Name.JobType())
                        .RuleFor(p => p.Currency, f => f.Random.Enum<Currency>().GetEnumDescription())
                        .RuleFor(p => p.CanApply, f => f.Random.Bool());

   }

}
 