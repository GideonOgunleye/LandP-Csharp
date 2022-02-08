Feature: Convention_AccommodationPage
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@Qa-Smoke
Scenario: Convention Search Accommodation Page Is Up
	Given I Navigate to Accommodation Search Page '/search-accommodation'
	Then I Should See 'Qa' Search Results

@Preview-Smoke
Scenario: Convention Preview Search Accommodation Page Is Up
	Given I Navigate to Preview Accommodation Search Page '/search-accommodation'
	Then I Should See 'Preview' Search Results


