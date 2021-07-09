using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Http.Internal;
using Moq;
using TripLooking.Business.Trips.Models.Photos;
using TripLooking.Business.Trips.Services.Photos;
using TripLooking.Entities.Trips;
using TripLooking.Persistence;
using Xunit;

namespace TripLooking.Business.Tests
{
    public class PhotosServiceTests : TestsBase<PhotosService>
    {
        private Mock<ITripsRepository> _tripsRepository;
        private Mock<IMapper> _mapper;

        protected override void CreateMocks()
        {
            _tripsRepository = MockRepository.Create<ITripsRepository>();
            _mapper = MockRepository.Create<IMapper>();
        }

        protected override PhotosService CreateSUT() => new(_tripsRepository.Object, _mapper.Object);

        [Fact]
        public async void When_AddIsCalled_ExpectInvokeGetAllAndUpdateFromRepository_and_ReturnMappedResults()
        {
            // Arrange
            var trip = new Trip("dummy", "dummy", false);
            var createPhotoModel = new CreatePhotoModel
            {
                Content = new FormFile(Stream.Null, 0, 0, "dummyName", "dummyFileName")
            };

            await using var stream = new MemoryStream();
            await createPhotoModel.Content.CopyToAsync(stream);
            var photo = new Photo(createPhotoModel.Content.FileName, stream.ToArray());
            var photoModel = new PhotoModel
            {
                Id = Guid.NewGuid(),
                Name = photo.Name
            };

            _tripsRepository.Setup(mock => mock.GetTripById(trip.Id)).Returns(Task.FromResult(trip));
            _tripsRepository.Setup(mock => mock.Update(trip));
            _tripsRepository.Setup(mock => mock.SaveChanges()).Returns(Task.CompletedTask);
            _mapper.Setup(mock => mock.Map<PhotoModel>(It.IsAny<Photo>())).Returns(photoModel);

            // Act
            var result = await SUT.Add(trip.Id, createPhotoModel);

            // Assert
            result.Should().BeEquivalentTo(photoModel);
        }

        [Fact]
        public async void When_GetByIdIsCalled_ExpectInvokeGetTripByIdFromRepo_And_ReturnMappedModel()
        {
            // Arrange
            var trip = new Trip("dummy", "dummy", false);
            var photo = new Photo("dummy", Array.Empty<byte>());
            trip.Photos.Add(photo);
            var photoModel = new PhotoModel
            {
                Id = photo.Id,
                Name = photo.Name,
                PhotoContent = photo.PhotoContent
            };

            _tripsRepository.Setup(mock => mock.GetTripById(trip.Id)).Returns(Task.FromResult(trip));
            _mapper.Setup(mock => mock.Map<PhotoModel>(photo)).Returns(photoModel);

            // Act
            var result = await SUT.GetById(trip.Id, photo.Id);

            // Assert
            result.Should().BeEquivalentTo(photoModel);
        }

        [Fact]
        public async void When_GetIsCalled_ExpectGetTripByIdFromRepoToBeCalled_And_ReturnsMappedResult()
        {
            var trip = new Trip("dummy", "dummy", false);
            trip.Photos.Add(new Photo("dummy1", Array.Empty<byte>()));
            trip.Photos.Add(new Photo("dummy2", Array.Empty<byte>()));

            var expectedResult = trip.Photos.Select(p => new PhotoModel
            {
                Id = p.Id,
                Name = p.Name,
                PhotoContent = p.PhotoContent
            }).ToList();

            _tripsRepository.Setup(mock => mock.GetTripById(trip.Id)).Returns(Task.FromResult(trip));
            _mapper.Setup(mock => mock.Map<IEnumerable<PhotoModel>>(trip.Photos)).Returns(expectedResult);
            var result = await SUT.Get(trip.Id);

            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}
