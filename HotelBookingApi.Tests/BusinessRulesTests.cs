
using Xunit;

namespace HotelBookingApi.Tests
{

    public class BusinessRulesTests
    {
        [Fact]
        public void FindAvailableRooms_ShouldExcludeBookedRooms()
        {
            // TODO: Arrange AvailabilityService with context including booking overlap
            // TODO: Act service.FindAvailableRooms
            // TODO: Assert booked room is excluded
        }

        [Fact]
        public void CreateBooking_ShouldThrow_WhenRoomDoubleBooked()
        {
            // TODO: Arrange BookingService with existing booking
            // TODO: Act & Assert exception thrown on double booking
        }

        [Fact]
        public void CreateBooking_ShouldThrow_WhenGuestCountExceedsCapacity()
        {
            // TODO: Arrange BookingService and room with limited capacity
            // TODO: Act & Assert exception thrown when guest count too high
        }

        [Fact]
        public void BusinessRules_ShouldEnforceRoomTypesAndCapacities()
        {
            // TODO: Arrange model or service checks
            // TODO: Act and assert RoomType enum has Single, Double, Deluxe and capacities
        }

        [Fact]
        public void BookingReference_ShouldBeUnique()
        {
            // TODO: Arrange service with duplicate reference scenario
            // TODO: Act & Assert exception or error on duplicate reference
        }
    }

}
