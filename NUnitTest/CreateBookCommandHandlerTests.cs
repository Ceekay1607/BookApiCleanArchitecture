using Application.Book.Commands;
using Application.DTOs.Requests.Book;
using Application.Interfaces;

namespace NUnitTest;

[TestFixture]
public class Tests
{
    private Mock<IBookRepository> _mockBookRepository;
    private CreateBookCommandHandler _handler;

    [SetUp]
    public void Setup()
    {
        _mockBookRepository = new Mock<IBookRepository>();
        _handler = new CreateBookCommandHandler(_mockBookRepository.Object);
    }

    [Test]
    public async Task Handle_ValidRequest_CreatesBookAndReturnsId()
    {
        // Arrange
        var command = new CreateBookCommand { Title = "Test Book", Author = "Test Author", Price = 1 };
        var expectedBookId = 1;

        _mockBookRepository.Setup(repo => repo.CreateBookAsync(It.IsAny<CreateBookRequest>()))
                           .ReturnsAsync(expectedBookId);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.AreEqual(expectedBookId, result);
        _mockBookRepository.Verify(repo => repo.CreateBookAsync(It.Is<CreateBookRequest>(b =>
            b.Title == command.Title &&
            b.Author == command.Author &&
            b.Price == command.Price)), Times.Once);
    }

    [Test]
    public async Task Handle_InvalidPrice_ThrowsArgumentException()
    {
        // Arrange
        var command = new CreateBookCommand { Title = "Test Book", Author = "Test Author", Price = -1 };

        // Act 
        var exception = Assert.ThrowsAsync<ArgumentException>(async () =>
            await _handler.Handle(command, CancellationToken.None));

        //Assert
        Assert.AreEqual("Price must be a positive number.", exception.Message);
    }

    [Test]
    public async Task Handle_InvalidAuthor_ThrowsArgumentException()
    {
        //Arrage
        var command = new CreateBookCommand {Title = "", Author = "Test Author", Price = 1};

        // Act
        var exception = Assert.ThrowsAsync<ArgumentException>(async () => 
            await _handler.Handle(command, CancellationToken.None));

        // Assert
        Assert.AreEqual("Attribute cannot be null", exception.Message);

    }
}