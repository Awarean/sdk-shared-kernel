using System;
using Awarean.Sdk.SharedKernel.Events;
using Awarean.Sdk.SharedKernel.Tests.Fixtures;
using Awarean.Sdk.SharedKernel;
using FluentAssertions;
using Xunit;

namespace Awarean.Sdk.SharedKernel.Tests.AuditableEntityTests;

public class EventsTests
{
    [Fact]
    public void Updating_AuditableEntity_Should_Raise_Event()
    {
        var sut = new MockAuditableEntity();
        var eventRaised = false;

        sut.OnUpdate += (sender, eventArgs) => eventRaised = true;

        sut.MockUpdate("sender", "data");

        eventRaised.Should().BeTrue();
    }

    [Fact]
    public void AutidableEntityInstance_Should_Be_Event_Sender()
    {
        var sut = new MockAuditableEntity();
        object actualEventSender = null;

        sut.OnUpdate += (sender, eventArgs) => actualEventSender = sender;

        sut.MockUpdate("sender", "data");

        actualEventSender.Should().BeSameAs(sut);
        actualEventSender.Should().BeAssignableTo<AuditableEntity<Guid>>();
    }

    [Fact]
    public void UpdatedEntityEventArgs_Should_Reflect_Update()
    {
        var sut = new MockAuditableEntity();
        EntityUpdatedEventArgs actualEventArgs = default;
        var expectedUpdater = "test runner";
        var expectedData = "data";

        sut.OnUpdate += (sender, eventArgs) => actualEventArgs = eventArgs;

        sut.MockUpdate(expectedUpdater, expectedData);

        actualEventArgs.ChangeDate.Should().Be(sut.UpdatedAt);
        actualEventArgs.UpdatedBy.Should().Be(expectedUpdater);
    }

    [Fact]
    public void Updating_AuditableEntity_Should_Change_UpdatedAt()
    {
        var sut = new MockAuditableEntity();
        var firstUpdate = sut.UpdatedAt;

        sut.MockUpdate("sender", "data");

        var secondUpdate = sut.UpdatedAt;

        secondUpdate.Should().BeAfter(firstUpdate);
    }
}