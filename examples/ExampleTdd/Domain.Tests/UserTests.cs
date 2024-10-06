namespace Domain.Tests;

[TestClass]
public class UserTests
{
    private string _name;
    private string _lastName;
    [TestInitialize]
    public void OnInitialize()
    {
        
         _name = "Martin";
         _lastName = "Rado";
        
    }
    [TestMethod]
    public void Create_User()
    {
        var age = 10;
        User u = new User(_name,_lastName, age);
        
        Assert.AreEqual(_name, u.Name);
        Assert.AreEqual(_lastName, u.LastName);
        Assert.AreEqual(age, u.Age);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Valid_Age_Test()
    {
        var age = 9;
        User u = new User(_name,_lastName, age);
    }
}