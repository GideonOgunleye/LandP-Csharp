Feature: HomePage
	In order to test a deploy
	As a visitor
	I want to check the homepage is up and running:

#@web
Scenario: Home page is up
	Given I visit the Homepage
	Then I should be shown the main title 'OFFICIAL VISITOR GUIDE'
