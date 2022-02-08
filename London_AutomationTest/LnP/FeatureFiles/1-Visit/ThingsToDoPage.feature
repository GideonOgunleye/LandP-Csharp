Feature: ThingsToDoPage
	In order to test a deploy
	As a visitor
	I want to check the Things To Do Hub page is up and running:
		- Home page
		- Product page
		- Event calendar
		- Things to do
		- London tube

@Qa-Smoke
Scenario: Things to do hub is up
	Given I navigate to the thing to do hub page '/things-to-do'
	#And I don't see an error code
	Then I should be shown the title
	Then I should be shown the intro copy

@Preview-Smoke
Scenario: Preview Things to do hub is up
	Given I navigate to the Preview thing to do hub page '/things-to-do'
	#And I don't see an error code
	Then I should be shown the title
	Then I should be shown the intro copy
