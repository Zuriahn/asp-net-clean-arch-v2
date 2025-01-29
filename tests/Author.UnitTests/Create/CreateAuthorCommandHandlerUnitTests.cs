using Application.Authors.Commands;
using Domain.Entities;
using Domain.Repository;
using Domain.Exceptions;
using Domain.Primitives;

namespace UnitTests.Author.Create
{
    public class CreateAuthorCommandHandlerUnitTests
    {
        private readonly Mock<IAuthorRepository> _mockAuthorRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly CreateAuthorCommandHandler _handler;

        public CreateAuthorCommandHandlerUnitTests()
        {
            _mockAuthorRepository = new Mock<IAuthorRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();

            _handler = new CreateAuthorCommandHandler(_mockAuthorRepository.Object, _mockUnitOfWork.Object);
        }

        [Fact]
        public async Task HandleCreateCustomer_WhenPhoneNumberHasBadFormat_ShouldReturnValidationError()
        {
            //Arrange
            // Se configura los parametros de entrada de nuestra prueba unitaria.
            CreateAuthorCommand command = new CreateAuthorCommand("Fernando", "33049439443", "", "", "", 0, "");
            //Act
            // Se ejecuta el metodo a probar de nuestra prueba unitaria
            var result = await _handler.Handle(command, default);
            //Assert
            // Se verifica los datos de retorno de nuestro metodo probado en la prueba unitaria
            result.IsError.Should().BeTrue();
            result.FirstError.Type.Should().Be(ErrorType.Validation);
            result.FirstError.Code.Should().Be(Errors.Author.PhoneNumberWithBadFormat.Code);
            result.FirstError.Description.Should().Be(Errors.Author.PhoneNumberWithBadFormat.Description);
        }
    }
}