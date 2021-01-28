using GenEz.Character.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace GenEz.Character.Data.Mappings.EthnicityMapping
{
    internal partial class EducationRelationalMapping
    {
        private const string LessThanPrimaryId = "418A24C4-5E3A-41BE-AEC7-5F534CA09587";
        private const string PrimaryId = "CC1BFFD3-8272-48AE-85F0-F1B7ABEFFE06";
        private const string HighId = "A24F28BE-5288-438B-8710-5CDC180426A6";
        private const string SomeCollegeId = "04856059-D913-4615-B469-1F2ED2CF47F7";
        private const string BachelorId = "0BB2708D-D637-42EF-A728-93B6EB9F4F32";
        private const string MastersId = "606BA2FC-E154-438F-A9DE-7C2AD447886E";
        private const string DoctorateId = "814EF9BC-0E26-4154-9BD5-28476B909945";

        private void Seed(EntityTypeBuilder<Education> b) =>
            _ = b.HasData(
                new Education(new Guid(LessThanPrimaryId), "less than primary school", 0, 0, null, null),
                new Education(new Guid(PrimaryId), "primary school", 6, 5, null, null),
                new Education(new Guid(HighId), "high school", 15, 4, null, null),
                new Education(new Guid(SomeCollegeId), "some college", 17, 3, null, null),
                new Education(new Guid(BachelorId), "bachelor's degree", 17, 5, "Bachelor", null),
                new Education(new Guid(MastersId), "masters", 22, 2, "Master", null),
                new Education(new Guid(DoctorateId), "doctorate", 22, 2, "Doctor", "Dr."));
    }
}
