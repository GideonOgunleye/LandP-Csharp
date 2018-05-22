Feature: HomePage
	In order to test a deploy
	As a visitor
	I want to check the homepage is up and running:

#@mytag
Scenario: Home page is up
	Given I visit the Homepage
	And I don't see an error code
	Then I should be shown the main title 'OFFICIAL VISITOR GUIDE'
