/*
 * Unit testing lecture
 * 
 * what do you need to write to show that the user can not log in?
 * write a test for the simplest thing that is not working
 * get the simpliest thing to work
 * 
 * 
 * right click on solution explorer
 *	add new project
 *		add MSTest
 *		
 *		
 * right click on test project dependencies
 *	Add Project References
 *		add project to be tested
 * write a test ex: Login_GivenValidUserNameAndPassword_Success()
 *		methodBeingTested_whatIsBeingTested_ExpectedResults
 * 
 * ****NOTE Write production test based on failing tests**************
 * [TestClass]
 * public class PersonTests
 * {
 *		Person Person = new Person();	OR
 *		Person Person = new();
 *		string UserName = "Intigo.Montoya";
 *		string Password = "";
 *		
 *		[TestInitialize]
 *		public void Initialize()
 *		{
 *			Password = "YouKilledMyF@ther!";
 *		}
 *		
 *		[TestMethod]
 *		public void Login_GivenValidUserNameAndPassword_Success()
 *		{
 *					Person.Login(userName: "user", password: "Password");	OR
 *			bool success = Person.Login(UserName, password);
 *			Assert.IsTrue(success);
 *		}
 *		
 *		[TestMethod]
 *		public void Login_GivenInvalidPassword_Failure()
 *		{
 *			Password = "InvalidPwd";
 *			bool result = Person.Login(UserName, Password);
 *			Assert.IsFalse(result);
 *		}
 *		
 *		[TestMethod]
 *		Login_GivenInvalidUsername_Failure()
 *		{
 *			userName = "MarkMichaelis";
 *			bool result = Person.Login(userName, Password);
 *			Assert.IsFalse(results);
 *		}
 *		
 *		
 *		
 * }//end PersonTests
 * 
 * 
 * 
 * 
 * testm tab tab to generate a test method
 * renaming a variable: ctrl+. enter
 * Ctrl+r t to run test
 * Ctrl+r Ctrl+t to debug test
 * 
 * refactor code as you make test. Both test code and production code
 * 
 * 
 * 
 */
