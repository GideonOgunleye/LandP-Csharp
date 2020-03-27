Feature: HomePage
	In order to test a deploy
	As a visitor
	I want to check the homepage is up and running:

@Smoke
Scenario: Home page is up
	Given I visit the Homepage
	Then I should be shown the main title 'OFFICIAL VISITOR GUIDE'

@Preview-Smoke
Scenario: Preview Home page is up
	#Given I visit the Homepage
	Given I Navigate To PreviewHomePage
	Then I should be shown the main title 'OFFICIAL VISITOR GUIDE'
