using GenEz.Character.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace GenEz.Character.Data.Mappings.SocialClassMapping
{
    internal partial class SocialClassRelationalMapping
    {
        private const string WorkingId = "BE0C73E9-2710-4676-9478-EE36A9E6F96E";
        private const string MiddleId = "F7A540BD-DDC7-421D-A879-0E7974A5633B";
        private const string UpperId = "81F4BB6E-3C6D-4EE4-A7C6-4F18BE3DD478";

        private void Seed(EntityTypeBuilder<SocialClass> b) =>
            _ = b.HasData(
                new SocialClass(new Guid(WorkingId), "working"),
                new SocialClass(new Guid(MiddleId), "middle"),
                new SocialClass(new Guid(UpperId), "upper"));
    }
}
