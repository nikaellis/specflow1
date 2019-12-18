Feature: NW
	As NorthWind user
	I want to verify login to the application


Scenario: Login-Add-Logout Tests
	Given I open "http://localhost:5000" url
	When I login with "user" username and "user" password
	Then Login is successfull
	When I click All product link
	Then open All product page
	When I click Create new
	Then open Product editing page
	And create New Product
	Then I check product exist
	And Logout
	




