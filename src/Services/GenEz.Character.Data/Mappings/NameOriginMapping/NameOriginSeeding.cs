using GenEz.Character.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace GenEz.Character.Data.Mappings.NameOriginMapping
{
    internal partial class NameOriginRelationalMapping
    {
        private const string AfricanId = "BE0C73E9-2710-4676-9478-EE36A9E6F96E";
        private const string ArabicId = "F7A540BD-DDC7-421D-A879-0E7974A5633B";
        private const string CelticId = "81F4BB6E-3C6D-4EE4-A7C6-4F18BE3DD478";
        private const string ChineseId = "E376EA1A-0F28-4F67-809A-A78BCC0A7183";
        private const string FrenchId = "838C1BE0-06B0-48AC-9268-C69072280F90";
        private const string GaelicId = "208ED58E-D875-473A-A67E-3DC3E034C783";
        private const string GermanId = "EB47FD93-662F-45A8-B6F4-FE63400D0C3D";
        private const string GreekId = "0C101315-5611-4967-ACB0-27E124D5DE1C";
        private const string HawaiianId = "6408B9EA-D64F-4F22-9045-133788ECB4B6";
        private const string HebrewId = "24ECC259-89E2-4B20-B1F5-7890A5E4E820";
        private const string HinduId = "EE7088E9-706B-49C6-8468-ED57DDFAED12";
        private const string ItalianId = "4455EA44-E256-4F38-B120-5DA91007AEF6";
        private const string JapaneseId = "BC3D3311-4353-4FE7-85F8-E9816CA2E80A";
        private const string LatinId = "FCB12666-B2F2-4A00-A9E8-0B48E46653CD";
        private const string PortugueseId = "9DA6842E-8F89-4A04-A187-973BEF4F0D45";
        private const string RussianId = "609C53B7-968C-46B0-B231-01E0DDC6A351";

        private void Seed(EntityTypeBuilder<NameOrigin> b) =>
            _ = b.HasData(
                new NameOrigin(new Guid(AfricanId), "African"),
                new NameOrigin(new Guid(ArabicId), "Arabic"),
                new NameOrigin(new Guid(CelticId), "Celtic"),
                new NameOrigin(new Guid(ChineseId), "Chinese"),
                new NameOrigin(new Guid(FrenchId), "French"),
                new NameOrigin(new Guid(GaelicId), "Gaelic"),
                new NameOrigin(new Guid(GermanId), "German"),
                new NameOrigin(new Guid(GreekId), "Greek"),
                new NameOrigin(new Guid(HawaiianId), "Hawaiian"),
                new NameOrigin(new Guid(HebrewId), "Hebrew"),
                new NameOrigin(new Guid(HinduId), "Hindu"),
                new NameOrigin(new Guid(ItalianId), "Italian"),
                new NameOrigin(new Guid(JapaneseId), "Japanese"),
                new NameOrigin(new Guid(LatinId), "Latin"),
                new NameOrigin(new Guid(PortugueseId), "Portuguese"),
                new NameOrigin(new Guid(RussianId), "Russian"));
    }
}
