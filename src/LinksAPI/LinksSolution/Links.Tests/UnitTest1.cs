

namespace Links.Tests;

public class UnitTest1
{
    [Fact] // Attibutes. Like ([HttpPost("/links")]
    public void Test1()
    {
        // Given Arrange
        int a = 10, b = 20, answer;


      

        // When Act
        answer = a + b;

        // then Assert
        Assert.Equal(30, answer);
    }
}


