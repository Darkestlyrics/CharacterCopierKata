using CharacterCopierKata;
using CharacterCopierKata.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace CharacterCopierKataTests
{
    [TestFixture]
    public class CopierTests
    {
        private IDestination _subDestination;
        private ISource _subSource;

        [SetUp]
        public void SetUp()
        {
            this._subDestination = Substitute.For<IDestination>();
            this._subSource = Substitute.For<ISource>();
        }

        private Copier CreateCopier(char[] testData)
        {
            this._subSource.ReadChar().Returns(' ', testData);
            return new Copier(
                this._subDestination,
                this._subSource);
        }

        [Test]
        public void Copy_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var testData = new [] {'z', 'x', 'y', '\n', 'a'};
            var copier = this.CreateCopier(testData);

            // Act
            copier.Copy();

            // Assert
            _subSource.Received(5).ReadChar();
        }


        [Test]
        public void Copy_StartsWithNewLine()
        {
            // Arrange
            var testData = new[] {'\n','z', 'x', 'y', '\n', 'a' };
            var copier = this.CreateCopier(testData);

            // Act
            copier.Copy();

            // Assert
            _subSource.Received(2).ReadChar();
        }
    }
}
