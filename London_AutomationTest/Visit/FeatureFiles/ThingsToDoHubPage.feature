Feature: ThingsToDoHubPage
	In order to test a deploy
	As a visitor
	I want to check the Things To Do Hub page is up and running:
		- Home page
		- Product page
		- Event calendar
		- Things to do
		- London tube

#@mytag
Scenario: Things to do hub is up
	Given I navigate to the thing to do hub page '/things-to-do'
	And I don't see an error code
	Then I should be shown the title
	Then I should be shown the intro copy
