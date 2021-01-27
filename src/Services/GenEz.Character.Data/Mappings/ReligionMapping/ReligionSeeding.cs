using GenEz.Character.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace GenEz.Character.Data.Mappings.ReligionMapping
{
    internal partial class ReligionRelationalMapping
    {
        private const string ChristianityId = "418A24C4-5E3A-41BE-AEC7-5F534CA09587";
        private const string IslamId = "CC1BFFD3-8272-48AE-85F0-F1B7ABEFFE06";
        private const string AgnosticismId = "A24F28BE-5288-438B-8710-5CDC180426A6";
        private const string AtheismId = "04856059-D913-4615-B469-1F2ED2CF47F7";
        private const string HinduismId = "0BB2708D-D637-42EF-A728-93B6EB9F4F32";
        private const string BuddhismId = "606BA2FC-E154-438F-A9DE-7C2AD447886E";
        private const string TaoismId = "1CB3CDCE-5AA9-49AB-B18D-4E9F225CCBBE";
        private const string SikhismId = "A489AB07-7264-4C7D-881A-31504FC3A372";
        private const string SpiritismId = "BE87573A-91F0-4228-BF66-4BC4382467B7";
        private const string JudaismId = "5DDB4CC2-BEA2-4766-A870-9ABB852574DD";

        private void Seed(EntityTypeBuilder<Religion> b) =>
            _ = b.HasData(
                new Religion(new Guid(ChristianityId), "Christianity", false, "christian"),
                new Religion(new Guid(IslamId), "Islam", false, "muslim"),
                new Religion(new Guid(AgnosticismId), "Agnosticism", false, "agnostic"),
                new Religion(new Guid(AtheismId), "Atheism", false, "atheist"),
                new Religion(new Guid(HinduismId), "Hinduism", false, "hindu"),
                new Religion(new Guid(BuddhismId), "Buddhism", false, "buddhist"),
                new Religion(new Guid(TaoismId), "Taoism", false, "taoist"),
                new Religion(new Guid(SikhismId), "Sikhism", false, "sikh"),
                new Religion(new Guid(SpiritismId), "Spiritism", false, "spiritist"),
                new Religion(new Guid(JudaismId), "Judaism", false, "jew"));
    }
}