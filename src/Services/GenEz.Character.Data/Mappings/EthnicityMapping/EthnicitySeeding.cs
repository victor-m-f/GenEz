using GenEz.Character.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace GenEz.Character.Data.Mappings.EthnicityMapping
{
    internal partial class EthnicityRelationalMapping
    {
        private const string CaucasianId = "418A24C4-5E3A-41BE-AEC7-5F534CA09587";
        private const string MixedId = "CC1BFFD3-8272-48AE-85F0-F1B7ABEFFE06";
        private const string LatinId = "A24F28BE-5288-438B-8710-5CDC180426A6";
        private const string AfricanId = "04856059-D913-4615-B469-1F2ED2CF47F7";
        private const string MiddleEasternId = "0BB2708D-D637-42EF-A728-93B6EB9F4F32";
        private const string AmerindianId = "606BA2FC-E154-438F-A9DE-7C2AD447886E";
        private const string AsianId = "1CB3CDCE-5AA9-49AB-B18D-4E9F225CCBBE";
        private const string SouthAsianId = "A489AB07-7264-4C7D-881A-31504FC3A372";

        private void Seed(EntityTypeBuilder<Ethnicity> b) =>
            _ = b.HasData(
                new Ethnicity(new Guid(CaucasianId), "caucasian"),
                new Ethnicity(new Guid(MixedId), "mixed"),
                new Ethnicity(new Guid(LatinId), "latin"),
                new Ethnicity(new Guid(AfricanId), "african"),
                new Ethnicity(new Guid(MiddleEasternId), "middle eastern"),
                new Ethnicity(new Guid(AmerindianId), "amerindian"),
                new Ethnicity(new Guid(AsianId), "asian"),
                new Ethnicity(new Guid(SouthAsianId), "south asian"));
    }
}
