using GenEz.Character.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace GenEz.Character.Data.Mappings.SexualOrientationMapping
{
    internal partial class SexualOrientationRelationalMapping
    {
        private const string AndrosexualId = "418A24C4-5E3A-41BE-AEC7-5F534CA09587";
        private const string GynesexualId = "CC1BFFD3-8272-48AE-85F0-F1B7ABEFFE06";
        private const string AsexualId = "A24F28BE-5288-438B-8710-5CDC180426A6";
        private const string AutosexualId = "04856059-D913-4615-B469-1F2ED2CF47F7";
        private const string BicuriousId = "0BB2708D-D637-42EF-A728-93B6EB9F4F32";
        private const string BisexualId = "606BA2FC-E154-438F-A9DE-7C2AD447886E";
        private const string GayId = "1CB3CDCE-5AA9-49AB-B18D-4E9F225CCBBE";
        private const string StraightId = "A489AB07-7264-4C7D-881A-31504FC3A372";
        private const string PansexualId = "D7A9CAB4-703D-47F7-92B3-87B3281C2ED0";

        private void Seed(EntityTypeBuilder<SexualOrientation> b) =>
            _ = b.HasData(
                new SexualOrientation(new Guid(AndrosexualId), "androsexual", null, false),
                new SexualOrientation(new Guid(GynesexualId), "gynesexual", null, true),
                new SexualOrientation(new Guid(AsexualId), "asexual", null, null),
                new SexualOrientation(new Guid(AutosexualId), "autosexual", null, null),
                new SexualOrientation(new Guid(BicuriousId), "bicurious", null, null),
                new SexualOrientation(new Guid(BisexualId), "bisexual", null, null),
                new SexualOrientation(new Guid(GayId), "gay", false, null),
                new SexualOrientation(new Guid(StraightId), "straight", true, null),
                new SexualOrientation(new Guid(PansexualId), "pansexual", null, null));
    }
}
