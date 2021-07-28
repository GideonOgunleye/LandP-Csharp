Feature: TestFeature3
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@SmokeTest
Scenario: Login scenario of BugZilla 3
	# Steps - A Given Step
	When I click on File a Bug Link
	Then User should be at Login Page
	When I provide the "rahul@bugzila.com", "rathore" and click on Login button
	Then User Should be at Enter Bug page
	When I click on Logout button
	Then User should be logged out and should be at Home Page
