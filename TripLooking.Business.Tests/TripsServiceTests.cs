using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Moq;
using TripLooking.Business.Trips.Models;
using TripLooking.Business.Trips.Services;
using TripLooking.Entities.Trips;
using TripLooking.Persistence;
using Xunit;

namespace TripLooking.Business.Tests
{
    public class TripsServiceTests: IDisposable
    {
        private readonly MockRepository _mockRepository = new(MockBehavior.Strict);

        private readonly TripsService _sut;

        private Mock<ITripsRepository> _tripsRepository;
        private Mock<IMapper> _mapper;

        public TripsServiceTests()
        {
            CreateMocks();
            _sut = CreateSut();
        }

        public void Dispose()
        {
            _mockRepository.VerifyAll();
        }

        private void CreateMocks()
        {
            _tripsRepository = _mockRepository.Create<ITripsRepository>();
            _mapper = _mockRepository.Create<IMapper>();
        }

        private TripsService CreateSut() => new(_tripsRepository.Object, _mapper.Object);

        [Fact]
        public void When_GetAllIsCalled_ExpectInvokeGetAllFromRepository_and_ReturnMappedResults()
        {
            // Arrange
            var tripEntities = new List<Trip> {new Trip("dummy", "dummy", false)};
            var tripModels = new List<TripModel> {new TripModel{Id = tripEntities.First().Id, Title = "dummy", Description = "dummy", Private = false}};
            _tripsRepository.Setup(mock => mock.GetAll()).Returns(tripEntities.AsEnumerable());
            _mapper.Setup(mock => mock.Map<IEnumerable<TripModel>>(tripEntities)).Returns(tripModels.AsEnumerable());

            // Act
            var result = _sut.GetAll();

            // Assert
            result.Should().BeEquivalentTo(tripModels);
        }

        [Fact]
        public async void When_GetByIdIsCalled_ExpectInvokeGetTripByIdFromRepository_and_ReturnMappedResults()
        {
            // Arrange
            var trip = new Trip("dummy", "dummy", false);
            var tripModel = new TripModel {Id = trip.Id, Title = "dummy", Description = "dummy", Private = false};

            _tripsRepository.Setup(mock => mock.GetTripById(trip.Id)).Returns(Task.FromResult(trip));
            _mapper.Setup(mock => mock.Map<TripModel>(trip)).Returns(tripModel);

            // Act
            var result = await _sut.GetById(trip.Id);

            // Assert
            result.Should().BeEquivalentTo(tripModel);
        }

        [Fact]
        public async void When_CreateIsCalled_ExpectInvokeCreateAndSaveChangesFromRepository_and_ReturnMappedResult()
        {
            // Arrange
            var trip = new Trip("dummy", "dummy", false);
            var upsertTripModel = new UpsertTripModel {Title = "dummy", Description = "dummy", Private = false};
            var tripModel = new TripModel {Id = trip.Id, Title = "dummy", Description = "dummy", Private = false};

            _mapper.Setup(mock => mock.Map<Trip>(upsertTripModel)).Returns(trip);
            _tripsRepository.Setup(mock => mock.Create(trip)).Returns(Task.CompletedTask);
            _tripsRepository.Setup(mock => mock.SaveChanges()).Returns(Task.CompletedTask);
            _mapper.Setup(mock => mock.Map<TripModel>(trip)).Returns(tripModel);

            // Act
            var result = await _sut.Create(upsertTripModel);

            // Assert
            result.Should().BeEquivalentTo(tripModel);
        }

        [Fact]
        public async void When_DeleteIsCalled_ExpectInvokeGetTripByIdAndDeleteFromRepository()
        {
            // Arrange
            var trip = new Trip("dummy", "dummy", false);

            _tripsRepository.Setup(mock => mock.GetTripById(trip.Id)).Returns(Task.FromResult(trip));
            _tripsRepository.Setup(mock => mock.Delete(trip));
            _tripsRepository.Setup(mock => mock.SaveChanges()).Returns(Task.CompletedTask);

            // Act
            await _sut.Delete(trip.Id);

            // Assert
            // The asertion is done by MockRepository that checks (in Dispose method)
            // that all setups were used, and there is no missing setup.
        }

        [Fact]
        public async void When_UpdateIsCalled_ExpectInvokeGetTripByIdAndUpdateFromRepository()
        {
            // Arrange
            var trip = new Trip("dummy", "dummy", false);
            var upsertTripModel = new UpsertTripModel {Title = "dummy", Description = "dummy", Private = false};

            _mapper.Setup(mock => mock.Map(upsertTripModel, trip)).Returns(trip);
            _tripsRepository.Setup(mock => mock.GetTripById(trip.Id)).Returns(Task.FromResult(trip));
            _tripsRepository.Setup(mock => mock.Update(trip));
            _tripsRepository.Setup(mock => mock.SaveChanges()).Returns(Task.CompletedTask);

            // Act
            await _sut.Update(trip.Id, upsertTripModel);

            // Assert
            // The asertion is done by MockRepository that checks (in Dispose method)
            // that all setups were used, and there is no missing setup.
        }
    }
}