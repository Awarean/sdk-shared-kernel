using System;
using Awarean.Sdk.SharedKernel.Events;
using Awarean.Sdk.SharedKernel.Tests.Fixtures;
using Awaren.Sdk.SharedKernel;
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

        sut.Update(sut);

        eventRaised.Should().BeTrue();
    }

    [Fact]
    public void AutidableEntityInstance_Should_Be_Event_Sender()
    {
        var sut = new MockAuditableEntity();
        object actualEventSender = null;

        sut.OnUpdate += (sender, eventArgs) => actualEventSender = sender;

        sut.Update(sut);

        actualEventSender.Should().BeSameAs(sut);
        actualEventSender.Should().BeAssignableTo<AuditableEntity>();
    }

    [Fact]
    public void AutidableEntityInstance_Should_Be_Event_Sender()
    {
        var sut = new MockAuditableEntity();
        EntityUpdatedEventArgs actualEventArgs = default;

        sut.OnUpdate += (sender, eventArgs) => actualEventArgs = eventArgs;

        sut.Update(sut);

        actualEventArgs.ChangeDate.Should().Be(sut.UpdatedAt);
        actualEventArgs.UpdatedBy.Should().Be(sut);
    }

    [Fact]
    public void Updating_AuditableEntity_Should_Change_UpdatedAt()
    {
        var sut = new MockAuditableEntity();
        var firstUpdate = sut.UpdatedAt;

        sut.Update(sut);

        var secondUpdate = sut.UpdatedAt;

        secondUpdate.Should().BeAfter(firstUpdate);
    }
}